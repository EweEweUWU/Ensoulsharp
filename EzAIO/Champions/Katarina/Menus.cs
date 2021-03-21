using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Champions.Katarina.Configs;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Katarina.Katarina;
namespace EzAIO.Champions.Katarina
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
                MiscellaneousMenu.DetectLanded,
                MiscellaneousMenu.Magnet,
                MiscellaneousMenu.SmartSaveBool
                
            };
            var comboMenu = new Menu("Combo", "Combo")
            {
                ComboMenu.ComboList,
                ComboMenu.QBool,
                ComboMenu.WBool,
                ComboMenu.EBool,
                ComboMenu.ESaveBool,
                ComboMenu.FollowBool,
                ComboMenu.EModeList,
                new MenuSeparator("sep1", "Smart: If R is Ready then cast Infront. If R i not Ready cast Behind"),
                ComboMenu.RModeList,
                ComboMenu.RSlider,
                ComboMenu.RCancelBool
            };
            ComboMenu.ComboList.Permashow();
            var harassMenu = new Menu("Harass", "Harass")
            {
                HarassMenu.HarassModeList,
                HarassMenu.QBool,
                HarassMenu.WBool,
                HarassMenu.EBool,
                HarassMenu.ESaveBool,
                HarassMenu.EModeList
            };
            var killstealMenu = new Menu("Killsteal", "Kill Steal")
            {
                KillstealMenu.QBool,
                KillstealMenu.EBool,
                KillstealMenu.EGapBool,
                KillstealMenu.RCancelBool
            };
            var laneclearMenu = new Menu("Laneclear", "Lane Clear")
            {
                LaneclearMenu.FarmToggleKey,
                LaneclearMenu.QBool,
                LaneclearMenu.WSliderButton,
                LaneclearMenu.ESliderButton,
                LaneclearMenu.ETurretBool
            };
            LaneclearMenu.FarmToggleKey.Permashow();
            var jungleclearMenu = new Menu("Jungleclear", "Jungle Clear")
            {
                JungleclearMenu.QBool,
                JungleclearMenu.WBool,
                JungleclearMenu.EBool
            };
            var lasthitMenu = new Menu("Lasthit", "Last Hit")
            {
                LasthitMenu.QBool
            };
            var fleeMenu = new Menu("Flee", "Flee")
            {
                FleeMenu.WBool,
                FleeMenu.EBool
            };
            var drawMenu = new Menu("Draw", "Draw")
            {
                DrawMenu.QBool,
                DrawMenu.EBool,
                DrawMenu.RBool,
                DrawConfig.DrawDaggerBool
            };
            var menuList = new[]
            {
                miscellaneousMenu,
                comboMenu,
                harassMenu,
                killstealMenu,
                laneclearMenu,
                jungleclearMenu,
                lasthitMenu,
                //fleeMenu,
                drawMenu
            };
            foreach (var menu in menuList)
            {
                mainMenu.Add(menu);
            }
        }
    }
}