using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Ashe.Ashe;

namespace EzAIO.Champions.Ashe
{
    class Menus
    {
        public Menus()
        {
            Initialize();
        }
        public static void Initialize()
        {
            var automaticMenu = new Menu("Automatic", "Automatic")
            {
                AutomaticMenu.Rinmobile,
                AutomaticMenu.RrangeSlider,
                AutomaticMenu.NoEnemiesSliderButton
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.RSemiKeyBind,
                new Menu("sep", "W Customization")
                {
                    ComboMenu.DontWBool
                }
            };
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.WSliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.WBool,
                KillstealMenu.RBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.WSliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool
            };
            var menuList = new[]
            {
                automaticMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneclearMenu,
                jungleclearMenu,
                drawMenu
            };
            foreach (var menu in menuList)
            {
                mainMenu.Add(menu);
            }
        }
    }
}