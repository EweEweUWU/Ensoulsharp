using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
using static EzAIO.Champions.Jinx.Damage;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Lasthit
    {
        public static void CastQ()
        {
            if (!LasthitMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LasthitMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var minion = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(Extension.RocketRange))
                .OrderBy(x => x.MaxHealth).FirstOrDefault(x =>
                    Extension.RocketDamage(x) >= x.Health - Player.CalculateDamage(x, DamageType.Physical, 1));
            if (minion == null || !minion.IsValid)
            {
                return;
            }

            if (Extension.Swap(minion))
            {
                Q.Cast();
            }
        }
    }
}