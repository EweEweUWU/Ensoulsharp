using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;

namespace EzAIO.Champions.Vayne
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] QBaseDamage = {0f, .6f, .65f, .7f, .75f, .8f, .8f};
        private static readonly float[] WBaseDamage = {0f, .04f, .065f, .09f, .115f, .14f, .14f};
        private static readonly float[] WTrueDamage = {0f, 50f, 65f, 80f, 95f, 110f, 110f};
        private static readonly float[] EBaseDamage = {0f, 50f, 85f, 120f, 155f, 190f, 190f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] * GameObjects.Player.TotalAttackDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wTrueDamage = WTrueDamage[wLevel];
            var wBaseDamage = WBaseDamage[wLevel] * target.MaxHealth;
            if (target is AIMinionClient jungle && jungle.IsJungle())
            {
                return Math.Max(wTrueDamage, Math.Min(200, wBaseDamage));
            }
            return Math.Max(wTrueDamage, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + .5f * GameObjects.Player.GetBonusPhysicalDamage();
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, eBaseDamage);
        }
    }
}