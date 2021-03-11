using EnsoulSharp;
using EnsoulSharp.SDK;
using static EzAIO.Champions.Lucian.Lucian;
namespace EzAIO.Champions.Lucian
{
    using static Configs;
    static class Extension
    {
        public static bool IsCulling()
        {
            return GameObjects.Player.HasBuff("LucianR");
        }

        public static bool HasPassive()
        {
            return GameObjects.Player.HasBuff("LucianPassiveBuff");
        }

        public static Geometry.Rectangle QRectangle(AIBaseClient unit)
        {
            return new Geometry.Rectangle(GameObjects.Player.Position,
                GameObjects.Player.Position.Extend(unit.Position, ExtendedQ.Range),
                ExtendedQ.Width);
        }

        public static bool CanCastE(AttackableUnit target)
        {
            if (GameObjects.Player.Distance(Game.CursorPos) <= GameObjects.Player.GetRealAutoAttackRange() &&
                MiscellaneousMenu.OnlyEifMouseOutAARangeBool.Enabled)
            {
                return false;
            }

            var posAfterE = GameObjects.Player.Position.Extend(Game.CursorPos, 300f);
            if (posAfterE.Distance(target) > GameObjects.Player.GetRealAutoAttackRange(target) &&
                MiscellaneousMenu.NoOutAARangeBool.Enabled)
            {
                return false;
            }

            if (posAfterE.IsUnderEnemyTurret() &&
                MiscellaneousMenu.NoTurret.Enabled)
            {
                return false;
            }

            return true;
        }
    }
}