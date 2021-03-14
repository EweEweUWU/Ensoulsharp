using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Kalista.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Kalista.Kalista;
namespace EzAIO.Champions.Kalista
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
                AutomaticMenu.RAllysave,
                AutomaticMenu.WDrake,
                AutomaticMenu.WBaron,
                AutomaticMenu.MinionsChase
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.QBool,
            };
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.QSliderButton,
                HarassMenu.ESliderButton
            };
            var killStealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.QSBool,
                KillstealMenu.EBool
            };
            var laneClearMenu = new Menu("Laneclear", "Lane Clear")
            {
                Laneclear.ESliderButton,
                Laneclear.Eminion,
                Laneclear.EBool
            };
            var lastHitMenu = new Menu("LastHit", "Last Hit")
            {
                Lasthit.ESliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                Jungleclear.QSliderButton,
                Jungleclear.ESliderButton
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.QBool,
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool,
                DrawConfig.Edmg,
                DrawConfig.EDmgJG,
                DrawConfig.Ecircle
            };
            var menuList = new[]
            {
                automaticMenu,
                comboMenu,
                harassMenu,
                killStealMenu,
                laneClearMenu,
                lastHitMenu,
                jungleclearMenu,
                drawMenu
            };
            foreach (var menu in menuList)
            {
                maineMenu.Add(menu);
            }
        }
    }
}