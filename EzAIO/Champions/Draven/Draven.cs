using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
using static EzAIO.Bases.DrawingBase;
using EzAIO.Champions.Draven.Modes;
using SharpDX;
using static EzAIO.Program;
using Color = System.Drawing.Color;

namespace EzAIO.Champions.Draven
{
    sealed class Draven : ChampionBases
    {
        public Draven()
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
            W = new Spell(SpellSlot.W);
            E = new Spell(SpellSlot.E, 1100){AddHitBox = true};
            E.SetSkillshot(.25f*4,260f,float.MaxValue,false,SpellType.Line);
            R = new Spell(SpellSlot.R, MiscellaneousMenu.RRangeSlider.Value){AddHitBox = true};
            R.SetSkillshot(.5f*4,320f,float.MaxValue,false,SpellType.Line);
            mainMenu = new Menu("Draven", "[EzAIO] EzDraven", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameObject.OnCreate += OnCreate;
            GameObject.OnDelete += OnDelete;
            GameEvent.OnGameTick += OnGameUpdate;
            Orbwalker.OnBeforeAttack += OnBeforeAttack;
            Orbwalker.OnAfterAttack += OnAfterAttack;
            Orbwalker.OnBeforeMove += OnBeforeMove;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,R.Range,System.Drawing.Color.Cyan);
            }

            if (DrawConfig.PlayerMagnetRangeBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,MiscellaneousMenu.MagnetRangeSliderButton.Value,System.Drawing.Color.Purple);
            }

            if (DrawConfig.MouseMagnetRangeBool.Enabled)
            {
                DrawCircle(Game.CursorPos,MiscellaneousMenu.MagnetToMarkSliderButton.Value,System.Drawing.Color.Purple);
            }

            var firstMark = Extension.Marks.FirstOrDefault();
            if (firstMark == null)
            {
                return;
            }

            if (DrawConfig.PlayerMagnetRangeBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,MiscellaneousMenu.MagnetRangeSliderButton.Value, Color.Purple);
            }

            if (DrawConfig.MouseMagnetRangeBool.Enabled)
            {
                DrawCircle(Game.CursorPos,MiscellaneousMenu.MagnetToMarkSliderButton.Value,Color.Purple);
            }

            if (DrawConfig.MarkBoudingRadiusBool.Enabled)
            {
                DrawCircle(firstMark.Pos,Extension.MarksBoudingRadius,Color.Purple);
            }

            var count = 0;
            foreach (var mark in Extension.Marks)
            {
                var markPos = Drawing.WorldToScreen(mark.Pos);
                if (DrawConfig.MarkOrderBool.Enabled)
                {
                    DrawText(TextBold,$"Order: {++count}",markPos.X,markPos.Y +20,SharpDX.Color.White);
                }

                if (DrawConfig.MarkExpireTimeBool.Enabled)
                {
                    DrawText(TextBold, $"Expire in: {(mark.EndTime - Variables.TickCount)/1000f} seconds", markPos.X,
                        markPos.Y + (DrawConfig.MarkOrderBool.Enabled ? 40 : 20), SharpDX.Color.White);
                }
            }
        }


        private static void OnBeforeMove(object sender, BeforeMoveEventArgs args)
        {
            if (Extension.CanCatchAxe() && MiscellaneousMenu.BlockMovementBool.Enabled)
            {
                args.Process = false;
                return;
            }

            if (!Extension.Marks.Any() || !MiscellaneousMenu.MagnetToMarkSliderButton.Enabled)
            {
                return;
            }

            var firstMark = Extension.Marks.FirstOrDefault(Extension.IsMarkBoostedCatchable);
            if (firstMark == null)
            {
                return;
            }

            var firstReachableMark = firstMark.Object;
            if (firstReachableMark.DistanceToPlayer() < Extension.MarksBoudingRadius * .9)
            {
                return;
            }

            if (firstReachableMark.DistanceToPlayer() > MiscellaneousMenu.MagnetRangeSliderButton.Value ||
                firstReachableMark.Distance(Game.CursorPos) > MiscellaneousMenu.MagnetToMarkSliderButton.Value)
            {
                return;
            }
            if(W.IsReady() && !Extension.IsMarkNormallyCatchable(firstMark))
            {
                W.Cast();   
            }

            args.MovePosition = firstReachableMark.Position;
        }

        private static void OnAfterAttack(object sender, AfterAttackEventArgs args)
        {
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (E.IsReady())
                    {
                        Combo.CastE(args);
                    }
                    break;
            }
        }

        private static void OnBeforeAttack(object sender, BeforeAttackEventArgs args)
        {
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (W.IsReady())
                    {
                        Combo.CastW();
                    }

                    if (Q.IsReady())
                    {
                        Combo.CastQ();
                    }
                    break;
                case OrbwalkerMode.Harass:
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
                    var target = args.Target as AIMinionClient;
                    if (W.IsReady())
                    {
                        Structureclear.CastW();
                        if (target.IsMinion())
                        {
                            Laneclear.CastW();
                        }
                        else if ((target.GetJungleType() & JungleType.Large) != 0)
                        {
                            Jungleclear.CastW();
                        }
                    }

                    if (Q.IsReady())
                    {
                        if (target.IsMinion())
                        {
                            Laneclear.CastQ();
                        }
                        else if ((target.GetJungleType() & JungleType.Large) != 0)
                        {
                            Jungleclear.CastQ();
                        }
                    }

                    break;
            }
            if (MiscellaneousMenu.WaitAxeBool.Enabled && !Extension.HasAxeInHand() && Extension.CanCatchAxe())
            {
                args.Process = false;
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }

            if (W.IsReady())
            {
                Automatic.CastWSlowed();
            }

            
            if (R.IsReady())
            {
                Automatic.CastRImmobile();
                Combo.SemiCastR();
            }
            Killsteal.Cast();

            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (W.IsReady())
                    {
                        Combo.CastW();
                    }
                    break;
                case OrbwalkerMode.LaneClear:
                    if (E.IsReady())
                    {
                        Laneclear.CastE();
                    }
                    break;
            }
        }

        private static void OnDelete(GameObject sender, EventArgs args)
        {
            var obj = sender;
            if (obj.IsValid)
            {
                Extension.Marks.RemoveAll(x => x.NewtworkId == obj.NetworkId);
            }
        }

        private static void OnCreate(GameObject sender, EventArgs args)
        {
            var obj = sender;
            if (obj.Name.Contains("Draven_") && obj.Name.Contains("_Q_reticle_self"))
            {
                DelayAction.Add(10, () =>
                {
                    Extension.Marks.Add(new Extension.Mark(obj,obj.NetworkId,obj.Position,Variables.TickCount +1300));
                });
            }
        }
    }
}