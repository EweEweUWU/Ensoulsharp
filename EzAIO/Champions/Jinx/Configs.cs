using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Jinx
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuBool WCCBool =
                new MenuBool("w", "Use W on CC Targets");

            public static readonly MenuBool ECCBool =
                new MenuBool("e", "Use E on CC Targets");

            public static readonly MenuBool ETeleportBool =
                new MenuBool("eTeleport", "Use E on Teleport");
        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Switch Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool PBool =
                new MenuBool("p", "^ Only if passive is not active");

            public static readonly MenuBool EnemiesBool =
                new MenuBool("enemies", "^ Only if no enemies in Q Range");

            public static readonly MenuBool EKey =
                new MenuBool("ekey", "Use E");

            public static readonly MenuKeyBind Rkey =
                new MenuKeyBind("r", "Semi-Cast R", Keys.T, KeyBindType.Press);
            public static readonly MenuSlider RSliderRange =
                new MenuSlider("rRange", "Set R range", 1600, 1500, 2500);

            public static readonly MenuBool RSafeBool =
                new MenuBool("rSafe", "^ Only if no enemies in Q Range");
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x&", 50, 1, 100);

            public static readonly MenuBool EnemiesBool =
                new MenuBool("enemies", "^ Only if no enemies in Q Range");
        }
        public static class KillstealMenu
        {
            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If enemy coumt in Q Range <= x", 0, 0, 5, false);

            public static readonly MenuSliderButton RSliderButton =
                new MenuSliderButton("r", "Use R | If enemy count in Q Range <= x", 0, 0, 5, false);
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider QCountSlider =
                new MenuSlider("qCount", "^ If killable Minions >= x", 3, 1, 5);

            public static readonly MenuBool SwapBool =
                new MenuBool("swap", "Allow swaping Q");
        }
        public static class LasthitMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 30, 1, 100);
        }
        public static class DrawConfig
        {
            public static readonly MenuBool QRRange =
                new MenuBool("q", "Draw Q Rocket Range");
        }
    }
}