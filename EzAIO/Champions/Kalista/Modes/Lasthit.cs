using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kalista.Configs;
namespace EzAIO.Champions.Kalista.Modes
{
    using static ChampionBases;
    using static Damage;
    static class Lasthit
    {
        public static void CastE()
        {
            if (!Configs.Lasthit.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (Configs.Lasthit.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.EnemyMinions.Any(x => x.IsValidTarget(E.Range) &&
                                                  Extension.HasRendBuff(x, E.Range) &&
                                                  EDamage(x) >= x.Health -
                                                  GameObjects.Player.CalculateDamage(x, DamageType.Physical, 1)))
            {
                E.Cast();
            }
        }
    }
}