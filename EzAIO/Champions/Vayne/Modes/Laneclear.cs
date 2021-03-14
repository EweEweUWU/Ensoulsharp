using System.Linq;
using static EzAIO.Champions.Vayne.Damage;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!LaneclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var posAfterQ = GameObjects.Player.Position.Extend(Game.CursorPos, 300f);
            foreach (var target in GameObjects.EnemyMinions.Where(x=>x.IsValidTarget(Q.Range) &&
                                                                     x.Distance(posAfterQ) < GameObjects.Player.GetRealAutoAttackRange() &&
                                                                     x != Orbwalker.GetTarget() &&
                                                                     x.Health<=GameObjects.Player.GetAutoAttackDamage(x) + QDamage(x)))
            {
                Q.Cast(Game.CursorPos);
            }
        }
    }
}