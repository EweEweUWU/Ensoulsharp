using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;

namespace EzAIO.Champions.Kaisa
{
    using static ChampionBases;
    class Damage
    {
        private static readonly float[] WBseDamage = {0f, 30f, 55f, 80f, 105f, 130f, 130f};

        public static float WDamage(AIBaseClient target)
        {
            var missingHealth = target.MaxHealth - target.Health;
            var wLevel = W.Level;
            var wBaseDamage = WBseDamage[wLevel] +
                              GameObjects.Player.TotalAttackDamage * 1.3f +
                              GameObjects.Player.TotalMagicalDamage * .7f;
            if (target.GetBuffCount("kaisapassivemarker") >= (GameObjects.Player.FlatMagicDamageMod >= 100 ? 2 : 3))
            {
                var passiveDamage = missingHealth *
                                    (.15f + .0375f * GameObjects.Player.TotalMagicalDamage / 100);
                if (target is AIMinionClient jungle && jungle.IsJungle())
                {
                    wBaseDamage += Math.Min(400, passiveDamage);
                }
                else
                {
                    wBaseDamage += passiveDamage;
                }

            }

            return (float)GameObjects.Player.CalculateDamage(target, DamageType.Magical, wBaseDamage);
        }
    }
}