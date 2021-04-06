using EnsoulSharp.SDK;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
using static EzAIO.Bases.ChampionBases;
namespace EzAIO.Champions.Tristana.Modes
{
    static class Jungleclear
    {
        public static void CastE(BeforeAttackEventArgs args)
        {
            if (!JungleClearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (JungleClearMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            E.CastOnUnit(args.Target);
        }

        public static void CastQ()
        {
            if (!JungleClearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (JungleClearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            Q.Cast();
        }
    }
}