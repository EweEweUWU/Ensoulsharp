using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Kaisa.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Kaisa.Kaisa;
namespace EzAIO.Champions.Kaisa
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
                MiscellaneousMenu.EBool
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.WSliderButton,
                ComboMenu.WRange,
                ComboMenu.WList,
                ComboMenu.EBool,
                new MenuSeparator("sep1","R is manual")
            };
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.WSliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.WBool
            };
            var laneClearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton,
                LaneclearMenu.ESliderButton,
                new Menu("custom", "Customization")
                {
                    LaneclearMenu.QCount
                }
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.WSliderButton,
                JungleclearMenu.ESliderButton
            };
            var structureclearMenu = new Menu("Structureclear", "Structure Clear")
            {
                StructureclearMenu.ESliderButton,
                StructureclearMenu.ERange
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.QBool,
                DrawMenu.WBool,
                DrawMenu.RBool
            };
            var menuList = new[]
            {
                miscellaneousMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneClearMenu,
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