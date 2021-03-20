using static EzAIO.Champions.Vayne.Damage;
using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;
using static EzAIO.Champions.Vayne.Configs;
using EzAIO.Bases;
using EzAIO.Extras;

namespace EzAIO.Champions.Vayne
{
    using static ChampionBases;
    public static class Extension
    {
        public static bool Attacked = false;
        private static AIBaseClient LastTarget = null;
        public static float AttackedTimer = 0;
        
        public static bool KillableWithE(this AIBaseClient unit)
        {
            return unit.IsValidTarget(E.Range) &&
                   !unit.IsInvulnerable &&
                   EDamage(unit) >= unit.Health - GameObjects.Player.CalculateDamage(unit, DamageType.Physical, 1) +
                   (unit.GetBuffCount("vaynesilvereddebuff") == 1 ? WDamage(unit) : 0) +
                   (KillstealMenu.EAA.Enabled && Attacked && LastTarget == unit
                       ? GameObjects.Player.GetRealAutoAttackRange(unit)
                       : 0);
        }
        public static Vector2[] CircleCircleIntersection(
            this Vector2 center1,
            Vector2 center2,
            float radius1,
            float radius2)
        {
            var d = center1.Distance(center2);
            if (d > radius1 + radius2 || d <= Math.Abs(radius1 - radius2))
            {
                return new Vector2[]
                {
                };
            }

            var a = (radius1 * radius1 - radius2 * radius2 + d * d) / (2 * d);
            var h = (float) Math.Sqrt(radius1 * radius1 - a * a);
            var direction = Vector2Extensions.Normalized((center2 - center1));
            var pa = center1 + a * direction;
            var s1 = pa + h * direction.Perpendicular();
            var s2 = pa - h * direction.Perpendicular();
            return new[]
            {
                s1,
                s2
            };
        }

        public static bool HasUltBuff()
        {
            return GameObjects.Player.HasBuff("vaynetumblefade");
        }

        public static bool ShouldCastQ(AIHeroClient heroTarget)
        {
            if (GameObjects.Player.Distance(Game.CursorPos) <= GameObjects.Player.GetRealAutoAttackRange() &&
                MiscellaneousMenu.QIfMouseOutAABool.Enabled)
            {
                return false;
            }

            var posAfterQ   = GameObjects.Player.Position.Extend(Game.CursorPos, 300f);
            var qRangecheck = MiscellaneousMenu.QrangeCheckBool;
            if (qRangecheck.Enabled &&
                posAfterQ.CountEnemyHeroesInRange(GameObjects.Player.GetRealAutoAttackRange()) >= qRangecheck.Value)
            {
                return false;
            }

            if (posAfterQ.Distance(heroTarget) > GameObjects.Player.GetRealAutoAttackRange(heroTarget) &&
                MiscellaneousMenu.NoQAAEnemiesBool.Enabled)
            {
                return false;
            }

            if (posAfterQ.IsUnderEnemyTurret() &&
                MiscellaneousMenu.QTurretBool.Enabled)
            {
                return false;
            }

            if (heroTarget.GetBuffCount("vaynesilvereddebuff") != 1 &&
                MiscellaneousMenu.Q3stackBool.Enabled)
            {
                return false;
            }

            return true; 
        }

        public static bool Has2WStacks(this AIBaseClient unit)
        {
            return unit.GetBuffCount("vaynesilvereddebuff") == 2;
        }

        //Prada Port 
        private static bool IsCollisionable(Vector3 pos)
        {
            return NavMesh.GetCollisionFlags(pos).HasFlag(CollisionFlags.Wall) ||
                (NavMesh.GetCollisionFlags(pos).HasFlag(CollisionFlags.Building));
        }

        public static bool IsCondemnable(AIHeroClient target)
        {
            if (!target.IsValidTarget(550f) || target.HasBuffOfType(BuffType.SpellShield) ||
                target.HasBuffOfType(BuffType.Invulnerability) || target.IsDashing())
            {
                return false;
            }

            var pP = ObjectManager.Player.Position;
            var p = target.Position;
            var pD = 475f;
            if (IsCollisionable(p.Extend(pP, -pD)) || IsCollisionable(p.Extend(pP, -pD / 2f)) ||
                IsCollisionable(p.Extend(pP, -pD / 3f)))
            {
                if (!target.CanMove || (target.IsWindingUp))
                {
                    return true;
                }

                var angle = .2;
                const float travelDistance = .5f;
                var alpha = new Vector2((float) (p.X + travelDistance * Math.Cos(Math.PI / 180 * angle)),
                    (float) (p.X + travelDistance * Math.Sin(Math.PI / 180 * angle)));
                var beta = new Vector2((float) (p.X - travelDistance * Math.Cos(Math.PI / 180 * angle)),
                    (float) (p.X - travelDistance * Math.Sin(Math.PI / 180 * angle)));
                for (var i = 15; i < pD; i += 100)
                {
                    if (i > pD)
                    {
                        return IsCollisionable(alpha.Extend(pP.ToVector2(), -pD).ToVector3()) &&
                               IsCollisionable(beta.Extend(pP.ToVector2(), -pD).ToVector3());
                    }

                    if (IsCollisionable(alpha.Extend(pP.ToVector2(), -i).ToVector3()) &&
                        IsCollisionable(beta.Extend(pP.ToVector2(), -1).ToVector3()))
                    {
                        return true;
                    }

                    return false;
                }

            }

            return false;
        }

        public static bool IsMinionCondemnable(AIMinionClient minion)
        {
            return GameObjects.JungleLarge.Any(x => minion.NetworkId == x.NetworkId) &&
                   NavMesh.GetCollisionFlags(
                           minion.Position.ToVector2().Extend(GameObjects.Player.Position.ToVector2(), -400)
                               .ToVector3())
                       .HasFlag(CollisionFlags.Wall) ||
                   NavMesh.GetCollisionFlags(minion.Position.ToVector2().Extend(
                       GameObjects.Player.Position.ToVector2(), -200).ToVector3()).HasFlag(CollisionFlags.Wall);
        }
    }
}