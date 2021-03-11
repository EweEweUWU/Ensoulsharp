using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using SharpDX;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Extra
    {
        public static bool CastE()
        {
            switch (ComboMenu.EMode.Index)
            {
                case 0:
                    return DynamicCastE();
                case 1:
                    return E.Cast(
                        GameObjects.Player.Position.Extend(Game.CursorPos, GameObjects.Player.BoundingRadius));
                case 2:
                    return E.Cast(GameObjects.Player.Position.Extend(Game.CursorPos, 425f));
            }

            return false;
        }

        public static bool CastQ(AfterAttackEventArgs args)
        {
            if (!ComboMenu.QBool.Enabled)
            {
                return false;
            }

            var target = args.Target as AIHeroClient;
            if (target == null)
            {
                return false;
            }

            return Q.CastOnUnit(target);
        }

        public static bool CastW(AfterAttackEventArgs args)
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return false;
            }

            return W.Cast(args.Target.Position);
        }

        private static bool DynamicCastE()
        {
            Vector3 point;
            if (GameObjects.Player.Position.IsUnderEnemyTurret() ||
                GameObjects.Player.Distance(Game.CursorPos) <
                GameObjects.Player.GetRealAutoAttackRange())
            {
                point = GameObjects.Player.Position.Extend(Game.CursorPos, GameObjects.Player.BoundingRadius);
            }
            else
            {
                point = GameObjects.Player.Position.Extend(Game.CursorPos, 475f);
            }

            return E.Cast(point);
        }
    }
}