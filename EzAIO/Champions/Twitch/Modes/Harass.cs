using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Configs;
namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastW()
        {
            if (!HarassMenu.WSliderButton.Enabled || !W.IsReady())
            {
                return;
            }

            if (HarassMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var wtarget = TargetSelector.GetTarget(W.Range);
            if (wtarget == null)
            {
                return;
            }

            var winput = W.GetPrediction(wtarget);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.UnitPosition);
            }
        }

        public static void CastE()
        {
            if (!HarassMenu.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (HarassMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var etarget = TargetSelector.GetTarget(E.Range);
            if (etarget == null || !Extension.HasPoisonEffect(etarget, E.Range))
            {
                return;
            }

            if (HarassMenu.EBool.Enabled)
            {
                if (etarget.DistanceToPlayer() >= GameObjects.Player.GetCurrentAutoAttackRange())
                {
                    E.Cast();
                }
            }
            else
            {
                E.Cast();
            }
            
        }
    }
}