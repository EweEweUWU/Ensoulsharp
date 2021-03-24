using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Champions.Kaisa.Modes;
namespace EzAIO.Champions.Kaisa
{
    using static DrawingBase;
    sealed class Kaisa : ChampionBases
    {
        public Kaisa()
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

            Q = new Spell(SpellSlot.Q, GameObjects.Player.GetRealAutoAttackRange() + GameObjects.Player.BoundingRadius);
            W = new Spell(SpellSlot.W, 3000f) {AddHitBox = true};
            W.SetSkillshot(.4f*4,100f,float.MaxValue,true,SpellType.Line);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R, 1500 + 750 * (GameObjects.Player.Spellbook.GetSpell(SpellSlot.R).Level -1));
            mainMenu = new Menu("Kaisa", "[EzAIO] EzKaisa", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Orbwalker.OnAfterAttack += OnAfterAttack;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnAfterAttack(object sender, AfterAttackEventArgs args)
        {
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    Extra.CastW(args);
                    break;
                case OrbwalkerMode.LaneClear:
                    var target = args.Target as AIMinionClient;
                    if (E.IsReady())
                    {
                        Jungleclear.CastE();
                        Structureclear.CastE(args);
                    }
                    if (W.IsReady())
                    {
                        if (target.IsJungle())
                        {
                            Jungleclear.CastW(args);
                        }
                    }
                    break;
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }
            Killsteal.Cast();
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (W.IsReady())
                    {
                        Combo.CastW();
                    }

                    if (E.IsReady())
                    {
                        Combo.CastE();
                    }

                    if (Q.IsReady())
                    {
                        Combo.CastQ();
                    }
                    break;
                case  OrbwalkerMode.Harass:
                    if (W.IsReady())
                    {
                        Harass.CastW();
                    }

                    if (Q.IsReady())
                    {
                        Harass.CastQ();
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    if (E.IsReady())
                    {
                        Laneclear.CastE();
                    }

                    if (Q.IsReady())
                    {
                        Laneclear.CastQ();
                        Jungleclear.CastQ();
                    }
                    break;
            }
        }

        private static void OnDraw(EventArgs args)
        {
            if (DrawMenu.QBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,Q.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.WBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,W.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,R.Range,System.Drawing.Color.Cyan);
            }
        }
    }
}