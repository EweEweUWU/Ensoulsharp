using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using static EzAIO.Champions.Jinx.Jinx;
using static EzAIO.Bases.ChampionBases;

namespace EzAIO.Champions.Jinx
{
    static class Extension
    {
        public static float RocketRange
            => MinigunRange + 50 + 25 * Q.Level;

        private static float MinigunRange
            => 595;
        public static bool ActivatedRockets { get; set; }
        public static bool ActivatedPassive { get; set; }
        
        public static bool Swap(AIBaseClient target)
        {
            return SwapToMinigun(target) || SwapToRockets(target);
        }

        private static bool SwapToMinigun(AIBaseClient target)
        {
            return ActivatedRockets && target.DistanceToPlayer() < MinigunRange;
        }

        private static bool SwapToRockets(AIBaseClient target)
        {
            return !ActivatedRockets &&
                   (target.DistanceToPlayer() < RocketRange && target.CountEnemyHeroesInRange(150) >= 2 ||
                    target.DistanceToPlayer() > MinigunRange && target.DistanceToPlayer() < RocketRange);
        }
        public static float RocketDamage(AIBaseClient target)
        {
            return Player.GetRealAutoAttackRange(target) * 1.1f;
        }

        public static int KillableMinionsCount(AIMinionClient minions)
        {
            return GameObjects.EnemyMinions.Count(x => x.IsValidTarget(RocketRange) &&
                                                       x.Distance(minions) <= 150 &&
                                                       RocketRange >= x.Health -
                                                       Player.CalculateDamage(x, DamageType.Physical, 1));
        }
    }
}