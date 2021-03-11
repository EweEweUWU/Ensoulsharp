using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Lucian;
using static EzAIO.Champions.Lucian.Damage;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void Cast()
        {
            if (KillstealMenu.QnormalBool.Enabled)
            {
                CastQ();
                return;
            }

            if (KillstealMenu.QextendedBool.Enabled)
            {
                CastExtendedQ();
                return;
            }

            if (KillstealMenu.WBool.Enabled)
            {
                CastW();
                return;
            }
        }

        private static void CastQ()
        {
            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(Q.Range) &&
                                                                      QDamage(x) >= x.Health -
                                                                      GameObjects.Player.CalculateDamage(x,
                                                                          DamageType.Physical, 1) &&
                                                                      !x.IsInvulnerable))
            {
                Q.CastOnUnit(target);
                return;
            }
        }

        private static void CastExtendedQ()
        {
            var usableunits = GameObjects.EnemyHeroes.Concat<AIBaseClient>(GameObjects.EnemyMinions).ToList();
            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(ExtendedQ.Range) &&
                                                                    QDamage(x)>=x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    !x.IsInvulnerable))
            {
                var qpred = Q.GetPrediction(target);
                foreach (var minion in usableunits.Where(u=>u.IsValidTarget(Q.Range)))
                {
                    if (!Extension.QRectangle(minion).IsInside(qpred.UnitPosition.ToVector2()))
                    {
                        return;
                    }

                    Q.CastOnUnit(minion);
                    break;
                }
            }
        }

        private static void CastW()
        {
            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(W.Range) &&
                                                                    WDamage(x)>=x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Magical,1) &&
                                                                    !x.IsInvulnerable))
            {
                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High)
                {
                    W.Cast(winput.UnitPosition);
                    return;
                }
            }
        }
        
    }
}