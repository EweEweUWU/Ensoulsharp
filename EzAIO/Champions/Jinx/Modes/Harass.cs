using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastQ()
        {
            if (!HarassMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value > Player.ManaPercent)
            {
                if (Extension.ActivatedRockets)
                {
                    Q.Cast();
                }
                return;
            }

            var target = TargetSelector.GetTarget(Extension.RocketRange,DamageType.Physical);
            if (target == null)
            {
                return;
            }

            if (Extension.Swap(target))
            {
                Q.Cast();
            }
        }

        public static void CastW()
        {
            if (!HarassMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.WSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            if (HarassMenu.EnemiesBool.Enabled && Player.CountEnemyHeroesInRange(Extension.RocketRange) > 0)
            {
                return;
            }

            var target = W.GetTarget();
            if (target == null)
            {
                return;
            }

            var winput = W.GetPrediction(target);
            if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
            {
                W.Cast(winput.CastPosition);
            }
        } 
    }
}