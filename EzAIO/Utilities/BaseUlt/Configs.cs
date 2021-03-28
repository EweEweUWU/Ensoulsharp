using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Utilities.BaseUlt
{
    public static class Configs
    {
        public static class BaseUltMenu
        {
            public static readonly MenuBool EnableBool =
                new MenuBool("enable", "Enable");

            public static readonly MenuBool CollisionBool =
                new MenuBool("coll", "Check Collision");

            public static readonly MenuSlider EnemyRangeSlider =
                new MenuSlider("range", "Don't cast if Enemyes in Range", 1200, 100, 2000);

            public static readonly MenuList NotifyModeList =
                new MenuList("notify", "Notify Mode", new[] {"Chat", "Screen"}, 0);

            public static readonly MenuKeyBind PanicKey =
                new MenuKeyBind("key", "Don't cast while is pressed", Keys.Space, KeyBindType.Press);
        }
    }
}