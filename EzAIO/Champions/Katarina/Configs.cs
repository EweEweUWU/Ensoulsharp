using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Katarina
{
    public static class Configs
    {
        public static class MiscellaneousMenu
        {
            public static readonly MenuBool DetectLanded =
                new MenuBool("detectLanded", "Detect only Landed Daggers", false);

            public static readonly MenuBool Magnet =
                new MenuBool("magnet", "Magnet to Daggers", false);

            public static readonly MenuBool SmartSaveBool =
                new MenuBool("save", "Smart save if Hero under Enemy Turret");
        }

        public static class ComboMenu
        {
            public static readonly MenuList ComboList =
                new MenuList("mode", "Combo Mode", new[] {"Q > E", "E > Q"}, 0);

            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool ESaveBool =
                new MenuBool("eSave", "E Only for Daggers", false);

            public static readonly MenuList EModeList =
                new MenuList("eMode", "E Mode", new[] {"Infront", "Behind", "Smart"}, 0);

            public static readonly MenuList RModeList =
                new MenuList("rMode", "R Usage", new[] {"If X Health", "If Killable", "Never"},0);

            public static readonly MenuSlider RSlider =
                new MenuSlider("rHealth", "^ If Enemy <= X Health", 50, 1, 100);

            public static readonly MenuBool RCancelBool =
                new MenuBool("rCancel", "Cancel R if no Enemies");

            public static readonly MenuBool FollowBool =
                new MenuBool("follow", "Follow up Enemy if running out R range");
        }
        public static class HarassMenu
        {
            public static readonly MenuList HarassModeList =
                new MenuList("hMode", "Harass Mode", new[] {"Q > E", "E > Q"}, 0);

            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool ESaveBool =
                new MenuBool("eSave", "E Only for Daggers", false);
            public static readonly MenuList EModeList =
                new MenuList("eMode", "E Mode", new[] {"Infront", "Behind", "Smart"}, 0);
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool EGapBool =
                new MenuBool("eGap", "Use E to Gapcloser for Q");

            public static readonly MenuBool RCancelBool =
                new MenuBool("r", "Cancel R for Kill Steal");
        }
        public static class LaneclearMenu
        {
            public static readonly MenuKeyBind FarmToggleKey =
                new MenuKeyBind("farmkey", "Farm Toggle", Keys.A, KeyBindType.Toggle);

            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Minions hit >= X", 3, 1, 7);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Minions hit >= X", 3, 1, 7);

            public static readonly MenuBool ETurretBool =
                new MenuBool("eTurret", "Don't use E under Enemy Turret");
        }
        public static class JungleclearMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
        }
        public static class LasthitMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");
        }
        public static class FleeMenu
        {
            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
        }

        public static class DrawConfig
        {
            public static readonly MenuBool DrawDaggerBool =
                new MenuBool("dagger", "Draw Dagger");
        }
    }
}