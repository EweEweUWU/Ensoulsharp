using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;
using EzAIO.Bases;
using EzAIO.Champions.Vayne.Modes;
using SharpDX;
using static EzAIO.Champions.Vayne.Configs;

namespace EzAIO.Champions.Vayne
{
    using static DrawingBase;
    sealed class Vayne : ChampionBases
    {
        public Vayne()
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

            Q = new Spell(SpellSlot.Q, GameObjects.Player.GetRealAutoAttackRange() + 300f);
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 550f + GameObjects.Player.BoundingRadius);
            E.SetSkillshot(.25f,65f,2200f,false,SpellType.None);
            mainMenu = new Menu("Vayne", "[EzAIO] EzVayne", true);
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
                    if (Q.IsReady())
                    {
                        Extra.CastQ(args);
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (Q.IsReady())
                    {
                        Harass.CastQ(args);
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    var target = args.Target as AIMinionClient;
                    if (Q.IsReady())
                    {
                        Structureclear.CastQ(args);
                        if (target.IsJungle())
                        {
                            Jungleclear.CastQ(args);
                        }

                        if (target.IsMinion())
                        {
                            Laneclear.CastQ(args);
                            return;
                        }

                    }

                    if (E.IsReady())
                    {
                        if (target.IsJungle())
                        {
                            Jungleclear.CastE(args);
                        }
                        
                    }
                    break;
                case OrbwalkerMode.LastHit:
                    if (Q.IsReady())
                    {
                        Lasthit.CastQ(args);
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

            if (Extension.AttackedTimer < Game.Time)
            {
                Extension.Attacked = false;
            }

            if (E.IsReady())
            {
                Automatic.CastE();
                Automatic.SemiE();
                if (KillstealMenu.EBool.Enabled)
                {   
                    Killsteal.CastE();
                }
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (E.IsReady())
                    {
                        Combo.CastE();
                    }

                    if (Q.IsReady())
                    {
                        Combo.CastQ();
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (E.IsReady())
                    {
                        Harass.CastE();
                    }
                    break;
            }
            
        }
        
        private static void OnDraw(EventArgs args)
        {
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.Cyan);
            }

            if (DrawConfig.Eposition.Enabled)
            {
                foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(E.Range)))
                {
                    var pred = E.GetPrediction(target);
                    for (var i = 1; i < 400; i += 50)
                    {   
                        var loc = pred.UnitPosition.Extend(GameObjects.Player.Position, -i);
                        if (loc.IsWall())
                        {
                            DrawCircle(loc,30,System.Drawing.Color.Purple);
                        }
                    }
                }
            }
        }
    }
}