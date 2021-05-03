using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Jhin;
using static EzAIO.Champions.Jhin.Extension;
namespace EzAIO.Champions.Jhin
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] QBaseDamage = {0f, 45f, 70f, 95f, 120f, 145f, 145f};
        private static readonly float[] QMultiplier = {0f, .35f, .425f, .5f, .575f, .65f, .65f};
        private static readonly float[] WBaseDamage = {0f, 50f, 85f, 120f, 155f, 190f, 190f};
        private static readonly float[] EBaseDamage = {0f, 20f, 80f, 140f, 200f, 260f, 260f};
        private static readonly float[] RBaseDamage = {0f, 50f, 125f, 200f, 200f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] + QMultiplier[qLevel] * Player.TotalAttackDamage +
                              .6f * Player.TotalMagicalDamage;
            return (float) Player.CalculateDamage(target, DamageType.Physical, qBaseDamage);
        }

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wBaseDamage = WBaseDamage[wLevel] + .5f * Player.TotalAttackDamage;
            return (float) Player.CalculateDamage(target, DamageType.Physical, wBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + 1.2f * Player.TotalAttackDamage +
                              1f * Player.TotalMagicalDamage;
            if (!(target is AIHeroClient) || target.RHBCAU())
            {
                eBaseDamage *= .65f;
            }

            return (float) Player.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RShot(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rShotDamage = RBaseDamage[rLevel] + .2f * Player.TotalAttackDamage;
            rShotDamage *= (target.MaxHealth - target.Health)*2.5f;
            return (float) Player.CalculateDamage(target, DamageType.Physical, rShotDamage * (Extension.Has4Shot() ? 2 : 1));
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] + .2f * Player.TotalAttackDamage;
            rBaseDamage *= (target.MaxHealth - target.Health) * 2.5f * 5;
            return (float) Player.CalculateDamage(target, DamageType.Physical, rBaseDamage);
        }
    }
}