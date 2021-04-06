using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using EzAIO.Champions.Jinx.Modes;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Champions.Jinx.Configs;
namespace EzAIO.Champions.Jinx
{
    sealed class Jinx : ChampionBases
    {
        public static AIBaseClient Player = GameObjects.Player;
        public Jinx()
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
            W = new Spell(SpellSlot.W, 1450f) {AddHitBox = true};
            W.SetSkillshot(.6f*4,120f,3300f,true,SpellType.Line);
            E = new Spell(SpellSlot.E, 900f);
            E.SetSkillshot(.7f*4,300f,float.MaxValue,false,SpellType.Circle);
            R = new Spell(SpellSlot.R, Configs.ComboMenu.RSliderRange.Value) {AddHitBox = true};
            R.SetSkillshot(.6f*4,100f,float.MaxValue,false,SpellType.Line);
            mainMenu = new Menu("Jinx", "[EzAIO] EzJinx", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameTick;
            AIBaseClient.OnBuffAdd += OnBuffAdd;
            AIBaseClient.OnBuffRemove += OnBuffRemove;
            Teleport.OnTeleport += OnTeleport;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (DrawConfig.QRRange.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,Extension.RocketRange,System.Drawing.Color.Cyan);
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
        }

        private static void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            Laneclear.CastQAOE();
            if (!Extension.ActivatedRockets)
            {
                return;
            }

            switch (args.Target)
            {
                case AITurretClient _:
                case AIMinionClient _ when  Orbwalker.ActiveMode == OrbwalkerMode.Harass:
                    Q.Cast();
                    break;
            }
        }

        private static void OnTeleport(AIBaseClient sender, Teleport.TeleportEventArgs args)
        {
            if (!E.IsReady())
            {
                return;
            }

            if (!AutomaticMenu.ETeleportBool.Enabled)
            {
                return;
            }

            if (args.Type != Teleport.TeleportType.Teleport || args.Status != Teleport.TeleportStatus.Start)
            {
                return;
            }

            if (!sender.IsEnemy)
            {
                return;
            }

            if (sender.DistanceToPlayer() <= E.Range)
            {
                E.Cast(sender.Position);
            }
        }

        private static void OnBuffRemove(AIBaseClient sender, AIBaseClientBuffRemoveEventArgs args)
        {
            switch (args.Buff.Name)
            {
                case "JinxQ" when args.Buff.Caster.IsMe:
                    Extension.ActivatedRockets = false;
                    break;
                case "jinxpassivekillmovementspeed" when args.Buff.Caster.IsMe:
                    Extension.ActivatedPassive = false;
                    break;
            }
        }

        private static void OnBuffAdd(AIBaseClient sender, AIBaseClientBuffAddEventArgs args)
        {
            switch (args.Buff.Name)
            {
                case "JinxQ" when args.Buff.Caster.IsMe:
                    Extension.ActivatedRockets = true;
                    break;
                case "jinxpassivekillmovementspeed" when args.Buff.Caster.IsMe:
                    Extension.ActivatedPassive = true;
                    break;
            }
        }

        private static void OnGameTick(EventArgs args)
        {
            if (Player.IsDead)
            {
                return;
            }
            
            if (W.IsReady())
            {
                Automatic.WOnImmobile();
                Killsteal.CastW();
            }

            if (E.IsReady())
            {
                Automatic.EOnImmobile();
            }

            if (R.IsReady())
            {
                Killsteal.CastR();
                Combo.SemiCastR();
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

                    if (E.IsReady())
                    {
                        Combo.CastE();
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
                        Jungleclear.CastQ();
                    }

                    if (W.IsReady())
                    {
                        Jungleclear.CastW();
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
    }
}