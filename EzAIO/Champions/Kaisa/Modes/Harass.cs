using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
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

            if (HarassMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.EnemyHeroes.Any(x => x.IsValidTarget(Q.Range)))
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

            if (HarassMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var enemies = TargetSelector.GetTargets(W.Range,DamageType.Mixed).ToList();
            foreach (var target in enemies.Where(x=>x.IsValidTarget(W.Range)))
            {
                if (target == null)
                {
                    return;
                }

                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High)
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }
    }
}