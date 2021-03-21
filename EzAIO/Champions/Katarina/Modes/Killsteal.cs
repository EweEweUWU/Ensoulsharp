using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
using static EzAIO.Champions.Katarina.Damage;
namespace EzAIO.Champions.Katarina.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastQ()
        {
            if (!KillstealMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(Q.Range) &&
                                                                      QDamage(x) >= x.Health -
                                                                      GameObjects.Player.CalculateDamage(x,
                                                                          DamageType.Magical, 1) &&
                                                                      !x.IsInvulnerable))
            {
                if (KillstealMenu.RCancelBool.Enabled && Extension.CastingR)
                {
                    Extension.CastingR = false;
                }

                Q.CastOnUnit(target);
                break;
            }
        }

        public static void CastEGap()
        {
            if (!Q.IsReady() || !E.IsReady() ||
                !KillstealMenu.QBool.Enabled || !KillstealMenu.EGapBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(Q.Range+E.Range*.9f) &&
                                                                    x.DistanceToPlayer()>Q.Range &&
                                                                    QDamage(x)>=x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Magical,1) &&
                                                                    !x.IsInvulnerable))
            {
                var bObject = GameObjects.AttackableUnits.Where(x => x.IsTargetable &&
                                                                     x.DistanceToPlayer() <= E.Range &&
                                                                     x.Distance(target) <= E.Range &&
                                                                     x.Position.IsUnderEnemyTurret() == false)
                    .OrderBy(x => x.Distance(target)).FirstOrDefault();
                if (bObject == null)
                {
                    return;
                }

                E.Cast(bObject.Position);
                break;
            }
        }

        public static void CastE()
        {
            if (!KillstealMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(E.Range+200)))
            {
                var dagger = Extension.Daggers.FirstOrDefault(x =>
                    x.Distance(target) < 450 && x.DistanceToPlayer() <= E.Range + 200);
                if (dagger != null)
                {
                    if (!(Passive(target) >=
                          target.Health - GameObjects.Player.CalculateDamage(target, DamageType.Magical, 1)) ||
                        !target.IsInvulnerable)
                    {
                        continue;
                    }

                    if (KillstealMenu.RCancelBool.Enabled && Extension.CastingR)
                    {
                        Extension.CastingR = false;
                    }
                    
                    E.Cast(dagger.Position.Extend(target.Position, 200));
                    break;
                }
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(E.Range)))
            {
                if (!(EDamage(target) >=
                      target.Health - GameObjects.Player.CalculateDamage(target, DamageType.Magical, 1)) ||
                    !target.IsInvulnerable ||
                    target.DistanceToPlayer() > E.Range)
                {
                    continue;
                }

                if (KillstealMenu.RCancelBool.Enabled || Extension.CastingR)
                {
                    Extension.CastingR = false;
                }
                E.Cast(target.Position.Extend(GameObjects.Player.Position, -50));
                break;
            }
        }
    }
}