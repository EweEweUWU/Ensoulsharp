using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Extension;
namespace EzAIO.Champions.Ashe.Modes
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

            var qtarget = Q.GetTarget();
            if (qtarget == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW()
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            if (ComboMenu.DontWBool.Enabled && IsQActive())
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(W.Range)))
            {
                if (target == null)
                {
                    return;
                }

                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }

        public static void SemiRCast()
        {
            if (!ComboMenu.RSemiKeyBind.Active)
            {
                return;
            }

            var rtarget = TargetSelector.GetTarget(AutomaticMenu.RrangeSlider.Value,DamageType.Mixed);
            if (rtarget == null)
            {
                return;
            }

            var rinput = R.GetPrediction(rtarget);
            if (rinput.Hitchance >= HitChance.High && R.IsInRange(rinput.CastPosition))
            {
                R.Cast(rinput.CastPosition);
            }
        }
    }
}