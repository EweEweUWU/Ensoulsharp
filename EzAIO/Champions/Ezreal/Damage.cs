using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal
{
    using static ChampionBases;
    class Damage
    {
        
        private static readonly float[] QBaseDamage = {0f, 20f, 45f, 70f, 95f, 120f, 120f};
        private static readonly float[] WBaseDamage = {0f, 80f, 135f, 190f, 245f, 300f, 300f};
        private static readonly float[] WAPScaling = {0f, .7f, .75f, .80f, .85f, .90f, .90f};
        private static readonly float[] EBaseDamage = {0f, 80f, 130f, 180f, 230f, 280f, 280f};
        private static readonly float[] RBaseDamage = {0f, 350f, 500f, 650f, 650f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] +
                                (1.3f * GameObjects.Player.TotalAttackDamage +
                                 .15f * GameObjects.Player.TotalMagicalDamage);
            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Physical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wBaseDamage = WBaseDamage[wLevel] +
                              (.6f * GameObjects.Player.TotalAttackDamage +
                               WAPScaling[wLevel] * GameObjects.Player.TotalMagicalDamage);
            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] +
                            (.5f * GameObjects.Player.TotalAttackDamage +
                             .75f * GameObjects.Player.TotalMagicalDamage);
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] +
                              (1f * GameObjects.Player.TotalAttackDamage +
                               .9f * GameObjects.Player.TotalMagicalDamage);
            if (target is AIMinionClient minion && !minion.IsJungle())
            {
                rBaseDamage /= 2;
            }

            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}