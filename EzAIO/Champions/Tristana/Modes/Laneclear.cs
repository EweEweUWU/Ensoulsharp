using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
using static EzAIO.Extras.Helps;
namespace EzAIO.Champions.Tristana.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastE(BeforeAttackEventArgs args)
        {
            if (!LaneclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var bestMinion = GameObjects.EnemyMinions.FirstOrDefault(x =>
                x.IsValidTarget(Player.GetRealAutoAttackRange()) &&
                CountInRange(x,300,GameObjects.EnemyMinions) >=
                LaneclearMenu.EMinionSlider.Value);
            if (bestMinion == null)
            {
                return;
            }
            
            E.CastOnUnit(bestMinion);
        }

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
            
            Q.Cast();
        }
    }
}