using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastQ()
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }
            if (JungleclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                if (Extension.ActivatedRockets)
                {
                    Q.Cast();
                }
                return;
            }

            var mob = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Extension.RocketRange) );
            if (mob == null)
            {
                return;
            }

            if (Extension.Swap(mob))
            {
                Q.Cast();
            }
        }

        public static void CastW()
        {
            if (!JungleclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.WSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var mob = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(W.Range) && (x.GetJungleType() & JungleType.Legendary) != 0);
            if (mob == null)
            {
                return;
            }

            var winput = W.GetPrediction(mob);
            if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
            {
                W.Cast(winput.CastPosition);
            }
        }
    }
}