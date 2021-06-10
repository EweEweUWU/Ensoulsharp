using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;
using static EnsoulSharp.SDK.Geometry;

namespace EzAIO.Extras
{
    static class Helps
    {
        public static readonly string[] GrabsNames = {"ThreshQ", "rocketgrab2"};

        public static bool IsGrabbed(this AIHeroClient hero)
        {
            return hero.Buffs.Any(x => GrabsNames.Contains(x.Name));
        }
        private static IEnumerable<AIBaseClient> GetInRange(Vector2 pos, float range, IEnumerable<AIBaseClient> units)
        {
            return units.Where(x => x != null && x.IsValid && x.Position.To2D().Distance(pos) <= range).ToList();
        }
        public static int CountInRange(this Vector2 pos, float range, IEnumerable<AIBaseClient> units)
        {
            return GetInRange(pos, range, units).Count();
        }

        public static int CountInRange(AIBaseClient unit, float range, IEnumerable<AIBaseClient> units)
        {
            return GetInRange(unit.Position.To2D(), range, units).Count();
        }

        public static List<AIHeroClient> GetBestEnemyHeroesTarget()
        {
            return GetBestEnemyHeroesInRange(float.MaxValue);
        }
        public static List<AIHeroClient> GetBestEnemyHeroesInRange(float range)
        {
            return GameObjects.EnemyHeroes.Where(x => x.InRange(range)).ToList();
        }
    }
}