using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Structureclear
    {
        public static void CastW(AfterAttackEventArgs args)
        {
            if (!StructureclearMenu.WSlider.Enabled)
            {
                return;
            }

            if (StructureclearMenu.WSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var wtarget = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (wtarget == null)
            {
                return;
            }

            W.Cast(Game.CursorPos);
        }

        public static void CastE(AfterAttackEventArgs args)
        {
            if (!StructureclearMenu.ESlider.Enabled)
            {
                return;
            }

            if (StructureclearMenu.ESlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var etraget = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(E.Range));
            if (etraget == null)
            {
                return;
            }

            E.Cast(GameObjects.Player.Position.Extend(Game.CursorPos, GameObjects.Player.BoundingRadius));
        }
    }
}