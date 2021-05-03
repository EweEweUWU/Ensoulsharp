using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;
using static EzAIO.Developer.Configs;
using static EzAIO.Program;
using Color = System.Drawing.Color;

namespace EzAIO.Developer
{
    public static class Developer
    {
        public static AIBaseClient Player = GameObjects.Player;

        public static void OnGameLoad()
        {
            if (Player.IsDead)
            {
                return;
            }

            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (BuffMenu.MyBuffBool.Enabled)
            {
                var x = Drawing.WorldToScreen(Player.Position).X;
                var y = Drawing.WorldToScreen(Player.Position).Y;
                var buff = Player.Buffs;
                if (buff.Any())
                {
                    Drawing.DrawText(x,y+120,System.Drawing.Color.White,"Buffs: ");
                }

                for (var i = 0; i < buff.Length * 10; i += 10)
                {
                    Drawing.DrawText(x+40,(y+120+i),Color.Cyan, buff[i/10].Count+"X "+buff[i/10].Name);
                }
            }
        }
    }
}