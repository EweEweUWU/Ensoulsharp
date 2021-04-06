using System;
using EnsoulSharp;
using EnsoulSharp.SDK;

namespace EzAIO.Champions.Tristana
{
    static class Extension
    {
        public static bool IsCharged(this AIBaseClient target)
        {
            return target.HasBuff("TristanaECharge");
        }

        /*public static bool IsPerfectCharged(this AIBaseClient target)
        {
            if (target.IsCharged() &&
                target.IsValidTarget())
            {
                switch (target.Type)
                {
                    case GameObjectType.AIMinionClient:
                        return true;
                    case GameObjectType.AIHeroClient:
                        var heroTarget = (AIHeroClient) target;
                        return !heroTarget.IsInvulnerable;
                }
            }

            return false;
        }*/
        public static Boolean HasEBuff(AIBaseClient target)
        {
            return target.HasBuff("TristanaECharge");
        }

        public static int EBuffCount(this AIBaseClient target)
        {
            return target.GetBuffCount("TristanaECharge");
        }
    }
}