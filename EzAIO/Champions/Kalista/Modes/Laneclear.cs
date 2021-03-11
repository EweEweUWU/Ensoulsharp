using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista.Modes
{
    using static ChampionBases;
    using static Damage;
    static class Laneclear
    {
        public static void CastE()
        {
            if(!Configs.Laneclear.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (Configs.Laneclear.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            int cont = 0;
            foreach (var minions in GameObjects.EnemyMinions.Where(x => x.IsValidTarget(E.Range) &&
                                                                        Extension.HasRendBuff(x, E.Range)))
            {
                if (EDamage(minions) >=
                    minions.Health - GameObjects.Player.CalculateDamage(minions, DamageType.Physical, 1))
                {
                    cont++;
                }

                if (cont > 0)
                {
                    if (cont >= Configs.Laneclear.Eminion.Value)
                    {
                        E.Cast();
                    }
                }

                if (Configs.Laneclear.EBool.Enabled && minions.Health <= 40)
                {
                    E.Cast();
                }
            }
        }
    }
}