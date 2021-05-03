using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Ashe;
using static EzAIO.Champions.Ashe.Damage;
namespace EzAIO.Champions.Ashe.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastW()
        {
            if (!KillstealMenu.WBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(W.Range) &&
                                                                    WDamage(x)>=x.Health-Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    !x.IsInvulnerable))
            {
                if (target.DistanceToPlayer() <= Player.GetRealAutoAttackRange())
                {
                    return;
                }
                var winpput = W.GetPrediction(target);
                if (winpput.Hitchance >= HitChance.High && W.IsInRange(winpput.CastPosition))
                {
                    W.Cast(winpput.CastPosition);
                }
            }
        }

        public static void CastR()
        {
            if (!KillstealMenu.RBool.Enabled)
            {
                return;
            }
            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(AutomaticMenu.RrangeSlider.Value) &&
                                                                    RDamage(x)>=x.Health &&
                                                                    !x.IsInvulnerable))
            {
                if (KillstealMenu.WBool.Enabled && WDamage(target) >= target.Health && target.InAutoAttackRange() && W.IsReady())
                {
                    return;
                }
                if (target.DistanceToPlayer() <= Player.GetRealAutoAttackRange())
                {
                    return;
                }
                var rinput = W.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High && W.IsInRange(rinput.CastPosition))
                {
                    R.Cast(rinput.CastPosition);
                }
            }
        }
    }
}