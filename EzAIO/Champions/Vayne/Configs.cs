using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Vayne
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuSliderButton EsSliderButton =
                new MenuSliderButton("e", "Use E to self-peel | If Health <= x%",50, 1, 100);
        }
        public static class MiscellaneousMenu
        {
            public static readonly MenuBool Q3stackBool =
                new MenuBool("qStack", "Use Q only to proc 3rd W Stack", false);

            public static readonly MenuBool NoQAAEnemiesBool =
                new MenuBool("noQAAenemies", "Don't use Q out of AA range from Enemies");

            public static readonly MenuBool QIfMouseOutAABool =
                new MenuBool("qMouse", "Only Q if mouse out of self AA range", false);

            public static readonly MenuSliderButton QrangeCheckBool =
                new MenuSliderButton("qRangecheck", "Don't Q if X enemies near dash position", 3, 2, 5);

            public static readonly MenuBool QTurretBool =
                new MenuBool("qTurret", "Don't Q under enemy Turret");

        }
        public static class ComboMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool("q", "Use Q");

            public static readonly MenuList QList =
                new MenuList("qList", "Q Mode ", new[] {"Classic", "Safe"});

            public static readonly MenuBool QEngageBool =
                new MenuBool("qEngage", "^ Use Q to Engage", false);

            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
            
            public static MenuKeyBind ESmiKeybind =
                new MenuKeyBind("eSemi", "E Semi-Auto Cast", Keys.E, KeyBindType.Press);
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton EsSliderButton =
                new MenuSliderButton("e", "Use E to proc 3rd W Stack | If Mana >= x%", 50, 1, 100);
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");

            public static readonly MenuBool EAA =
                new MenuBool("eAA", "^ Include Last AA");
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);
        }
        public static class LasthitMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);
        }
        public static class StructureclearMenu
        {
            public static readonly MenuSliderButton QSliderButton =
                new MenuSliderButton("q", "Use Q | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton NoEnemiesSliderButton =
                new MenuSliderButton("qRange", "^ Only if no enemies in range", 1400, 1200, 2000);
        }
        public static class DrawConfig
        {
            public static readonly MenuBool Eposition =
                new MenuBool("ePos", "Draw E Precition");
        }
        
    }
}