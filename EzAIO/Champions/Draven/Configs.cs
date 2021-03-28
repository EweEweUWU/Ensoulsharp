using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Draven
{
    public static class Configs
    {
        public static class MiscellaneousMenu
        {
            public static readonly MenuSlider RRangeSlider =
                new MenuSlider("rRange", "Custom R Range", 1500, 1500, 2000);

            public static readonly MenuBool WaitAxeBool =
                new MenuBool("waitAxe", "Don't AA if can catch Axe");

            public static readonly MenuSliderButton MagnetToMarkSliderButton =
                new MenuSliderButton("magnetMark", "Magnet to Marks | If Distance to Mouse <= x", 600, 350, 750);

            public static readonly MenuSliderButton MagnetRangeSliderButton =
                new MenuSliderButton("magnetRange", "^ Only if Range from player <= x", 600, 350, 750);

            public static readonly MenuBool BlockMovementBool =
                new MenuBool("blockMove", "Block Movement Logic", false);
        }

        public static class AutomaticMenu
        {
            public static readonly MenuBool WSlowedBool =
                new MenuBool("wSlow", "Auto W if Player Slowed");

            public static readonly MenuBool RImmobileBool =
                new MenuBool("rImmobile", "R on immobile targets", true);
        }
        public static class ComboMenu
        {
            public static readonly MenuSliderButton QBoolSliderButton =
                new MenuSliderButton("q", "Use Q | If Total Axes < x",2,1,4);

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuKeyBind RKey =
                new MenuKeyBind("r", "Semi-Automatic Cast R", Keys.T, KeyBindType.Press);
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider QAxesSlider =
                new MenuSlider("qAxes", "^ Only if Total Axes < x", 2, 1, 4);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton EsSliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }

        public static class KillstealMenu
        {
            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool RBool =
                new MenuBool("r", "Use R");
        }

        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSlider QAxesSlider =
                new MenuSlider("qAxes", "^ Only if Total Axes < x", 2, 1, 4);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100,false);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100,false);

            public static readonly MenuSlider WCountSlider =
                new MenuSlider("wCount", "Use W if Minions near >= x", 3, 1, 5);

            public static readonly MenuSlider ECountSlider =
                new MenuSlider("eCount", "Use E if Minions hittable >= x", 5, 1, 7);
        }

        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSlider QAxesSlider =
                new MenuSlider("qAxes", "^ Only if Total Axes < x", 2, 1, 4);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 30, 1, 100);
        }

        public static class StructureclearMenu
        {
            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton WRangeSliderButton =
                new MenuSliderButton("wRange", "^ Only if no enemies in range", 1400, 1700, 2000);
        }

        public static class DrawConfig
        {
            public static readonly MenuBool PlayerMagnetRangeBool =
                new MenuBool("playerMagnet", "Draw Player Magnet Range");

            public static readonly MenuBool MouseMagnetRangeBool =
                new MenuBool("mouseMagnet", "Draw Mouse Magnet Range");

            public static readonly MenuBool MarkBoudingRadiusBool =
                new MenuBool("markbouding", "Draw Marks BoudingRadius");

            public static readonly MenuBool MarkOrderBool =
                new MenuBool("markOrder", "Draw Mark Order");

            public static readonly MenuBool MarkExpireTimeBool =
                new MenuBool("expireTime", "Draw Mark expire Time");
        }
    }
}