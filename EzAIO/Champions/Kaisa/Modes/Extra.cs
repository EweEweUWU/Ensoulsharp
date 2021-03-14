using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
{
    using static ChampionBases;
    static class Extra
    {
        public static void CastW(AfterAttackEventArgs args)
        {
            if (!ComboMenu.WSliderButton.Enabled || ComboMenu.WSliderButton.Value == 2)
            {
                return;
            }

            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return;
            }

            if (ComboMenu.WRange.Enabled && target.DistanceToPlayer() <= ComboMenu.WRange.Value)
            {
                return;
            }

            if (ComboMenu.WSliderButton.Value == 1 &&
                target.GetBuffCount("kaisapassivemarker") < ComboMenu.WSliderButton.Value - 1)
            {
                return;
            }

            var winput = W.GetPrediction(target);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.UnitPosition);
            }
        }
    }
}