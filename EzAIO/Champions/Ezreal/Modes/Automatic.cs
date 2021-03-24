using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;
    class Automatic
    {
        internal static void CastQ()
        {
            if (!mainMenu["Automatic"].GetValue<MenuSliderButton>("q").Enabled || !Q.IsReady())
            {
                return;
            }
            if (mainMenu["Automatic"].GetValue<MenuSliderButton>("q").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var qtarget = Q.GetTarget();
            if (qtarget == null)
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High && Q.IsInRange(qinput.CastPosition))
            {
                Q.Cast(qinput.CastPosition);
            }
        }

        internal static void OnImmobile()
        {
            if (!mainMenu["Automatic"].GetValue<MenuBool>("immobile").Enabled)
            {
                return;
            }

            var target = GameObjects.EnemyHeroes.FirstOrDefault(x =>
                x.IsValidTarget(mainMenu["Automatic"].GetValue<MenuSlider>("rRange").Value) &&
                x.IsStunned);
            if (target == null)
            {
                return;
            }
            R.Cast(target.Position);
        }
    }
}