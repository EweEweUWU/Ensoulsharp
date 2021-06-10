using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
namespace EzAIO.Champions.Jinx.Modes
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

            var target = TargetSelector.GetTarget(Extension.RocketRange,DamageType.Physical);
            if (target == null)
            {
                return;
            }

            if (Extension.Swap(target))
            {
                Q.Cast();
            }
        }

        public static void CastW()
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            if (ComboMenu.PBool.Enabled && Extension.ActivatedPassive)
            {
                return;
            }

            if (ComboMenu.EnemiesBool.Enabled && Player.CountEnemyHeroesInRange(Extension.RocketRange) > 0)
            {
                return;
            }

            var target = W.GetTarget();
            if (target == null)
            {
                return;
            }

            var winput = W.GetPrediction(target);
            if (winput.Hitchance >= HitChance.High && Q.IsInRange(winput.CastPosition))
            {
                W.Cast(winput.CastPosition);
            }
        }

        public static void CastE()
        {
            if (!ComboMenu.EKey.Enabled)
            {
                return;
            }

            var target = E.GetTarget();
            if (target == null)
            {
                return;
            }

            var einput = E.GetPrediction(target);
            if (einput.Hitchance >= HitChance.High && E.IsInRange(einput.CastPosition))
            {
                E.Cast(einput.CastPosition);
            }
        }

        public static void SemiCastR()
        {
            if (!ComboMenu.Rkey.Active)
            {
                return;
            }

            if (ComboMenu.RSafeBool.Enabled && Player.CountEnemyHeroesInRange(Extension.RocketRange) > 0)
            {
                return;
            }

            var target = R.GetTarget();
            if (target == null)
            {
                return;
            }

            var rinput = R.GetPrediction(target);
            if (rinput.Hitchance >= HitChance.High && R.IsInRange(rinput.CastPosition))
            {
                R.Cast(rinput.CastPosition);
            }
        }
    }
}