using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista.Modes
{
    using static Configs; 
    using static Damage;
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastQ()
        {
            if (!KillstealMenu.QSBool.Enabled || !Q.IsReady())
            {
                return;
            }
            if (GameObjects.Player.IsDashing())
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x =>
                x.IsValidTarget(Q.Range) &&
                QDamage(x) >= x.Health - GameObjects.Player.CalculateDamage(x, DamageType.Physical, 1) &&
                !x.IsInvulnerable))
            {
                var qinput = Q.GetPrediction(target);
                if (qinput.Hitchance >= HitChance.High)
                {
                    Q.Cast(qinput.UnitPosition);
                }
            }
        }

        public static void CastE()
        {
            if (!KillstealMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }

            if (GameObjects.EnemyHeroes.Any(x =>
                Extension.HasRendBuff(x, E.Range) &&
                EDamage(x) >= x.Health - GameObjects.Player.CalculateDamage(x, DamageType.Physical, 1)))
            {
                E.Cast();
            }
        }
        
    }
}