using System;
using System.Drawing;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using static EzAIO.Bases.DrawingBase;
using EzAIO.Champions.Tristana.Modes;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Extras.Helps;
using static EzAIO.Program;

namespace EzAIO.Champions.Tristana
{
    sealed class Tristana : ChampionBases
    {
        public static AIHeroClient Player = GameObjects.Player;

        public Tristana()
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
            W = new Spell(SpellSlot.W,900f);
            W.SetSkillshot(.25f,350f,1100f,false,SpellType.Circle);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);
            mainMenu = new Menu("Tristana", "[EzAIO] EzTristana", true);
            Menus.Initialize();
            mainMenu.Attach();
            //AIBaseClient.OnBuffAdd += OnBuffAdd;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;
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
            var bestMinion = GameObjects.EnemyMinions.FirstOrDefault(x =>
                x.IsValidTarget(Player.GetRealAutoAttackRange()) &&
                CountInRange(x,300, GameObjects.EnemyMinions) >=
                LaneclearMenu.EMinionSlider.Value);
            if (bestMinion == null)
            {
                return;
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
                Automatic.CastR();
                Combo.SemiR();
                Killsteal.CastR();
            }
        }

        private static void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            var forceTarget =
                GameObjects.EnemyHeroes.FirstOrDefault(x => x.IsCharged() &&
                                                            x.IsValidTarget(Player.GetRealAutoAttackRange(x)));
            if (forceTarget != null &&
                Orbwalker.ActiveMode == OrbwalkerMode.Combo &&
                Orbwalker.GetTarget() != forceTarget)
            {
                Orbwalker.ForceTarget = forceTarget;
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (Q.IsReady())
                    {
                        Combo.CastQ(args);
                    }

                    if (E.IsReady())
                    {
                        Combo.CastE(args);
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (Q.IsReady())
                    {
                        Harass.CastQ(args);
                    }

                    if (E.IsReady())
                    {
                        Harass.CastE(args);
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    if (Q.IsReady() || E.IsReady())
                    {
                        Structureclear.Cast(args);
                    }

                    var target = args.Target as AIMinionClient;
                    if (target == null)
                    {
                        return;
                    }

                    if (target.IsMinion())
                    {
                        if (Q.IsReady())
                        {
                            Laneclear.CastQ();
                        }

                        if (E.IsReady())
                        {
                            Laneclear.CastE(args);
                        }

                        if (Extension.HasEBuff(target))
                        {
                            Orbwalker.ForceTarget = target;
                        }
                    }

                    if (target.IsJungle() && target.Health > Player.GetAutoAttackDamage(target) * 3)
                    {
                        if (Q.IsReady())
                        {
                            Jungleclear.CastQ();
                        }
                    }

                    if ((target.GetJungleType() & JungleType.Legendary) != 0 && target.Health >
                        Player.GetAutoAttackDamage(target) * 3)
                    {
                        if (E.IsReady())
                        {
                            Jungleclear.CastE(args);
                        }
                    }
                    break;
            }
        }

        /*private static void OnBuffAdd(AIBaseClient sender, AIBaseClientBuffAddEventArgs args)
        {
            var buff = args.Buff;
            if (!buff.Caster.IsMe)
            {
                return;
            }
            

            if (W.IsReady() && AutomaticMenu.AntiGrabBool.Enabled &&
                Player.IsGrabbed())
            {
                W.Cast(Game.CursorPos);
            }
        }*/
    }
}