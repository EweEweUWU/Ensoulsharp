using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
namespace EzAIO.Champions.Tristana.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastR()
        {
            if (!AutomaticMenu.RPeelSliderButton.Enabled || Player.Health >= AutomaticMenu.RPeelSliderButton.Value)
            {
                return;;
            }

            var target = GameObjects.EnemyHeroes
                .Where(x => x.IsValidTarget(Player.GetRealAutoAttackRange()) && x.IsMelee)
                .MaxBy(x => x.TotalAttackDamage);
            if (target == null)
            {
                return;
            }

            R.CastOnUnit(target);
        }
    }
}