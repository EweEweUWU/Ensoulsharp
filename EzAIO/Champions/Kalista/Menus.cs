using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
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
            var automaticMenu = new Menu("Automatic", "Automatic Settings")
            {
                AutomaticMenu.RAllysave,
                AutomaticMenu.WDrake,
                AutomaticMenu.WBaron,
                AutomaticMenu.MinionsChase
            };
            var comboMenu = new Menu("Combo", "Combo Settings")
            {
                ComboMenu.QBool,
            };
            var harassMenu = new Menu("Harass", "Harass Settings")
            {
                HarassMenu.QSliderButton,
                HarassMenu.ESliderButton
            };
            var killStealMenu = new Menu("Killsteal", "Killsteal Settings")
            {
                KillstealMenu.QSBool,
                KillstealMenu.EBool
            };
            var laneClearMenu = new Menu("Laneclear", "Laneclear Settings")
            {
                Laneclear.ESliderButton,
                Laneclear.Eminion,
                Laneclear.EBool
            };
            var lastHitMenu = new Menu("LastHit", "Lasthit Settings")
            {
                Lasthit.ESliderButton
            };
            var jungleclearMenu = new Menu("Jungleclear", "JungleClear Settings")
            {
                Jungleclear.QSliderButton,
                Jungleclear.ESliderButton
            };
            var drawMenu = new Menu("Draw", "Draw Settings")
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