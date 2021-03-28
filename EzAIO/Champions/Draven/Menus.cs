using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Draven.Draven;
namespace EzAIO.Champions.Draven
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
                MiscellaneousMenu.RRangeSlider,
                MiscellaneousMenu.WaitAxeBool,
                MiscellaneousMenu.MagnetToMarkSliderButton,
                MiscellaneousMenu.MagnetRangeSliderButton,
                MiscellaneousMenu.BlockMovementBool
            };
            var automaticMenu = new Menu("Automatic", "Automatic")
            {
                AutomaticMenu.WSlowedBool,
                AutomaticMenu.RImmobileBool
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBoolSliderButton,
                ComboMenu.WBool,
                ComboMenu.EBool,
                ComboMenu.RKey
            };
            ComboMenu.RKey.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.QAxesSlider,
                HarassMenu.WSliderButton,
                HarassMenu.EsSliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.EBool,
                KillstealMenu.RBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton,
                LaneclearMenu.QAxesSlider,
                LaneclearMenu.WSliderButton,
                LaneclearMenu.ESliderButton,
                new Menu("customization", "Customization")
                {
                    LaneclearMenu.WCountSlider,
                    LaneclearMenu.ECountSlider
                }
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSliderButton,
                JungleclearMenu.QAxesSlider,
                JungleclearMenu.WSliderButton
            };
            var structureclearMenu = new Menu("Structureclear", "Structure Clear")
            {
                StructureclearMenu.WSliderButton,
                StructureclearMenu.WRangeSliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.EBool,
                DrawMenu.RBool,
                new Menu("extra", "Extra Draw")
                {
                    DrawConfig.PlayerMagnetRangeBool,
                    DrawConfig.MouseMagnetRangeBool,
                    DrawConfig.MarkBoudingRadiusBool,
                    DrawConfig.MarkOrderBool,
                    DrawConfig.MarkExpireTimeBool
                }
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