using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    using static ChampionBases;
    static class Combo
    {
        public static void CastQ()
        {
            if (!ComboMenu.QBoolSliderButton.Enabled)
            {
                return;
            }

            if (Extension.GetNumberAxesActives() >= ComboMenu.QBoolSliderButton.Value)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW(BeforeAttackEventArgs args)
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            W.Cast();
        }

        public static void CastW()
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            if (!GameObjects.EnemyHeroes.Any(x => x.IsValidTarget(1500f) &&
                                                  x.Distance(Game.CursorPos) <= 250 &&
                                                  x.DistanceToPlayer() > GameObjects.Player.GetRealAutoAttackRange()))
            {
                return;
            }

            W.Cast();
        }

        public static void CastE(AfterAttackEventArgs args)
        {
            if (!ComboMenu.EBool.Enabled)
            {
                return;
            }

            var etarget = args.Target as AIHeroClient;
            if (etarget == null)
            {
                return;
            }

            var einput = E.GetPrediction(etarget);
            if (einput.Hitchance >= HitChance.High)
            {
                DelayAction.Add((int)Extension.eDelay,()=>E.Cast(einput.UnitPosition));
            }
        }

        public static void SemiCastR()
        {
            if (!ComboMenu.RKey.Active)
            {
                return;
            }

            var target = TargetSelector.GetTarget(R.Range,DamageType.Physical);
            var rinput = R.GetPrediction(target);
            if (rinput.Hitchance >= HitChance.High)
            {
                R.Cast(rinput.CastPosition);
            }
        }
    }
}