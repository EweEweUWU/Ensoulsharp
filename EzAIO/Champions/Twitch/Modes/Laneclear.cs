using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Damage;
using static EzAIO.Champions.Twitch.Configs;

namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    class Laneclear
    {
        public static void CastE()
        {
            if (!LaneclearMenu.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (LaneclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            int cont = 0;
            foreach (var minion in GameObjects.EnemyMinions.Where(x=>x.IsValidTarget(E.Range) &&
                                                                     Extension.HasPoisonEffect(x,E.Range)))
            {
                if (minion == null)
                {
                    return;
                }

                if (EDamage(minion) >= minion.Health - GameObjects.Player.CalculateDamage(minion, DamageType.Mixed, 1))
                {
                    cont++;
                }

                if (cont != 0 && cont == LaneclearMenu.ESlider.Value)
                {
                    E.Cast();
                }
            }
        }
    }
}