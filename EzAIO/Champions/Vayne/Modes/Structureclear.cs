using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Structureclear
    {
        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!StructureclearMenu.QSliderButton.Enabled)
            {
                
                return;
            }

            if (StructureclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var safecheck = StructureclearMenu.NoEnemiesSliderButton;
            if (safecheck.Enabled && GameObjects.Player.CountEnemyHeroesInRange(safecheck.Value) != 0)
            {
                return;
            }

            var qtarget = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            if (qtarget == null)
            {
                return;
            }

            if (!GameObjects.Player.InAutoAttackRange(qtarget))
            {
                return;
            }

            Q.Cast(Game.CursorPos);
        }
    }
}