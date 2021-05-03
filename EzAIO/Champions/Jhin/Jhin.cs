using System;
using System.Drawing;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Champions.Jhin.Modes;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Bases.DrawingBase;

namespace EzAIO.Champions.Jhin
{
    sealed class Jhin : ChampionBases
    {
        public static AIHeroClient Player = GameObjects.Player;

        public Jhin()
        {
            new Menus();
        }

        public static Menu mainMenu;
        public static Spell RShot { get; private set; }

        public static void OnGameLoad()
        {
            if (Player.IsDead)
            {
                return;
            }

            Q = new Spell(SpellSlot.Q, 550f);
            W = new Spell(SpellSlot.W, 2500f) {AddHitBox = true};
            W.SetSkillshot(.75f*1.5f,90f,float.MaxValue,false,SpellType.Line);
            E = new Spell(SpellSlot.E, 750f);
            E.SetSkillshot(.25f,260f,1000f,false,SpellType.Circle);
            R = new Spell(SpellSlot.R,3500f) {AddHitBox = true};
            R.Width = 55;
            RShot = new Spell(SpellSlot.R, 3500f) {AddHitBox = true};
            RShot.SetSkillshot(.25f*3.8f,80f,5000f,false,SpellType.Line);
            mainMenu = new Menu("Jhin", "[EzAIO] Jhin", true);
            Menus.Initialize();
            mainMenu.Attach();
            Orbwalker.OnBeforeMove += OnBeforeMove;
            Orbwalker.OnAfterAttack += OnAfterAttack;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            GameEvent.OnGameTick += OnGameUpdate;
            Teleport.OnTeleport += OnTeleport;
            AIBaseClient.OnProcessSpellCast += OnProcessSpellCast;
            Spellbook.OnCastSpell += OnCastSpell;
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
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,RShot.Range,Color.Cyan);
            }

            if (DrawConfig.DrawRConeBool.Enabled)
            {
                if (!Extension.IsUltShooting())
                {
                    return;
                }
                Extension.RCone().Draw(Color.Red,2);
                
            }
        }

        private static void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (Extension.IsUltShooting() && args.Slot != SpellSlot.R)
            {
                args.Process = false;
                return;
            }

            switch (args.Slot)
            {
                case SpellSlot.W:
                    if (ComboMenu.WRangeBool.Enabled && GameObjects.EnemyHeroes.Any(x =>
                        x.DistanceToPlayer() <= Player.GetCurrentAutoAttackRange(x)))
                    {
                        args.Process = false;
                    }
                    break;
            }
        }

        private static void OnProcessSpellCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe || args.Slot != SpellSlot.R)
            {
                return;
            }

            if (!Extension.IsUltShooting())
            {
                Extension.UltimateShootsCount = 0;
                Extension.End = args.End;
            }
            else
            {
                Extension.UltimateShootsCount++;
            }
        }

        private static void OnTeleport(AIBaseClient sender, Teleport.TeleportEventArgs args)
        {
            if (args.Type != Teleport.TeleportType.Teleport || args.Status != Teleport.TeleportStatus.Start)
            {
                return;
            }

            if (!sender.IsEnemy)
            {
                return;
            }
            if(E.IsReady() && AutomaticMenu.ETeleportBool.Enabled && sender.DistanceToPlayer() <= E.Range)
            {
                E.Cast(sender.Position);
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (Player.IsDead)
            {
                return;
            }

            if (E.IsReady())
            {
                Automatic.CastE();
            }

            Killsteal.Cast();
            
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (Q.IsReady() && Extension.IsReloading())
                    {
                        Combo.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Combo.CastW();
                    }

                    if (R.IsReady() && Extension.IsUltShooting())
                    {
                        Combo.CastR();
                    }
                    break;
                case OrbwalkerMode.Harass:
                    if (Q.IsReady())
                    {
                        Harass.CastQ();
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

                    if (E.IsReady())
                    {
                        Laneclear.CastE();
                    }
                    break;
                case OrbwalkerMode.LastHit:
                    if (Q.IsReady())
                    {
                        Lasthit.CastQ();
                    }
                    break;
            }
        }

        private static void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            if (Extension.IsUltShooting())
            {
                args.Process = true;
            }

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (Q.IsReady())
                    {
                        Extra.CastQ(args);
                    }
                    break;
            }
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

                    if (E.IsReady())
                    {
                        Extra.CastE();
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    var target = args.Target as AIMinionClient;
                    if (target == null)
                    {
                        return;
                    }

                    if ((target.GetJungleType() & JungleType.Large) == 0 ||
                        target.Health <= Player.GetAutoAttackDamage(target) * 3)
                    {
                        return;
                    }

                    if (Q.IsReady())
                    {
                        Jungleclear.CastQ(args);
                    }

                    if (E.IsReady())
                    {
                        Jungleclear.CastE(args);
                    }
                    break;
            }
        }

        private static void OnBeforeMove(object sender, BeforeMoveEventArgs args)
        {
            if (Extension.IsUltShooting())
            {
                args.Process = false;
            }
        }
    }
}