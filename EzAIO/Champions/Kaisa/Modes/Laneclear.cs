using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
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

            if (LaneclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var countMinions = GameObjects.EnemyMinions.Count(x => x.IsValidTarget(Q.Range) &&
                                                                   x.DistanceToPlayer() <= Q.Range);
            if (countMinions < LaneclearMenu.QCount.Value)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastE()
        {
            if (!LaneclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (!GameObjects.EnemyMinions.Any(x => x.IsValidTarget(Q.Range) && x.DistanceToPlayer() <= Q.Range))
            {
                return;
            }
            Game.Print("Hola");
            E.Cast();
        }
    }
}