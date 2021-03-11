using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Bases;
using EzAIO.Champions.Lucian.Modes;
using static EzAIO.Champions.Lucian.Configs;

namespace EzAIO.Champions.Lucian
{
    using static DrawingBase;
    sealed class Lucian : ChampionBases
    {
        public Lucian()
        {
            new Menus();
        }

        public static Menu mainMenu;
        public static Spell ExtendedQ { get; private set; }

        public static void OnGameLoad()
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }

            Q = new Spell(SpellSlot.Q, 500f + GameObjects.Player.BoundingRadius);
            ExtendedQ = new Spell(SpellSlot.Q, 1000f - GameObjects.Player.BoundingRadius);
            ExtendedQ.SetSkillshot(.25f,65f,float.MaxValue,false,SpellType.Line);
            W = new Spell(SpellSlot.W, 900f);
            W.SetSkillshot(.25f,80f,1600f,true,SpellType.Line);
            E = new Spell(SpellSlot.E, GameObjects.Player.GetRealAutoAttackRange() + 425f);
            R = new Spell(SpellSlot.R, 1150f);
            R.SetSkillshot(.25f,120f,2500f,true,SpellType.Line);
            mainMenu = new Menu("Lucian", "[EzAIO] EzLucian", true);
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
                    switch (ComboMenu.ComboList.Index)
                    {
                        case 0:
                            if (Q.IsReady())
                            {
                                if (Extra.CastQ(args))
                                {
                                    return;
                                }
                            }

                            if (E.IsReady() && Extension.CanCastE(args.Target) &&
                                ComboMenu.EBool.Enabled)
                            {
                                if (Extra.CastE())
                                {
                                    return;
                                }
                            }
                            break;
                        case 1:
                            if (E.IsReady() &&
                                Extension.CanCastE(args.Target) &&
                                ComboMenu.EBool.Enabled)
                            {
                                if (Extra.CastE())
                                {
                                    return;
                                }
                            }

                            if (Q.IsReady())
                            {
                                if (Extra.CastQ(args))
                                {
                                    return;
                                }
                            }
                            break;
                    }

                    if (W.IsReady())
                    {
                        Extra.CastW(args);
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    var target = args.Target as AIMinionClient;
                    if (E.IsReady())
                    {
                        Jungleclear.CastE();
                        Structureclear.CastE(args);
                        return;
                    }

                    if (Q.IsReady())
                    {
                        Jungleclear.CastQ(args);
                        
                    }

                    if (W.IsReady())
                    {
                        Jungleclear.CastW(args);
                        Structureclear.CastW(args);
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
            Combo.SemiR();
            Killsteal.Cast();

            if (Extension.IsCulling())
            {
                if (ComboMenu.Rbool.Enabled &&
                    (Q.IsReady() || W.IsReady() || E.IsReady()) &&
                    GameObjects.EnemyHeroes.Any(x => x.IsValidTarget(GameObjects.Player.GetRealAutoAttackRange(x))))
                {
                    R.Cast();
                }
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (E.IsReady())
                    {
                        Combo.CastE();
                    }

                    if (R.IsReady())
                    {
                        Combo.CastR();
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    if (Q.IsReady())
                    {
                        Laneclear.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Laneclear.CastW();
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (Q.IsReady())
                    {
                        Harass.CastQ();
                        Harass.CastExtendedQ();
                    }

                    if (W.IsReady())
                    {
                        Harass.CastW();
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
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,R.Range,System.Drawing.Color.Cyan);
            }

            if (DrawConfig.QextendRange.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,ExtendedQ.Range,System.Drawing.Color.Red);
            }
        }
    }
}