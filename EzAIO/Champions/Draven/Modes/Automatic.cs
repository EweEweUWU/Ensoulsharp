using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastWSlowed()
        {
            if (!AutomaticMenu.WSlowedBool.Enabled)
            {
                return;
            }

            if (GameObjects.Player.HasBuffOfType(BuffType.Slow))
            {
                W.Cast();
            }
        }

        public static void CastRImmobile()
        {
            if (!AutomaticMenu.RImmobileBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>
                x.IsValidTarget(R.Range) && !x.IsInvulnerable && x.HaveImmovableBuff()))
            {
                var rinput = R.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High)
                {
                    R.Cast(rinput.UnitPosition);
                }
            }
        }
    }
}