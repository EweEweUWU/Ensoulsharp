using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;

namespace EzAIO.Champions.Ezreal.Modes
{
    using static Ezreal;
    using static ChampionBases;

    class Structureclear
    {
        internal static void CastW()
        {
            if (!mainMenu["structure"].GetValue<MenuSliderButton>("w").Enabled || !W.IsReady())
            {
                return;
            }

            if (mainMenu["structure"].GetValue<MenuSliderButton>("w").Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var safecheck = mainMenu["structure"].GetValue<MenuSliderButton>("safe");
            var overrideCheck = mainMenu["structure"].GetValue<MenuSliderButton>("allies");
            var alliesCount = GameObjects.AllyHeroes.Count(x => x.IsValidTarget(900, true) && !x.IsMe);

            if (safecheck.Enabled && GameObjects.Player.CountEnemyHeroesInRange(safecheck.Value) != 0 &&
                (!overrideCheck.Enabled || alliesCount < overrideCheck.Value))
            {
                return;
            }

            if (safecheck.Enabled && GameObjects.Player.CountEnemyHeroesInRange(safecheck.Value) != 0 &&
                overrideCheck.Enabled && alliesCount < overrideCheck.Value)
            {
                return;
            }

            var wtarget = GameObjects.EnemyTurrets.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (wtarget == null)
            {
                return;
            }

            if (!GameObjects.Player.InAutoAttackRange(wtarget))
            {
                return;
            }

            W.Cast(wtarget.Position);
        }
        
    }
}