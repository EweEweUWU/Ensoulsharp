using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    using static ChampionBases;
    class Jungleclear
    {
        public static void CastQ()
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (Extension.GetNumberAxesActives() >= JungleclearMenu.QAxesSlider.Value)
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
            if (!JungleclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            W.Cast();
        }
    }
}