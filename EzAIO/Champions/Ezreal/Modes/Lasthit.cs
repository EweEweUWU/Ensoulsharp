using System.Linq;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static Damage;
    using static ChampionBases;
    
    class Lasthit
    {
        internal static void CastQ()
        {
            if (!mainMenu["Lasthit"].GetValue<MenuSliderButton>("q").Enabled || !Q.IsReady())
            {
                return;
            }

            if (mainMenu["Lasthit"].GetValue<MenuSliderButton>("q").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var qtarget = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(Q.Range)).FirstOrDefault(x =>
                QDamage(x) >= x.Health - GameObjects.Player.CalculateDamage(x, DamageType.Physical, 1));
            if (qtarget == null)
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