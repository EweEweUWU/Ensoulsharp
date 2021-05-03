using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;

namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastE(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var target = args.Target as AIMinionClient;
            if ((target.GetJungleType() & JungleType.Large) == 0)
            {
                return;
            }
            E.Cast(target);
        }

        public static void CastQ(BeforeAttackEventArgs args)
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            Q.CastOnUnit(args.Target);
        }

        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            Q.CastOnUnit(args.Target);
        } 
    }
}