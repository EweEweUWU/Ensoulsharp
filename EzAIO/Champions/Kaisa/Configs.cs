using EnsoulSharp.SDK.MenuUI;
namespace EzAIO.Champions.Kaisa
{
    public static class Configs
    {
        public static class MiscellaneousMenu
        {
            public static readonly MenuBool EBool =
                new MenuBool("e2", "Use E only if its evolved");
        }

        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Passive stacks >= x ", 3, 0, 4);

            public static readonly MenuSliderButton WRange =
                new MenuSliderButton("wRange", "Don't cast W in x range", 600, 550, 700);

            public static readonly MenuList WList =
                new MenuList("wmode", "W Mode", new[] {"After Attack", "Based on Stacks", "Always"}, 1);

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
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
            public static MenuBool WBool =
                new MenuBool("w", "Use W");
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100,false);

            public static readonly MenuSliderButton QCount =
                new MenuSliderButton("qCount", "Use Q | If Minions in range >= x", 3, 1, 5);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 30, 1, 100);
        }
        public static class StructureclearMenu
        {
            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ERange =
                new MenuSliderButton("eRange", "^ Only if no enemies in range", 1400, 1200, 2000);
        }
    }
}