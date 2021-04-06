using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
using static EzAIO.Champions.Jinx.Damage;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastW()
        {
            if (!KillstealMenu.WSliderButton.Enabled)
            {
                return;
            }
            if (Player.CountEnemyHeroesInRange(Extension.RocketRange) < KillstealMenu.WSliderButton.Value)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(W.Range) &&
                                                                    WDamage(x)>=x.Health-Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    !x.IsInvulnerable))
            {
                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }

        public static void CastR()
        {
            if (!KillstealMenu.RSliderButton.Enabled)
            {
                return;
            }
            if (Player.CountEnemyHeroesInRange(Extension.RocketRange) > KillstealMenu.RSliderButton.Value)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(ComboMenu.RSliderRange.Value) &&
                                                                    RDamage(x)>=x.Health-Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    !x.IsInvulnerable))
            {
                if (W.IsReady() && WDamage(target) >= target.Health)
                {
                    return;
                }

                var rinput = R.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High && R.IsInRange(rinput.CastPosition) && rinput.CollisionObjects.Any(x=>x.IsEnemy))
                {
                    R.Cast(rinput.CastPosition);
                }
            }
        }
    }
}