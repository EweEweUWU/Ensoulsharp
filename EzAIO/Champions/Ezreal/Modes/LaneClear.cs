using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;
    using static Damage;
    
    class LaneClear
    {
        internal static void CastQ()
        {
            if (!mainMenu["LaneClear"].GetValue<MenuSliderButton>("q").Enabled || !Q.IsReady())
            {
                return;
            }
            if (mainMenu["LaneClear"].GetValue<MenuSliderButton>("q").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var qtarget = GameObjects.EnemyMinions.Where(x=>x.IsValidTarget(Q.Range)).
                    OrderBy(x=>x.Health).FirstOrDefault();
            if (qtarget == null)
            {
                return;
            }

            if (mainMenu["LaneClear"].GetValue<MenuBool>("killable").Enabled &&
                QDamage(qtarget) >=
                qtarget.Health - GameObjects.Player.CalculateDamage(qtarget, DamageType.Physical, 1))
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qinput.UnitPosition);
            }
        }
        
    }
}