using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Vayne.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Vayne.Vayne;
namespace EzAIO.Champions.Vayne
{
    class Menus
    {
        public Menus()
        {
            Initialize();
        }

        public static void Initialize()
        {
            var miscellaneousMenu = new Menu("Miscellaneous", "Miscellaneous")
            {
                new Menu("q", "Q Combo Customization")
                {
                    MiscellaneousMenu.QTurretBool,
                    MiscellaneousMenu.NoQAAEnemiesBool,
                    MiscellaneousMenu.QIfMouseOutAABool,
                    MiscellaneousMenu.Q3stackBool,
                    MiscellaneousMenu.QrangeCheckBool
                },
            };
            var automaticMenu = new Menu("Automatic", "Automatic")
            {
                new Menu("e", "Condemm Logic")
                {
                    AutomaticMenu.EsSliderButton,
                    new MenuSeparator("sep2", "It will only use it against Melees in E Range")
                }
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.QList,
                ComboMenu.QEngageBool,
                ComboMenu.EBool,
                ComboMenu.ESmiKeybind
            };
            ComboMenu.QList.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.EsSliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.EBool,
                KillstealMenu.EAA
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.ESliderButton
            };
            var structureclearMenu = new Menu("Structureclear", "Structure Clear")
            {
                StructureclearMenu.QSliderButton,
                StructureclearMenu.NoEnemiesSliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.EBool,
                DrawConfig.Eposition
            };
            var menuList = new[]
            {
                miscellaneousMenu,
                automaticMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneclearMenu,
                jungleclearMenu,
                structureclearMenu,
                drawMenu
            };
            foreach (var menu in menuList)
            {
                mainMenu.Add(menu);
            }
        }
    }
}