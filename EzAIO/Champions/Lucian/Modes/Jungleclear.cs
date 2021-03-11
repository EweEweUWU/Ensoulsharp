using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static bool CastQ(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.QSlider.Enabled)
            {
                return false;
            }

            if (JungleclearMenu.QSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return false;
            }

            var qtarget = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            if (qtarget == null)
            {
                return false;
            }

            return Q.CastOnUnit(qtarget);
        }

        public static bool CastW(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.WSlider.Enabled)
            {
                return false;
            }

            if (JungleclearMenu.WSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return false;
            }

            var wtarget = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (wtarget == null)
            {
                return false;
            }
            return W.Cast(args.Target.Position);
        }

        public static bool CastE()
        {
            if (!JungleclearMenu.ESlider.Enabled)
            {
                return false;
            }

            if (JungleclearMenu.ESlider.Value >= GameObjects.Player.ManaPercent)
            {
                return false;
            }

            var etarget = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(E.Range));
            if (etarget == null)
            {
                return false ;
            }
            return E.Cast(GameObjects.Player.Position.Extend(Game.CursorPos, GameObjects.Player.BoundingRadius));
        }
    }
}