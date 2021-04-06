using EnsoulSharp;
using EnsoulSharp.SDK;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Bases.ChampionBases;
namespace EzAIO.Champions.Tristana.Modes
{
    static class Combo
    {
        public static void CastQ(BeforeAttackEventArgs args)
        {
            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return;
            }

            if (ComboMenu.QBool.Enabled)
            {
                Q.Cast();
            }
        }

        public static void CastE(BeforeAttackEventArgs args)
        {
            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return;
            }

            if (ComboMenu.EBool.Enabled)
            {
                E.CastOnUnit(target);
            }
        }

        public static void SemiR()
        {
            if (!ComboMenu.RSemiCastBool.Active)
            {
                return;
            }
            var target = R.GetTarget();
            if (target == null)
            {
                return;
            }

            R.CastOnUnit(target);
        }
    }
}