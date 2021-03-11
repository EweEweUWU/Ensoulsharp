using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using SharpDX;
using static EzAIO.Champions.Kalista.Extension;
namespace EzAIO.Champions.Kalista.Modes
{
    using static Configs; 
    using static Kalista;
    using static ChampionBases;
    static class Automatic
    {
        public static void CastR()
        {
            if (!AutomaticMenu.RAllysave.Enabled || !R.IsReady())
            {
                return;
            }
            var allyR = GameObjects.AllyHeroes.FirstOrDefault(x => HasRBuff(x, R.Range));
            if (allyR == null)
            {
                return;
            }

            if (allyR.DistanceToPlayer() <= R.Range && allyR.HealthPercent <= AutomaticMenu.RAllysave.Value)
            {
                R.Cast();
            }
        }

        public static void CastW()
        {
            if (!W.IsReady() || GameObjects.Player.IsRecalling())
            {
                return;
            }

            var DrakePos = new Vector3(9866f, 4414f, -71);
            var Baronpos = new Vector3(5007f, 10471f, -71);
            if (GameObjects.Player.Position.CountEnemyHeroesInRange(2000f) <= 0)
            {
                if (AutomaticMenu.WDrake.Enabled)
                {
                    if (GameObjects.Player.Distance(DrakePos) <= W.Range)
                    {
                        W.Cast(DrakePos);
                    }
                }

                if (AutomaticMenu.WBaron.Enabled)
                {
                    if (GameObjects.Player.Distance(Baronpos) <= W.Range)
                    {
                        W.Cast(Baronpos);
                    }
                }
            }
        }
    }
}