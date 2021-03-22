using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;

namespace EzAIO.Champions.Draven
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] EBaseDamage = {0f, 75f, 110f, 145f, 180f, 215f, 215f};
        private static readonly float[] RBaseDamage = {0f, 175f, 275f, 375f, 375f};
        private static readonly float[] RBonusAD = {0f, 1.1f, 1.3f, 1.5f, 1.5f};

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + .5f * GameObjects.Player.GetBonusPhysicalDamage();
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] + (RBonusAD[rLevel] * GameObjects.Player.GetBonusPhysicalDamage());
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, rBaseDamage);
        }
    }
}