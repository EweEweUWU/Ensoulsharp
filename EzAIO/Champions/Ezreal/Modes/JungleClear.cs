using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;

    class JungleClear
    {
        internal static void CastQ()
        {
            if (!mainMenu["Jungleclear"].GetValue<MenuSliderButton>("q").Enabled || !Q.IsReady())
            {
                return;
            }
            if (mainMenu["Jungleclear"].GetValue<MenuSliderButton>("q").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var qtarget = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            if (qtarget== null)
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qinput.CastPosition);
            }
        }

        internal static void CastW()
        {
            if (!mainMenu["Jungleclear"].GetValue<MenuSliderButton>("w").Enabled || !W.IsReady())
            {
                return;
            }
            if (mainMenu["Jungleclear"].GetValue<MenuSliderButton>("w").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var wtarget = GameObjects.JungleLegendary.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (wtarget == null)
            {
                return;
            }
            if(wtarget.Name.Contains("drake") ||
               wtarget.Name.Contains("baron") ||
               wtarget.Name.Contains("herald"))
            {
                return;
            }
            W.Cast(wtarget.Position);
        }
    }
}