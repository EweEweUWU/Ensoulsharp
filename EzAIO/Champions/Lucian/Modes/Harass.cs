using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Lucian;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastExtendedQ()
        {
            
            if (!HarassMenu.QextendSlider.Enabled)
            {
                return;
            }

            if (HarassMenu.QextendSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var usableunits = GameObjects.EnemyHeroes.Concat<AIBaseClient>(GameObjects.EnemyMinions);
            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(ExtendedQ.Range)))
            {
                if (target == null)
                {
                    return;
                }
                var qpred = ExtendedQ.GetPrediction(target);
                foreach (var minion in usableunits.Where(u=>u.IsValidTarget(Q.Range)))
                {
                    if (minion == null)
                    {
                        return;
                    }
                    if (!Extension.QRectangle(minion).IsInside(qpred.UnitPosition.ToVector2()))
                    {
                        continue;
                    }

                    Q.CastOnUnit(minion);
                    break;
                }
            }
        }

        public static void CastQ()
        {
            if (!HarassMenu.QnormalSlider.Enabled)
            {
                return;
            }

            if (HarassMenu.QnormalSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            foreach (var target in TargetSelector.GetTargets(Q.Range,DamageType.Physical).ToList())
            {
                if (target == null)
                {
                    return;
                }
                
                Q.CastOnUnit(target);
                break;
            }
        }

        public static void CastW()
        {
            if (!HarassMenu.WSlider.Enabled)
            {
                return;
            }

            if (HarassMenu.WSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            foreach (var target in TargetSelector.GetTargets(W.Range,DamageType.Magical).ToList())
            {
                if (target == null)
                {
                    return;
                }

                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High)
                {
                    W.Cast(winput.UnitPosition);
                    break;
                }
            }
        }
    }
}