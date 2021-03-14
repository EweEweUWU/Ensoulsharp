using EnsoulSharp.SDK;

namespace EzAIO.Champions.Kaisa
{
    static class Extension
    {
        public static bool HasE()
        {
            return GameObjects.Player.HasBuff("kaisaestealth");
        }

        public static bool QUpgraded()
        {
            return GameObjects.Player.HasBuff("kaisaqevolved");
        }

        public static bool WUpgraded()
        {
            return GameObjects.Player.HasBuff("kaisawevolved");
        }

        public static bool EUpgraded()
        {
            return GameObjects.Player.HasBuff("kaisaeevolved");
        }
    }
}