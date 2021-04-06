using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Tristana.Tristana;
namespace EzAIO.Champions.Tristana
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
                //AutomaticMenu.AntiGrabBool,
                AutomaticMenu.RPeelSliderButton
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
                ComboMenu.EBool,
                ComboMenu.RSemiCastBool
            };
            ComboMenu.RSemiCastBool.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.ESliderButton
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.RBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.QSliderButton,
                LaneclearMenu.ESliderButton,
                new Menu("customization","Customization")
                {
                    LaneclearMenu.EMinionSlider
                }
            };
            var lasthitMenu = new Menu("Lasthit", "Last Hit")
            {
                LasthitMenu.QSliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleClearMenu.QSliderButton,
                JungleClearMenu.ESliderButton
            };
            var structureclearMenu = new Menu("Structureclear", "Structure Clear")
            {
                StructureclearMenu.QSliderButton,
                StructureclearMenu.ESliderButton,    
                new Menu("customization","Customization")
                {
                    StructureclearMenu.NoEnemiesRange,
                }
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool
            };
            var menuLsit = new[]
            {
                automaticMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneclearMenu,
                lasthitMenu,
                jungleclearMenu,
                structureclearMenu,
                drawMenu
            };
            foreach (var menu in menuLsit)
            {
                mainMenu.Add(menu);
            }
        }
    }
}