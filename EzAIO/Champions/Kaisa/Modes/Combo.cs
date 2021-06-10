using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
{
    using static ChampionBases;
    static class Combo
    {
        public static void CastQ()
        {
            if (!ComboMenu.QBool.Enabled)
            {
                return;
            }

            var qtarget = TargetSelector.GetTarget(Q.Range,DamageType.Physical);
            if (qtarget == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW()
        {
            if (!ComboMenu.WSliderButton.Enabled || ComboMenu.WSliderButton.Value == 2)
            {
                return;
            }

            var wtarget = TargetSelector.GetTarget(W.Range,DamageType.Mixed);
            if (wtarget == null)
            {
                return;
            }

            if (ComboMenu.WRange.Enabled && wtarget.DistanceToPlayer() <= ComboMenu.WRange.Value)
            {
                return;
            }

            var winput = W.GetPrediction(wtarget);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.CastPosition);
            }
        }

        public static void CastE()
        {
            if (!ComboMenu.EBool.Enabled)
            {
                return;
            }

            if (MiscellaneousMenu.EBool.Enabled && !Extension.EUpgraded())
            {
                return;
            }

            var target = TargetSelector.GetTarget(Q.Range,DamageType.Physical);
            if (target == null)
            {
                return;
            }

            E.Cast();
        }
    }
}