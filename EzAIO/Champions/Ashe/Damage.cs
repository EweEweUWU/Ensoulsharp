using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Ashe;
namespace EzAIO.Champions.Ashe
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] WBaseDamage = {0f, 20f, 35f, 50f, 65f, 80f, 80f};
        private static readonly float[] RBaseDamage = {0f, 200f, 400f, 600f};

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wBaseDamage = WBaseDamage[wLevel] +
                              1f*Player.TotalAttackDamage;
            return (float) Player.CalculateDamage(target, DamageType.Physical, wBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] +
                              1f*Player.TotalMagicalDamage;
            return (float) Player.CalculateDamage(target, DamageType.Magical, rBaseDamage);
        }
    }
}