using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Developer
{
    public static class Configs
    {
        public static class BuffMenu
        {
            public static readonly MenuBool MyBuffBool =
                new MenuBool("my", "Show my Buffs");

            public static readonly MenuBool EnemieBuffBool =
                new MenuBool("enemie", "Show enemie Buffs");
        }
    }
}