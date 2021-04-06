using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Jinx;
namespace EzAIO.Champions.Jinx
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] WBaseDamage = {0f, 10f, 110f, 160f, 210f, 210f};
        private static readonly float[] RBaseDamage = {0f, 250f, 350f, 450f, 450f};
        private static readonly float[] Multiplir = {0f, .25f, .3f, .35f, .35f};

        public static float WDamage(AIBaseClient target)
        {
            var wLevel = W.Level;
            var wBaseDamage = WBaseDamage[wLevel] + 1.6f * Player.TotalAttackDamage;
            return (float) Player.CalculateDamage(target, DamageType.Physical, wBaseDamage);
        }

        public static float RDamage(AIBaseClient target)
        {
            var rLevel = R.Level;
            var rBaseDamage = RBaseDamage[rLevel] + 1.5f * Player.GetBonusPhysicalDamage() +
                              Multiplir[rLevel] * (target.MaxHealth - target.Health);
            var rDistance = ((int) Math.Ceiling(target.DistanceToPlayer() / 100) * 6 + 4) / 10;
            var total = rBaseDamage * (rDistance >= 1 ? 1 : rDistance);
            return (float) Player.CalculateDamage(target, DamageType.Physical, total);
        }
    }
}