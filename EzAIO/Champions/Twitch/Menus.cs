using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Twitch.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Twitch.Twitch;
namespace EzAIO.Champions.Twitch
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
                AutomaticMenu.Qsilent,
                new MenuSeparator("info","^ Twitch back in invisible.")
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QList,
                ComboMenu.WList,
                ComboMenu.WBool,
                ComboMenu.WRBool,
                ComboMenu.RSliderButton
            };
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.WSliderButton,
                HarassMenu.ESliderButton,
                HarassMenu.EBool
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.EBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.ESliderButton,
                LaneclearMenu.ESlider
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.WSliderButton,
                JungleclearMenu.ESliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool,
                DrawConfig.Edmg,
                DrawConfig.EDmgJG,
                DrawConfig.QTime,
                DrawConfig.RTime
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