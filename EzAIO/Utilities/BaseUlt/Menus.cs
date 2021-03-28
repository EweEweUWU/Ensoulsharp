using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Utilities.BaseUlt.Configs;
using static EzAIO.Program;
namespace EzAIO.Utilities.BaseUlt
{
    class Menus
    {
        
        public Menus()
        {
            Initialize();
        }
        
        public static void Initialize()
        {
            var baseMenu = new Menu("baseULT", "Base Ult")
            {
                BaseUltMenu.EnableBool,
                BaseUltMenu.CollisionBool,
                BaseUltMenu.EnemyRangeSlider,
                BaseUltMenu.NotifyModeList,
                BaseUltMenu.PanicKey
            };
            BaseUltMenu.PanicKey.Permashow();
            util.Add(baseMenu);
        }
    }
}