using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Jinx.Jinx;

namespace EzAIO.Champions.Jinx
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
                AutomaticMenu.WCCBool,
                AutomaticMenu.ECCBool,
                AutomaticMenu.ETeleportBool
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.EnemiesBool,
                ComboMenu.PBool,
                ComboMenu.EKey,
                ComboMenu.Rkey,
                ComboMenu.RSliderRange,
                ComboMenu.RSafeBool
            };
            ComboMenu.EKey.Permashow();
            ComboMenu.Rkey.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.WSliderButton,
                HarassMenu.EnemiesBool
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.WSliderButton,
                KillstealMenu.RSliderButton
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton,
                LaneclearMenu.SwapBool,
                new Menu("customization", "Customization")
                {
                    LaneclearMenu.QCountSlider
                }
            };
            var lasthitMenu = new Menu("Lasthit", "Last Hit")
            {
                LasthitMenu.QSliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle CLear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.WSliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawConfig.QRRange,
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
                lasthitMenu,
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