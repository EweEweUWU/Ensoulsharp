using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;

namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }
            Q.Cast(Game.CursorPos);
        }

        public static void CastE(AfterAttackEventArgs args)
        {
            var target = args.Target as AIMinionClient;

            if (!JungleclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (Extension.IsMinionCondemnable(target))
            {
                E.CastOnUnit(target);
            }
        }
        
    }
}