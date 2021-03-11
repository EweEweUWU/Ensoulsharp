using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Damage;
using static EzAIO.Champions.Twitch.Configs;
namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastW()
        {
            if (!JungleclearMenu.WSliderButton.Enabled || !W.IsReady())
            {
                return;
            }

            if (JungleclearMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var wtarget = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (wtarget == null)
            {
                return;
            }

            var winput = W.GetPrediction(wtarget);
            if (winput.Hitchance >= HitChance.High)
            {
                W.Cast(winput.UnitPosition);
            }
        }

        public static void CastE()
        {
            if (!JungleclearMenu.ESliderButton.Enabled || !E.IsReady())
            {
                return;
            }

            if (JungleclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var etarget = GameObjects.Jungle.FirstOrDefault(x=>x.IsValidTarget(E.Range));
            if (etarget == null || !Extension.HasPoisonEffect(etarget,E.Range))
            {
                return;
            }

            if (EDamage(etarget) >= etarget.Health - GameObjects.Player.CalculateDamage(etarget, DamageType.Mixed, 1))
            {
                E.Cast();
            }
        }
    }
}