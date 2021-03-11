using System;
using System.Drawing;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using static EzAIO.Program;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;
using Color = SharpDX.Color;

namespace EzAIO.Bases
{
    
    abstract class DrawingBase
    {
        protected DrawingBase()
        {
            //Drawing.OnDraw += OnDraw;
        }
        protected static Spell[] Spells { get; set; }

        public static class DrawMenu
        {
            public static readonly MenuBool QBool =
                new MenuBool($"{GameObjects.Player.CharacterName}.Qr", "Draw Q range", false);
            public static readonly MenuBool WBool =
                new MenuBool($"{GameObjects.Player.CharacterName}.Wr", "Draw W range", false);
            public static readonly MenuBool EBool =
                new MenuBool($"{GameObjects.Player.CharacterName}.Er", "Draw E range", false);
            public static readonly MenuBool RBool =
                new MenuBool($"{GameObjects.Player.CharacterName}.Rr", "Draw R range", false);
        }

        public static MenuBool getMenuBoolOf(SpellSlot slot)
        {
            MenuBool menuBool = null;
            switch (slot)
            {
                case SpellSlot.Q:
                    menuBool = DrawMenu.QBool;
                    break;
                case SpellSlot.W:
                    menuBool = DrawMenu.WBool;
                    break;
                case SpellSlot.E:
                    menuBool = DrawMenu.EBool;
                    break;
                case SpellSlot.R:
                    menuBool = DrawMenu.RBool;
                    break;
            }

            return menuBool;
        }

        public static void DrawCircle(Vector3 pos, float radius, System.Drawing.Color color)
        {
            Render.Circle.DrawCircle(pos,radius,color);
        }
    }
}