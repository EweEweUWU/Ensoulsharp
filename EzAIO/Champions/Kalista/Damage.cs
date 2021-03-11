using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] QBaseDamage = {0, 20, 85, 150, 215, 280, 280};
        private static readonly float[] EBaseDamage = {0, 20, 30, 40, 50, 60, 60};
        private static readonly float[] EStackBaseDamage = {0, 10, 14, 19, 25, 32, 32};
        private static readonly float[] EStackMultiplierDamage = {0, .198f, .23748f, .27498f, .31248f, .34988f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] + 1f * GameObjects.Player.TotalAttackDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, qBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + .6 * GameObjects.Player.TotalAttackDamage;
            var eStackDamage = EStackBaseDamage[eLevel] +
                               EStackMultiplierDamage[eLevel] * GameObjects.Player.TotalAttackDamage;
            var eStacksOnTarget = target.GetBuffCount("kalistaexpungemarker");
            if (eStacksOnTarget == 0)
            {
                return 0;
            }

            var total = eBaseDamage + eStackDamage * (eStacksOnTarget - 1);
            if (target is AIMinionClient minion && (minion.GetJungleType() & JungleType.Legendary) != 0)
            {
                total /= 2;
            }

            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Physical, total);
        }
    }
}