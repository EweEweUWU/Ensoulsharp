using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Developer.Configs;
using static EzAIO.Program;

namespace EzAIO.Developer
{
    class Menus
    {
        public Menus()
        {
            Initialize();
        }
        public static void Initialize()
        {
            var buffMenu = new Menu("Buff", "Buffs")
            {
                BuffMenu.MyBuffBool,
                BuffMenu.EnemieBuffBool
            };
            var menuList = new[]
            {
                buffMenu
            };
            foreach (var menu in menuList)
            {
                util.Add(menu);
            }
        }
    }
}