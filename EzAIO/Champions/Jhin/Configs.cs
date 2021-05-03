using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Jhin
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuBool ECCBool =
                new MenuBool("e", "E on CC targets");

            public static readonly MenuBool ETeleportBool =
                new MenuBool("eTeleport", "E on Teleport");
        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool QReloadBool =
                new MenuBool("qReload", "^ Only when Reloading");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool WRangeBool =
                new MenuBool("wRange", "^ Only when no Enemies in AA Range");

            public static readonly MenuBool WCCBool =
                new MenuBool("wCC", "^ Only if Enemy Slowed or CC",false);

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool EReloadBool =
                new MenuBool("eReload", "^ Only when Reloading");

            public static readonly MenuBool RBool =
                new MenuBool("r", "Use R");

            public static readonly MenuBool RCursor =
                new MenuBool("rCursor", "^ Focus enemy nearest to your Cursor");
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool RShoot =
                new MenuBool("r", "Auo Shoot R to kill");
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | IF Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider QSlider =
                new MenuSlider("qMinions", "Use Q if minions around >= x", 3, 1, 5);

            public static readonly MenuSlider WSlider =
                new MenuSlider("wMinions", "Use W if can hit >= x minions", 3, 1, 5);

            public static readonly MenuSlider ESlider =
                new MenuSlider("eMinions", "Use E if minions around >= x", 3, 1, 5);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 30, 1, 100);
        }
        public static class LasthitMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuBool QReloadBool =
                new MenuBool("qReload", "^ Only when Reloading");
        }
        public static class DrawConfig
        {
            public static readonly MenuBool DrawRConeBool =
                new MenuBool("r", "Draw R Cone");
        }
    }
}