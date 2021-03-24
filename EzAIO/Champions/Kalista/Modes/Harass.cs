using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista.Modes
{
    using static Configs;
    using static ChampionBases;
    using static Damage;
    static class Harass
    {
        public static void CastQ()
        {
            if (!HarassMenu.QSliderButton.Enabled || !Q.IsReady())
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.Player.IsDashing())
            {
                return;
            }

            var qtarget = TargetSelector.GetTarget(Q.Range);
            if (qtarget == null)
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qinput.CastPosition);
            }
        }

        public static void CastE()
        {
            if (!HarassMenu.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (HarassMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }
            foreach (var enemy in GameObjects.EnemyHeroes.Where(x =>
                x.IsValidTarget(E.Range) && Extension.HasRendBuff(x, E.Range)))
            {
                if (enemy == null)
                {
                    return;
                }

                foreach (var minion in GameObjects.EnemyMinions.Where(z =>
                    z.IsValidTarget(E.Range) && Extension.HasRendBuff(z, E.Range)))
                {
                    if (minion == null)
                    {
                        return;
                    }

                    if (!GameObjects.Player.InAutoAttackRange(enemy) && EDamage(minion) >=
                        minion.Health - GameObjects.Player.CalculateDamage(minion, DamageType.Physical, 1))
                    {
                        E.Cast();
                    }
                }
            }
        }
    }
}