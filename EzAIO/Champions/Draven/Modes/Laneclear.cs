using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (Extension.GetNumberAxesActives() >= LaneclearMenu.QAxesSlider.Value)
            {
                return;
            }

            if (LaneclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW()
        {
            if (!LaneclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.EnemyMinions.Count(x => x.IsValidTarget(E.Range)) < LaneclearMenu.WCountSlider.Value)
            {
                return;
            }

            W.Cast();
        }

        public static void CastE()
        {
            if (!LaneclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(E.Range));
            var farmLine = E.GetCircularFarmLocation(minions, E.Width);
            if (farmLine.MinionsHit < LaneclearMenu.ECountSlider.Value)
            {
                return;
            }

            E.Cast(farmLine.Position);
        }
    }
}