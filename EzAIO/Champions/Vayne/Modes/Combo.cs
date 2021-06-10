using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using EzAIO.Extras;
using SharpDX;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    class Combo
    {
        public static void CastQ()
        {
            if (!ComboMenu.QEngageBool.Enabled ||
                GameObjects.Player.Distance(Game.CursorPos) <= GameObjects.Player.GetRealAutoAttackRange())
            {
                return;
            }

            switch (ComboMenu.QList.Index)
            {
                case 0:
                    var qtarget = Q.GetTarget();
                    if (qtarget == null || qtarget.IsInvulnerable ||
                        qtarget.DistanceToPlayer() <= GameObjects.Player.GetRealAutoAttackRange(qtarget))
                    {
                        return;
                    }

                    var posAfterQ = GameObjects.Player.Position.Extend(Game.CursorPos, 425f);
                    if (posAfterQ.CountEnemyHeroesInRange(1000f) >= 3 ||
                        qtarget.Distance(posAfterQ) >= GameObjects.Player.GetRealAutoAttackRange() ||
                        posAfterQ.IsUnderEnemyTurret())
                    {
                        return;
                    }

                    Q.Cast(posAfterQ);
                    break;
                case 1:
                    var target = Q.GetTarget();
                    if (target == null || target.IsInvulnerable ||
                        target.DistanceToPlayer() <= GameObjects.Player.GetRealAutoAttackRange(target))
                    {
                        return;
                    }
                    SafeQ(target);
                    break;
            }
        }

        private static void SafeQ(AIBaseClient enemy)
        {
            var range = enemy.GetRealAutoAttackRange();
            var path = Extension.CircleCircleIntersection(VectorConversions.To2D(GameObjects.Player.Position),
                VectorConversions.To2D(enemy.Position), 300, range);
            if (path.Length > 0)
            {
                var qpos = path.MinBy(x => x.Distance(Game.CursorPos));
                if (VectorConversions.To3D2(qpos).IsUnderEnemyTurret() || VectorConversions.To3D2(qpos).IsWall())
                {
                    return;
                }

                if (VectorConversions.To3D2(qpos).CountEnemyHeroesInRange(200) > 0)
                {
                    return;
                }

                Q.Cast(qpos);
            }

            if (path.Length == 0)
            {
                var qpos = GameObjects.Player.Position.Extend(enemy.Position, -300f);
                if (qpos.IsUnderEnemyTurret() || qpos.IsWall())
                {
                    return;
                }

                Q.Cast(GameObjects.Player.Position.Extend(enemy.Position, -300));
            }
        }

        public static void CastE()
        {
            if (!ComboMenu.EBool.Enabled || GameObjects.Player.IsDashing())
            {
                return;
            }

            var target = E.GetTarget();
            if (target == null)
            {
                return;
            }

            if (Extension.IsCondemnable(target))
            {
                E.CastOnUnit(target);
            }
        }
    }
}