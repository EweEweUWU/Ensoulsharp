using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
namespace EzAIO.Champions.Kalista.Modes
{
    using static ChampionBases;
    using static Damage;
    static class Jungleclear
    {
        public static void CastQ()
        {
            if (!Configs.Jungleclear.QSliderButton.Enabled || !Q.IsReady())
            {
                return;
            }

            if (Configs.Jungleclear.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }
            if (GameObjects.Player.IsDashing())
            {
                return;
            }

            var qtarget = GameObjects.Jungle.FirstOrDefault(X => X.IsValidTarget(Q.Range));
            if (qtarget == null)
            {
                return;
            }

            var qinput = Q.GetPrediction(qtarget);
            if (qinput.Hitchance >= HitChance.High)
            {
                Q.Cast(qinput.CastPosition);
            }
        }

        public static void CastE()
        {
            if (!Configs.Jungleclear.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (Configs.Jungleclear.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.Jungle.Any(x => x.IsValidTarget(E.Range) &&
                                            Extension.HasRendBuff(x, E.Range) &&
                                            EDamage(x) >= x.Health -
                                            GameObjects.Player.CalculateDamage(x, DamageType.Physical, 1)))
            {
                E.Cast();
            }
            
        }
    }
}