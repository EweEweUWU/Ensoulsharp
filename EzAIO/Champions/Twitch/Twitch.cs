using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Champions.Twitch.Modes;
using static EzAIO.Program;
using static EzAIO.Bases.DrawingBase;

namespace EzAIO.Champions.Twitch
{
    sealed class Twitch : ChampionBases
    {
        public Twitch()
        {
            new Menus();
        }

        public static Menu mainMenu;
        public static void OnGameLoad()
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }

            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W,950f);
            E = new Spell(SpellSlot.E, 1200f);
            R = new Spell(SpellSlot.R, 850f);
            mainMenu = new Menu("Twitch", "[EzAIO] EzTwitch", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            Render.OnDraw += OnDraw;
            Render.OnEndScene += OnEndScene;
        }

        private static void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            if (Orbwalker.ActiveMode == OrbwalkerMode.Combo)
            {
                Combo.CastQ(args);
            }
            
        }

        private static void OnGameUpdate(EventArgs args)
        {
            Automatic.CastQ();
            Killsteal.CastE();
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    Combo.CastQ();
                    Combo.CastW();
                    Combo.CastR();
                    break;
                case  OrbwalkerMode.Harass:
                    Harass.CastW();
                    Harass.CastE();
                    break;
                case OrbwalkerMode.LaneClear:
                    Laneclear.CastE();
                    Jungleclear.CastW();
                    Jungleclear.CastE();
                    break;
            }
        }
        
        
        private static void OnDraw(EventArgs args)
        {
            if (DrawMenu.WBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,W.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,R.Range,System.Drawing.Color.Cyan);
            }
            //Ported from EntropyAIO. all credits to their oficcial owners
            var pos = Drawing.WorldToScreen(GameObjects.Player.Position);
            if (Configs.DrawConfig.QTime.Enabled)
            {
                var buff = GameObjects.Player.GetBuff("TwitchHideInShadows");
                if (buff != null)
                {
                    var timer = buff.EndTime - Game.Time;
                    DrawText(TextBold,$"Stealh: {timer:N1}",pos.X,pos.Y+100,SharpDX.Color.White);
                }
            }

            if (Configs.DrawConfig.RTime.Enabled)
            {
                var buff = GameObjects.Player.GetBuff("TwitchFullAutomatic");
                if (buff != null)
                {
                    var timer = buff.EndTime - Game.Time;
                    DrawText(TextBold,$"Ultimate: {timer:N1}",pos.X,pos.Y+50,SharpDX.Color.White);
                }
            }
            //
        }
        private static void OnEndScene(EventArgs args)
        {
            if (Configs.DrawConfig.Edmg.Enabled)
            {
                DamageIndicator.EChamps();
            }

            if (Configs.DrawConfig.EDmgJG.Enabled)
            {
                DamageIndicator.EMobs();
            }
        }
    }
}