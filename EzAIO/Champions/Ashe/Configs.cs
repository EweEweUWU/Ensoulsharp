using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Ashe
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuBool Rinmobile =
                new MenuBool("rInmobile", "Auto R to Inmobile targets",false);

            public static readonly MenuSlider RrangeSlider =
                new MenuSlider("rRange", "R custom Range", 1300, 1000, 4000);

            public static readonly MenuSliderButton NoEnemiesSliderButton =
                new MenuSliderButton("rEnemies", "Don't R if X Enemies is in W range", 1, 0, 6);
        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuKeyBind RSemiKeyBind =
                new MenuKeyBind("rSemi", "R Semi-Automatic Cast", Keys.T, KeyBindType.Press);

            public static readonly MenuBool DontWBool =
                new MenuBool("dontW", "Don't cast W while Q is actvie");
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool RBool =
                new MenuBool("r", "Use R", false);
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%",50,1,100);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 30, 1, 100);
        }
    }
}