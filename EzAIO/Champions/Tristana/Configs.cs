using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Tristana
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            /*public static readonly MenuBool AntiGrabBool =
                new MenuBool("antigrab", "W to cancel Grabs");*/

            public static readonly MenuSliderButton RPeelSliderButton =
                new MenuSliderButton("rPeel", "Use R to self-peel | If player health <= x%", 10, 5, 100, false);
        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuKeyBind RSemiCastBool =
                new MenuKeyBind("r", "R Semi-Automatic Cast", Keys.T, KeyBindType.Press);
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool RBool =
                new MenuBool("r", "Use R");
        }

        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider EMinionSlider =
                new MenuSlider("eMinions", "^ If minions araound >= x", 3, 1, 5);
        }
        public static class LasthitMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);
        }
        public static class JungleClearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 30, 1, 100);
        }
        public static class StructureclearMenu
        {
            public static readonly MenuSliderButton NoEnemiesRange =
                new MenuSliderButton("noEnemies", "Only if no enemies in X range", 1200, 1000, 2000);

            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }
    }
}