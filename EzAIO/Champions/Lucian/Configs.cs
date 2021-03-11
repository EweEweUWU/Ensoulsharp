using EnsoulSharp.SDK.MenuUI;
namespace EzAIO.Champions.Lucian
{
    public static class Configs
    {
        public static class MiscellaneousMenu
        {
            public static readonly MenuBool NoOutAARangeBool =
                new MenuBool("nooutaarange", "Don't use E out of AA range from enemies");

            public static readonly MenuBool OnlyEifMouseOutAARangeBool =
                new MenuBool("onlyifoutaarange", "Only E if mouse out of self AA Range", false);

            public static readonly MenuBool NoTurret =
                new MenuBool("noturret", "Don't use E under Enemy Turret");
        }
        public static class ComboMenu
        {
            public static readonly MenuList ComboList =
                new MenuList("mode", "Combo Mode", new[] {"Q -> E", "E -> Q"}, 1);

            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuList EMode =
                new MenuList("eMode", "E Mode", new[] {"Dynamic Range", "Always Short", "Always Long", "Don't use E"});

            public static readonly MenuBool Estart =
                new MenuBool("eStart", "^ Use E to Engage",false);

            public static readonly MenuBool Rbool =
                new MenuBool("r", "Use R if all spells on CD",false);

            public static readonly MenuKeyBind RSemi =
                new MenuKeyBind("rsemiauto", "R Semi Automatic Cast", Keys.T, KeyBindType.Press);
        }

        public static class HarassMenu
        {
            public static readonly MenuSliderButton QnormalSlider =
                new MenuSliderButton("qNormal", "Use Normal Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton QextendSlider =
                new MenuSliderButton("qExtended", "Use Extended Q", 50, 1, 100);

            public static readonly MenuSliderButton WSlider =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);
        }

        public static class KillstealMenu
        {
            public static readonly MenuBool QnormalBool =
                new MenuBool("qNormal", "Use Normal Q");

            public static readonly MenuBool QextendedBool =
                new MenuBool("qExtended", "Use Extended Q");

            public static readonly MenuBool WBool =
                new MenuBool("w", "Use W");
        }

        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSlider =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton QCount =
                new MenuSliderButton("qCount", "Use Q if minions to hit >= x", 3, 1, 7);

            public static readonly MenuSliderButton WSlider =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton WCount =
                new MenuSliderButton("wCount", "Use W if minions to hit >= x", 3, 1, 7);
            
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSlider =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton WSlider =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 30, 1, 100);

            public static readonly MenuSliderButton ESlider =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 30, 1, 100);
        }
        public static class StructureclearMenu
        {
            public static readonly MenuSliderButton WSlider =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 00);

            public static readonly MenuSliderButton ESlider =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }
        
        public static class DrawConfig
        {
            public static readonly MenuBool QextendRange =
                new MenuBool("qExtendedRange", "Extended Q Range");
        }
    }
}