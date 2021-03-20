using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
namespace EzAIO.Champions.Katarina.Modes
{
    using static ChampionBases;
    static class Flee
    {
        public static void CastW()
        {
            if (!FleeMenu.WBool.Enabled || !W.IsReady())
            {
                return;
            }

            W.Cast();
        }

        public static void CastE()
        {
            if (!FleeMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }

            var dagger = Extension.Daggers.FirstOrDefault(
                x => x.Distance(Game.CursorPos) < 450);
            if (dagger == null)
            {
                return;
            }

            var target = GameObjects.AttackableUnits.Where(x => x.IsTargetable &&
                                                                x.DistanceToCursor() <= E.Range &&
                                                                Game.CursorPos.DistanceToPlayer() >
                                                                x.Distance(Game.CursorPos))
                .OrderBy(x => x.DistanceToPlayer()).FirstOrDefault();
            if (target != null)
            {
                E.Cast(target.Position);
            }
        }
    }
}