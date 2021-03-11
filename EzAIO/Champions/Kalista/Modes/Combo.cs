using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista.Modes
{
    using static Configs;
    using static ChampionBases;
    static class Combo
    {
        public static void CastQ()
        {
            if (!ComboMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            if (GameObjects.Player.IsDashing())
            {
                return;
            }
            var qtarget = TargetSelector.GetTarget(Q.Range);
            if (qtarget == null)
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qtarget);
            }
        }

    }
}