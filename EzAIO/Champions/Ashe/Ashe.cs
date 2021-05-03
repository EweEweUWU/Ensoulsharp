using System;
using System.Drawing;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Champions.Ashe.Modes;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Bases.DrawingBase;

namespace EzAIO.Champions.Ashe
{
    sealed class Ashe : ChampionBases
    {
        public static AIHeroClient Player = GameObjects.Player;

        public Ashe()
        {
            new Menus();
        }

        public static Menu mainMenu;

        public static void OnGameLoad()
        {
            if (Player.IsDead)
            {
                return;
            }

            Q = new Spell(SpellSlot.Q);
            W = new Spell(SpellSlot.W,1200f);
            W.SetSkillshot(.25f,80f,2000f,true,SpellType.Cone);
            R = new Spell(SpellSlot.R, 4000);
            R.SetSkillshot(1f,125f,1600f,false,SpellType.Line);
            mainMenu = new Menu("Ashe", "[EzAIO] EzAshe", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Orbwalker.OnAfterAttack += OnAfterAttack;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (DrawMenu.QBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,Q.Range,Color.Cyan);
            }
            if (DrawMenu.WBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,W.Range,Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,AutomaticMenu.RrangeSlider.Value,Color.Cyan);
            }
        }

        private static void OnAfterAttack(object sender, AfterAttackEventArgs args)
        {
            if (Player.IsDead)
            {
                return;
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.LaneClear:
                    var target = args.Target as AIMinionClient;
                    if (target == null)
                    {
                        return;
                    }

                    if (target.Health <= Player.GetAutoAttackDamage(target) * 3)
                    {
                        return;
                    }
                    if (Q.IsReady())
                    {
                        Jungleclear.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Jungleclear.CastW(args);
                    }
                    break;
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (Player.IsDead)
            {
                return;
            }

            if (R.IsReady())
            {
                Combo.SemiRCast();
                Automatic.CastR();
                Killsteal.CastR();
            }

            if (W.IsReady())
            {
                Killsteal.CastW();
            }
            
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (Q.IsReady())
                    {
                        Combo.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Combo.CastW();
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (Q.IsReady())
                    {
                        Harass.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Harass.CastW();
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    if (Q.IsReady())
                    {
                        Laneclear.CastQ();
                    }
                    break;
            }
        }
    }
}