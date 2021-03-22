using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
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

            if (Extension.GetNumberAxesActives() >= HarassMenu.QAxesSlider.Value)
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW()
        {
            if (!HarassMenu.EsSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.EsSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            W.Cast();
        }
    }
}