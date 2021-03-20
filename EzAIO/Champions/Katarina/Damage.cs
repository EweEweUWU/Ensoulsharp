using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;

namespace EzAIO.Champions.Katarina
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] QBaseDamage = {0f, 75f, 105f, 135f, 165f, 195f, 195f};

        private static readonly float[] PasivaDamage =
        {
            0f, 68f, 72f, 77f, 82f, 89f, 96f, 103f, 112f, 121f, 131f, 142f, 154f, 166f, 180f, 194f, 208f, 224f, 240f,
            240f
        };

        private static readonly float[] EBaseDamage = {0f, 15f, 30f, 45f, 60f, 75f, 75f};
        private static readonly float[] RBaseDamage = {0f, 25f, 37.5f, 50f, 50f};

        public static float QDamage(AIBaseClient target)
        {
            var qLevel = Q.Level;
            var qBaseDamage = QBaseDamage[qLevel] + .3 * GameObjects.Player.TotalMagicalDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, qBaseDamage);
        }

        public static float Passive(AIBaseClient target)
        {
            var pBonus = 0f;
            if (GameObjects.Player.Level >= 1 && GameObjects.Player.Level < 6)
            {
                pBonus = .55f;
            }

            if (GameObjects.Player.Level >= 6 && GameObjects.Player.Level < 11)
            {
                pBonus = .66f;
            }

            if (GameObjects.Player.Level >= 11 && GameObjects.Player.Level < 16)
            {
                pBonus = .77f;
            }

            if (GameObjects.Player.Level >= 16)
            {
                pBonus = .88f;
            }

            var dagger = Extension.Daggers.FirstOrDefault(x => x.IsValid && x.Distance(target) < 450);
            if (dagger == null)
            {
                return 0f;
            }

            var pBaseDamage = PasivaDamage[GameObjects.Player.Level > 18 ? 18 : GameObjects.Player.Level] +
                              .75f * GameObjects.Player.GetBonusPhysicalDamage() +
                              pBonus * GameObjects.Player.TotalMagicalDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, pBaseDamage);
        }

        public static float EDamage(AIBaseClient target)
        {
            var eLevel = E.Level;
            var eBaseDamage = EBaseDamage[eLevel] + .5f * GameObjects.Player.TotalAttackDamage +
                              .25f * GameObjects.Player.TotalMagicalDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, eBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] + .16 * GameObjects.Player.GetBonusPhysicalDamage() +
                              .19f * GameObjects.Player.TotalMagicalDamage;
            return (float) GameObjects.Player.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}