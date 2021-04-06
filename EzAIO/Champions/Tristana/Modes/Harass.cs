using EnsoulSharp;
using EnsoulSharp.SDK;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
using static EzAIO.Bases.ChampionBases;
namespace EzAIO.Champions.Tristana.Modes
{
    static class Harass
    {
        public static void CastQ(BeforeAttackEventArgs args)
        {
            if (!HarassMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastE(BeforeAttackEventArgs args)
        {
            if (!HarassMenu.ESliderButton.Enabled)
            {
                return;  
            }

            if (HarassMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;   
            }

            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return;
            }

            E.CastOnUnit(target);
        }
    }
}