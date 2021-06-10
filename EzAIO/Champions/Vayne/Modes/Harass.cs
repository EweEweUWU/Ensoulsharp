using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Extension;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!HarassMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var heroytarget = args.Target as AIHeroClient;
            if (heroytarget == null || !ShouldCastQ(heroytarget))
            {
                return;
            }

            Q.Cast(Game.CursorPos);
        }

        public static void CastE()
        {
            if (!HarassMenu.EsSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.EsSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            foreach (var targets in TargetSelector.GetTargets(E.Range,DamageType.Physical).ToList().Where(x=>x.Has2WStacks()))
            {
                E.CastOnUnit(targets);
                break;
            }
        }
    }
}