using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Ezreal.Ezreal;

namespace EzAIO.Champions.Ezreal
{
    class Menus
    {
        public Menus()
        {
            Initialize();
        }

        public static void Initialize()
        {
            //Automatic
            var AutomaticMenu = new Menu("Automatic", "Automatic Settings");
            AutomaticMenu.Add(new MenuSliderButton("q", "Automatically use Q | If Mana >= x%", 85, 1, 100, true));
            AutomaticMenu.Add(new MenuBool("immobile", "R on immobile targets", true));
            AutomaticMenu.Add(new MenuSliderButton("distance", "Only if distance to player >= x", 1200, 1200, 2000, true));
            AutomaticMenu.Add(new MenuSliderButton("safe", "Only if no enemies in range", 1100, 1100, 2000, true));
            AutomaticMenu.Add(new MenuSlider("rRange", "Custom R range", 2500, 1500, 5000));
            //Combo
            var ComboMenu = new Menu("Combo", "Combo Settings");
            ComboMenu.Add(new MenuBool("q", "Use Q"));
            ComboMenu.Add(new MenuBool("w", "Use W"));
            ComboMenu.Add(new MenuSliderButton("priority", "Always priorize Q | If Mana <= x%", 35, 1, 100, true));
            ComboMenu.Add(new MenuKeyBind("rsemiautomatic", "R Semi-Automatic Cast", Keys.T, KeyBindType.Press));
            //Harass
            var HarassMenu = new Menu("Harass", "Harass Settings");
            HarassMenu.Add(new MenuSliderButton("q", "Use Q | If Mana <= x%", 50, 1, 100, true));
            HarassMenu.Add(new MenuSliderButton("w", "Use W | If Mana <= x%", 50, 1, 100, true));
            //Killsteal
            var KillstealMenu = new Menu("Killsteal","Killsteal Setting");
            KillstealMenu.Add(new MenuBool("q", "Use Q"));
            KillstealMenu.Add(new MenuBool("r", "Use R"));
            //LaneClear
            var LaneClear = new Menu("LaneClear", "LaneClear Settings");
            LaneClear.Add(new MenuSliderButton("q", "Use Q | If Mana <= x%", 50, 10, 100));
            LaneClear.Add(new MenuBool("killable", "^ Only if minions is killable"));
            //JungleClear
            var Jungleclear = new Menu("Jungleclear", "JungleClear Settigna");
            Jungleclear.Add(new MenuSliderButton("q", "Use Q | If Mana <= x%", 50, 1, 100));
            Jungleclear.Add(new MenuSliderButton("w", "Use W | If Mana <= x%", 50, 1, 100));
            //StructureClear
            var Structureclear = new Menu("structure", "Structure clear Settings");
            Structureclear.Add(new MenuSliderButton("w", "Use W | If Mana <= x%", 50, 1, 100));
            Structureclear.Add(new MenuSliderButton("safe", "^ Only if no enemies in range", 1400, 1200, 2000));
            Structureclear.Add(new MenuSliderButton("allies", "^ Despite allies count nearby >? x", 1, 1, 4));
            //Lasthit
            var Lasthit = new Menu("Lasthit", "LastHit Settings");
            Lasthit.Add(new MenuSliderButton("q", "Use Q | If Mana <= x%", 50, 1, 100));
            //Draw
            var Draw = new Menu("Draw", "Drawing Settings")
            {
                DrawMenu.QBool,
                DrawMenu.WBool,
                DrawMenu.EBool,
                DrawMenu.RBool
            };
            
            var menuList = new[]
            {
                AutomaticMenu,
                ComboMenu,
                HarassMenu,
                KillstealMenu,
                LaneClear,
                Jungleclear,
                Structureclear,
                Lasthit,
                Draw
            };
            foreach (var menu in menuList)
            {
                mainMenu.Add(menu);
            }
        }
    }
    
}