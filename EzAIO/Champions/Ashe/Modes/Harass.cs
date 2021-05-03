using System.Linq;
using System.Threading;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Ashe;
namespace EzAIO.Champions.Ashe.Modes
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

            if (HarassMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var qtarget = Q.GetTarget();
            if (qtarget == null)
            {
                return;
            }

            Q.Cast();
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

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(W.Range)))
            {
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
}