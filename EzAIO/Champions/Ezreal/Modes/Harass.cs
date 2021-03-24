using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;
    static class Harass
    {
        internal static void CastQ()
        {
            if (!mainMenu["Harass"].GetValue<MenuSliderButton>("q").Enabled || !Q.IsReady())
            {
                return;
            }

            if (mainMenu["Harass"].GetValue<MenuSliderButton>("q").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }
            
            var priorityTarget = GameObjects.EnemyHeroes.FirstOrDefault(x => Extension.HasEssenceFlux(x, Q.Range));
            if (priorityTarget != null)
            {
                var qinpupt = Q.GetPrediction(priorityTarget);
                if (qinpupt.Hitchance >= HitChance.High)
                {
                    Q.Cast(qinpupt.CastPosition);
                }
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(Q.Range) &&
                                                                     !Q.GetPrediction(x).CollisionObjects.Any()))
            {
                if (target == null)
                {
                    continue;
                }

                var qinput = Q.GetPrediction(target);
                if (qinput.Hitchance >= HitChance.High)
                {
                    Q.Cast(qinput.CastPosition);
                }

            }
        }

        internal static void CastW()
        {
            if (!mainMenu["Harass"].GetValue<MenuSliderButton>("w").Enabled || !W.IsReady())
            {
                return;
            }

            if (!Q.IsReady() &&
                GameObjects.Player.CountEnemyHeroesInRange(GameObjects.Player.GetRealAutoAttackRange()) == 0)
            {
                return;
            }

            if (mainMenu["Harass"].GetValue<MenuSliderButton>("w").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var wtarget = W.GetTarget();
            if (wtarget == null)
            {
                return;
            }

            var winput = W.GetPrediction(wtarget);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.CastPosition);
            }
        }
    }
}