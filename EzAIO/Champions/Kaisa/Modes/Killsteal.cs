using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Damage;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void Cast()
        {
            if (W.IsReady() && KillstealMenu.WBool.Enabled)
            {
                CastW();
            }
        }

        private static void CastW()
        {
            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(W.Range) &&
                                                                      WDamage(x) >= x.Health -
                                                                      GameObjects.Player.CalculateDamage(x, DamageType.Magical,
                                                                          1)))
            {
                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High)
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }
    }
}