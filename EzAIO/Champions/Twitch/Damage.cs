using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Twitch
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] EBaseDamage = {0f, 20f, 30f, 40f, 50f, 60f, 60f};
        private static readonly float[] EStackDamage = {0f, 15f, 20f, 25f, 30f, 35f, 35f};

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel];
            var stackDamage = (EStackDamage[eLevel] + GameObjects.Player.PercentBonusPhysicalDamageMod * .35f +
                               GameObjects.Player.TotalMagicalDamage * .333f) * Extension.BuffStacks(target);
            var totalDamage = eBaseDamage + stackDamage;
            return (float) (GameObjects.Player.CalculateDamage(target, DamageType.Physical, totalDamage));
        }
    }
}