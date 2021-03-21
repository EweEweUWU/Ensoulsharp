using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Kalista
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuSliderButton RAllysave =
                new MenuSliderButton("save", "Auto save ally | If ally Health <= x%", 15, 0, 100);

            public static readonly MenuBool WDrake =
                new MenuBool("wDrake", "Auto W to Drake");

            public static readonly MenuBool WBaron =
                new MenuBool("WBaron", "Auto W to Baron");

            public static readonly MenuBool MinionsChase =
                new MenuBool("useminions", "Use Mnions to Chase");
        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 0, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("eharass", "Use E on minions to Harass | If Mana >= x%", 50, 1, 100);
        }

        public static class KillstealMenu
        {
            public static readonly MenuBool QSBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
        }
        public static class Laneclear
        {
            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider Eminion =
                new MenuSlider("Eminion", "^ Minions to cast E", 2, 1, 7);

            public static readonly MenuBool EBool =
                new MenuBool("nonkillable", "Use E on non killable Minions");

        }
        public static class Lasthit
        {
            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }

        public static class Jungleclear
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);

        }

        public static class DrawConfig
        {
            public static readonly MenuBool Edmg =
                new MenuBool("eDmg", "Draw E Damage on Champions");

            public static readonly MenuBool EDmgJG =
                new MenuBool("eDmgJG", "Draw E Damage on mobs");

            public static readonly MenuBool Ecircle =
                new MenuBool("ecircle", "Draw circle under killable minion", true);
        }
        
    }
}