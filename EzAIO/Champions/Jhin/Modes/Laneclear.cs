using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using EzAIO.Extras;
using static EzAIO.Champions.Jhin.Damage;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
using static EzAIO.Extras.Helps;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var bestMinion = GameObjects.EnemyMinions.FirstOrDefault(x =>
                x.IsValidTarget(Q.Range) && x.Health < QDamage(x) &&
                CountInRange(x,300, GameObjects.EnemyMinions) >= LaneclearMenu.QSlider.Value);
            if (bestMinion == null)
            {
                return;
            }
            

            Q.CastOnUnit(bestMinion);
        }

        public static void CastW()
        {
            if (!LaneclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.WSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(W.Range)).ToList();
            var farmLine = W.GetLineFarmLocation(minions, W.Width);
            if (farmLine.MinionsHit < LaneclearMenu.WSlider.Value)
            {
                return;
            }
            
            W.Cast(farmLine.Position);
        }

        public static void CastE()
        {
            if (!LaneclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;
            }
            var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(E.Range)).ToList();
            var farmPos = E.GetCircularFarmLocation(minions, E.Width);
            if (farmPos.MinionsHit < LaneclearMenu.ESlider.Value)
            {
                return;
            }

            E.Cast(farmPos.Position);
        }
    }
}