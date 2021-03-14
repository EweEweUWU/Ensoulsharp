using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
{
    using static ChampionBases;
    static class Structureclear
    {
        public static void CastE(AfterAttackEventArgs args)
        {
            if (!StructureclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (StructureclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var safechek = StructureclearMenu.ERange;
            if (safechek.Enabled && GameObjects.Player.CountEnemyHeroesInRange(safechek.Value) != 0)
            {
                return;
            }

            var etarget = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(E.Range));
            if (etarget == null)
            {
                return;
            }

            if (!GameObjects.Player.InAutoAttackRange(etarget))
            {
                return;
            }
            E.Cast(Game.CursorPos);
        }
    }
}