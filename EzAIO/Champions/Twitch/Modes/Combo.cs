using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Configs;
namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    static class Combo
    {
        public static void CastQ()
        {
            if (ComboMenu.QList.Index != 1 || !Q.IsReady())
            {
                return;
            }

            var target = TargetSelector.GetTarget(600);
            if (target == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastQ(BeforeAttackEventArgs args)
        {
            if (ComboMenu.QList.Index != 0 || !Q.IsReady())
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW()
        {
            if (!ComboMenu.WList.Enabled || !W.IsReady())
            {
                return;
            }

            var wtaregt = TargetSelector.GetTarget(W.Range);
            if (wtaregt == null)
            {
                return;
            }

            if (ComboMenu.WBool.Enabled && GameObjects.Player.IsUnderEnemyTurret())
            {
                return;
            }

            if (ComboMenu.WRBool.Enabled && Extension.HasFullEffect(GameObjects.Player))
            {
                return;
            }

            var winput = W.GetPrediction(wtaregt);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.UnitPosition);
            }
        }

        public static void CastR()
        {
            if (!ComboMenu.RSliderButton.Enabled && !R.IsReady())
            {
                return;
            }

            if (GameObjects.Player.CountEnemyHeroesInRange(R.Range) >= ComboMenu.RSliderButton.Value)
            {
                R.Cast();
            }
        }
    }
}