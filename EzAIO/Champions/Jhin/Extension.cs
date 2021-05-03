using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;
using static EzAIO.Champions.Jhin.Jhin;
using static EzAIO.Bases.ChampionBases;
using static EnsoulSharp.SDK.Geometry;
namespace EzAIO.Champions.Jhin
{
    static class Extension
    {
        public static Vector3 End = Vector3.Zero;
        public static int UltimateShootsCount;

        public static bool Has4Shot()
        {
            return Player.HasBuff("jhinpassiveattackbuff");
        }

        public static bool IsMarked(this AIBaseClient target)
        {
            return target.HasBuff("jhinespotteddebuff");
        }

        public static bool RHBCAU(this AIBaseClient target)
        {
            return target.HasBuff("jhinetrapslow");
        }

        public static bool HasUltimate4Shoot()
        {
            return UltimateShootsCount == 3;
        }

        public static bool IsReloading()
        {
            return Player.HasBuff("JhinPassiveReload");
        }

        public static bool IsUltShooting()
        {
            return R.Name.Equals("JhinRShot");
        }

        public static Sector RCone()
        {
            return new Sector(Player.Position, End, (float) (60f * Math.PI / 180f), R.Range, 2);
        }

        public static IEnumerable<AIHeroClient> EnemiesInsideCone()
        {
            if (!IsUltShooting())
            {
                return null;
            }
            return GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(R.Range) && RCone().IsInside(x)).ToList();
        }
    }
}