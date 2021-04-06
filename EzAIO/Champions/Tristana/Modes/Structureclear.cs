using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
namespace EzAIO.Champions.Tristana.Modes
{
    using static ChampionBases;
    static class Structureclear
    {
        public static void Cast(BeforeAttackEventArgs args)
        {
            if (StructureclearMenu.NoEnemiesRange.Enabled &&
                (Player.CountEnemyHeroesInRange(Player.GetRealAutoAttackRange()) >=
                 StructureclearMenu.NoEnemiesRange.Value))
            {
                return;
            }

            var turret = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(Player.GetRealAutoAttackRange()));
            if (turret == null)
            {
                return;
            }
            CastQ();
            CastE(args);
        }
        
        private static void CastQ()
        {
            if (!StructureclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            Q.Cast();
        }

        private static void CastE(BeforeAttackEventArgs args)
        {
            if (!StructureclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (StructureclearMenu.ESliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            E.CastOnUnit(args.Target);
        }
    }
}