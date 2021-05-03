using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Ashe;
namespace EzAIO.Champions.Ashe.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastR()
        {
            if (!AutomaticMenu.Rinmobile.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsStunned &&
                                                                    x.IsValidTarget(R.Range)))
            {
                if (AutomaticMenu.NoEnemiesSliderButton.Enabled && Player.CountEnemyHeroesInRange(W.Range) >=
                    AutomaticMenu.NoEnemiesSliderButton.Value)
                {
                    return;
                }

                var rinput = R.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High && R.IsInRange(rinput.CastPosition))
                {
                    R.Cast(rinput.CastPosition);
                }
            }
        }
    }
}