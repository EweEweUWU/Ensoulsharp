using EnsoulSharp.SDK.MenuUI;

namespace EzAIO.Champions.Twitch
{
    public static class Configs
    {
        public static class AutomaticMenu
        {
            public static readonly MenuKeyBind Qsilent =
                new MenuKeyBind("back", "Silent back key", Keys.B, KeyBindType.Press);
        }

        public static class ComboMenu
        {
            public static readonly MenuList QList =
                new MenuList("q", "Q Mode", new[] {"Before AA", "Always", "Never"}, 2);

            public static readonly MenuBool WList =
                new MenuBool("w", "Use W");

            public static readonly MenuBool WBool =
                new MenuBool("wTurret", "^ Don't use if Player is under Turret");

            public static readonly MenuBool WRBool =
                new MenuBool("wr", "Don't use W if R is Active");

            public static readonly MenuSliderButton RSliderButton =
                new MenuSliderButton("r", "Use R | If Enemy count >= x", 2, 1, 5);
        }
        public static class HarassMenu
        {
            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%", 50, 1, 100);

            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%", 50, 1, 100);

            public static readonly MenuBool EBool =
                new MenuBool("eRange", "^ Only if target is out of AA range");
        }
        public static class KillstealMenu
        {
            public static readonly MenuBool EBool =
                new MenuBool("e", "Use E");
        }
        public static class LaneclearMenu
        {
            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | If Mana >= x%",50,1,100);

            public static readonly MenuSlider ESlider =
                new MenuSlider("eMinions", "^ Minions to Cast E", 3, 1, 7);
        }
        public static class JungleclearMenu
        {
            public static readonly MenuSliderButton WSliderButton =
                new MenuSliderButton("w", "Use W | If Mana >= x%",50,1,100);
            
            public static readonly MenuSliderButton ESliderButton =
                new MenuSliderButton("e", "Use E | IF Mana >= x%",50,1,100);
        }
        public static class DrawConfig
        {
            public static readonly MenuBool Edmg =
                new MenuBool("eDmg", "Draw E Damage on Champions");

            public static readonly MenuBool EDmgJG =
                new MenuBool("eDmgJG", "Draw E Damage on mobs");

            public static readonly MenuBool QTime =
                new MenuBool("qTime", "Show Q time");

            public static readonly MenuBool RTime =
                new MenuBool("rTime", "Show R time");
        }
    }
}