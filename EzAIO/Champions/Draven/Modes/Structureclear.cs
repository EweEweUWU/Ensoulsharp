using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    using static ChampionBases;
    static class Structureclear
    {
        public static void CastW()
        {
            if (!StructureclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (StructureclearMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.Player.CountEnemyHeroesInRange(StructureclearMenu.WRangeSliderButton.Value) != 0)
            {
                return;
            }

            var turret = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(E.Range));
            if (turret == null)
            {
                return;
            }
            W.Cast();
        }
    }
}