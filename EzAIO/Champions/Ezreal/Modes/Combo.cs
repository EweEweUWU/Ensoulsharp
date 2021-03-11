using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;
    static class Combo
    {
        
        internal static void CastQ()
        {
            if(!mainMenu["Combo"].GetValue<MenuBool>("q").Enabled || !Q.IsReady())
            {
                return;
            }
            var qtarget = TargetSelector.GetTarget(1200f);
            if (qtarget == null)
            {
                return;
            }

            if (qtarget.DistanceToPlayer() < GameObjects.Player.GetRealAutoAttackRange(qtarget))
            {
                return;
            }
            var priorityTarget = GameObjects.EnemyHeroes.FirstOrDefault(x => Extension.HasEssenceFlux(x, Q.Range));
            if (priorityTarget != null)
            {
                var qinpupt = Q.GetPrediction(priorityTarget);
                if (qinpupt.Hitchance >= HitChance.High)
                {
                    Q.Cast(qinpupt.UnitPosition);
                }
            }
            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qinput.UnitPosition);
            }
        }

        internal static void CastW()
        {
            if (!mainMenu["Combo"].GetValue<MenuBool>("w").Enabled || !W.IsReady())
            {
                return;
            }

            var wtarget = TargetSelector.GetTarget(W.Range);
            if (wtarget == null)
            {
                return;
            }

            if (wtarget.DistanceToPlayer() < GameObjects.Player.GetRealAutoAttackRange(wtarget))
            {
                return;
            }

            var winput = W.GetPrediction(wtarget);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.UnitPosition);
            }

        }

        internal static void SemiR()
        {
            if (!mainMenu["Combo"].GetValue<MenuKeyBind>("rsemiautomatic").Active || !R.IsReady())
            {
                return;
            }
            var rtarget = TargetSelector.GetTarget(R.Range);
            var rinput = R.GetPrediction(rtarget);
            if(rinput.Hitchance>=HitChance.High)
            {
                R.Cast(rinput.UnitPosition);
            }
        }
    }
}