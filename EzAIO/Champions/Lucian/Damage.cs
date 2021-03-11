using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Lucian
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] QBaseDamage = {0f, 95f, 130f, 165f, 200f, 235f, 235f};
        private static readonly float[] QMultiplier = {0f, .6f, .75f, .90f, 1.05f, 1.20f, 1.20f};
        private static readonly float[] WBaseDamage = {0f,.75f, 1.1f, 1.45f, 1.8f, 2.15f, 2.15f};
        private static readonly float[] RBaseDamage = {0f, 20f, 40f, 60f, 60f};
        private static readonly float[] RShots = {0, 22, 28, 34, 34};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] +
                              QMultiplier[qLevel] + GameObjects.Player.GetBonusPhysicalDamage();
            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Physical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wBaseDamage = WBaseDamage[wLevel] +
                              .9f * GameObjects.Player.TotalMagicalDamage;
            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] +
                              .25f * GameObjects.Player.TotalAttackDamage +
                              .1 + GameObjects.Player.TotalMagicalDamage;
            rBaseDamage *= RShots[rLevel];
            if (target is AIMinionClient minion && minion.IsMinion())
            {
                rBaseDamage *= 2;
            }

            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Physical, rBaseDamage);
        }
    }
}