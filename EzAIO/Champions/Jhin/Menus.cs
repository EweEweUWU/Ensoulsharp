using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Jhin.Jhin;

namespace EzAIO.Champions.Jhin
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
                AutomaticMenu.ECCBool,
                AutomaticMenu.ETeleportBool
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.QReloadBool,
                ComboMenu.WBool,
                ComboMenu.WRangeBool,
                ComboMenu.WCCBool,
                ComboMenu.EBool,
                ComboMenu.EReloadBool,
                ComboMenu.RBool,
                ComboMenu.RCursor,
            };
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.QBool,
                KillstealMenu.WBool,
                KillstealMenu.RShoot
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton,
                LaneclearMenu.WSliderButton,
                LaneclearMenu.ESliderButton,
                new Menu("Customization", "Customization")
                {
                    LaneclearMenu.QSlider,
                    LaneclearMenu.WSlider,
                    LaneclearMenu.ESlider
                }
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.ESliderButton
            };
            var lasthitMenu = new Menu("Lasthit", "Last Hit")
            {
                LasthitMenu.QSliderButton,
                LasthitMenu.QReloadBool
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.QBool,
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool,
                
            };
            var menuList = new[]
            {
                automaticMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneclearMenu,
                jungleclearMenu,
                lasthitMenu,
                drawMenu
            };
            foreach (var menu in menuList)
            {
                mainMenu.Add(menu);
            }
        }
    }
}