using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
using static EzAIO.Champions.Katarina.Damage;
namespace EzAIO.Champions.Katarina.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            var minion = GameObjects.EnemyMinions.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            if (minion == null)
            {
                return;
            }

            Q.CastOnUnit(minion);
        }

        public static void CastW()
        {
            if (!LaneclearMenu.WSliderButton.Enabled || !W.IsReady())
            {
                return;
            }

            if (LaneclearMenu.WSliderButton.Value > GameObjects.GetMinions(300).Count())
            {
                return;
            }

            if (W.Cast())
            {
                Extension.eDelay = Game.Time + 1.2f;
            }
        }

        public static void CastQLast()
        {
            if (!LasthitMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            var target = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(Q.Range) &&
                                                             QDamage(x) >= x.Health -
                                                             GameObjects.Player.CalculateDamage(x, DamageType.Magical,
                                                                 1)).OrderByDescending(x => x.MagicalShield)
                .FirstOrDefault();
            if (target == null)
            {
                return;
            }

            Q.CastOnUnit(target);
        }

        public static void CastE()
        {
            if (Extension.eDelay > Game.Time)
            {
                return;
            }

            if (!LaneclearMenu.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            var dagger = Extension.Daggers.Where(x =>
                    (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(450,false,x.Position)) > LaneclearMenu.ESliderButton.Value) &&
                    x.DistanceToPlayer() <= E.Range + 50)
                .OrderByDescending(x => (GameObjects.EnemyMinions.Count(t => t.IsValidTarget(450)))).FirstOrDefault();
            if (dagger == null)
            {
                return;
            }

            if (LaneclearMenu.ETurretBool.Enabled && (GameObjects.Player.Position.IsUnderEnemyTurret() || dagger.Position.IsUnderEnemyTurret()))
            {
                return;
            }

            E.Cast(dagger.Position);
        }
    }
}