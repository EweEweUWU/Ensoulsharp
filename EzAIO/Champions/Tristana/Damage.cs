using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Tristana.Tristana;
using static  EzAIO.Champions.Tristana.Extension;
namespace EzAIO.Champions.Tristana
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] EBaseDamage = {0f, 70f, 80f, 90f, 100f, 110f, 110f};
        private static readonly float[] EMultiplier = {0f, .5f, .75f, 1f, 1.25f, 1.5f, 1.5f};
        private static readonly float[] EStack = {0f, 21f, 24f, 27f, 30f, 33f, 33f};
        private static readonly float[] EStackMultiplier = {0f, .15f, .225f, .30f, .375f, .45f, .45f};
        private static readonly float[] RBaseDamage = {0f, 300f, 400f, 500f, 500f};

        public static float EDamage(AIBaseClient target)
        {
            if (!target.IsCharged())
            {
                return 0;
            }

            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + 
                              EMultiplier[eLevel] * Player.GetBonusPhysicalDamage() +
                              .5f * Player.TotalMagicalDamage;
            var eBonusDamage = EStack[eLevel] + EStackMultiplier[eLevel] + Player.TotalAttackDamage +
                               .15 * Player.TotalMagicalDamage;
            var total = eBaseDamage + eBonusDamage * target.EBuffCount();
            return (float) Player.CalculateDamage(target, DamageType.Physical, total);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] + Player.TotalMagicalDamage;
            return (float) Player.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
        
    }
}