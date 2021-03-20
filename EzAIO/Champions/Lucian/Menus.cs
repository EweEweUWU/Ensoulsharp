using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Lucian.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Lucian.Lucian;
namespace EzAIO.Champions.Lucian
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
                new Menu("e","E Combo Customization")
                {
                    MiscellaneousMenu.NoOutAARangeBool,
                    MiscellaneousMenu.OnlyEifMouseOutAARangeBool,
                    MiscellaneousMenu.NoTurret
                }
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.ComboList,
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.EBool,
                ComboMenu.EMode,
                new MenuSeparator("sep1","^ Always directed to Cursor"),
                ComboMenu.Estart,
                ComboMenu.Rbool,
                ComboMenu.RSemi
                
            };
            ComboMenu.ComboList.Permashow();
            ComboMenu.EMode.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QnormalSlider,
                HarassMenu.QextendSlider,
                HarassMenu.WSlider
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.QnormalBool,
                KillstealMenu.QextendedBool,
                KillstealMenu.WBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSlider,
                LaneclearMenu.WSlider,
                new Menu("custom","Customization")
                {
                    LaneclearMenu.QCount,
                    LaneclearMenu.WCount
                }
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QSlider,
                JungleclearMenu.WSlider,
                JungleclearMenu.ESlider
            };
            var structureclearMenu = new Menu("Structureclear", "Structure Clear")
            {
                StructureclearMenu.WSlider,
                StructureclearMenu.ESlider
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.QBool,
                DrawConfig.QextendRange,
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool
            };
            var menuList = new[]
            {
                miscellaneousMenu,
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