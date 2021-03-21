using System;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
using EzAIO.Champions.Katarina.Modes;
using SharpDX;
using static EzAIO.Champions.Katarina.Damage;
using static EzAIO.Bases.DrawingBase;
using static EzAIO.Program;
namespace EzAIO.Champions.Katarina
{
    sealed class Katarina : ChampionBases
    {
        public Katarina()
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

            Q = new Spell(SpellSlot.Q, 625f);
            W = new Spell(SpellSlot.W, 400f);
            E = new Spell(SpellSlot.E, 725f);
            R = new Spell(SpellSlot.R, 550f);
            mainMenu = new Menu("Katarina", "[EzAIO] EzKatarina", true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            AIBaseClient.OnProcessSpellCast += OnProcessSpellCast;
            Spellbook.OnCastSpell += OnCastSpell;
            GameObject.OnDelete += OnDelete;
            AIBaseClient.OnBuffAdd += OnBuffAdd;
            AIBaseClient.OnBuffRemove += OnBuffRemove;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnBuffRemove(AIBaseClient sender, AIBaseClientBuffRemoveEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }

            if (!sender.HasBuff("katarinarsound"))
            {
                return;
            }

            Extension.CastingR = false;
            Extension.rTrigger = false;
        }

        private static void OnBuffAdd(AIBaseClient sender, AIBaseClientBuffAddEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }

            if (!sender.HasBuff("katarinarsound"))
            {
                return;
            }

            Extension.CastingR = true;
        }

        private static void OnDelete(GameObject sender, EventArgs args)
        {
            if (sender.Name.Contains("R_cas") && sender.Name.Contains("Katarina"))
            {
                Extension.CastingR = false;
                Extension.rTrigger = false;
            }
        }

        private static void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (args.Slot == SpellSlot.R &&
                GameObjects.Player.Position.CountEnemyHeroesInRange(R.Range - 50) != 0 &&
                R.IsReady())
            {
                Extension.rDealy = Game.Time + Game.Ping / 500f;
                Extension.CastingR = true;
                return;
            }

            if (Extension.CastingR &&
                (args.Slot == SpellSlot.Q ||
                 args.Slot == SpellSlot.W ||
                 args.Slot == SpellSlot.E ||
                 args.Slot == SpellSlot.Item1 ||
                 args.Slot == SpellSlot.Item2 ||
                 args.Slot == SpellSlot.Item3 ||
                 args.Slot == SpellSlot.Item4 ||
                 args.Slot == SpellSlot.Item5 ||
                 args.Slot == SpellSlot.Item6))
            {
                args.Process = false;
            }
        }

        private static void OnProcessSpellCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe)
            {
                return;
            }
            if(args.Slot == SpellSlot.R)
            {
                Extension.CastingR = true;
                Extension.rTrigger = true;
            }
        }

        private static void OnGameUpdate(EventArgs args)
        {
            Extension.GetDagger();
            if (Extension.rTrigger == false && Extension.rDealy < Game.Time)
            {
                Extension.CastingR = false;
            }

            if (GameObjects.Player.IsDead)
            {
                return;
            }

            if (Extension.CastingR)
            {
                Orbwalker.MoveEnabled = false;
                Orbwalker.AttackEnabled = false;
                if (ComboMenu.RCancelBool.Enabled && GameObjects.Player.CountEnemyHeroesInRange(R.Range) == 0)
                {
                    GameObjects.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                }
            }
            else
            {
                Orbwalker.MoveEnabled = true;
                Orbwalker.AttackEnabled = true;
            }

            if (ComboMenu.RModeList.Index == 0)
            {
                ComboMenu.RSlider.Visible = true;
            }
            else
            {
                ComboMenu.RSlider.Visible = false;
            }
            Killsteal.CastE();
            Killsteal.CastQ();
            Killsteal.CastEGap();
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    Combo.CastCombo();
                    Combo.CastR();
                    break;
                case OrbwalkerMode.Harass:
                    Harass.CastHarass();
                    break;
                case OrbwalkerMode.LaneClear:
                    if (LaneclearMenu.FarmToggleKey.Active)
                    {
                        Laneclear.CastQ();
                        Laneclear.CastW();
                        Laneclear.CastE();
                    }
                    Jungleclear.CastW();
                    Jungleclear.CastE();
                    Jungleclear.CastQ();
                    break;
                case OrbwalkerMode.LastHit:
                    if (LaneclearMenu.FarmToggleKey.Active)
                    {
                        Laneclear.CastQLast();
                    }
                    break;
                
            }
        }

        public static void OnDraw(EventArgs args)
        {
            if (DrawMenu.QBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,Q.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.EBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.Cyan);
            }
            if (DrawMenu.RBool.Enabled)
            {
                DrawCircle(GameObjects.Player.Position,R.Range,System.Drawing.Color.Cyan);
            }

            if (DrawConfig.DrawDaggerBool.Enabled)
            {
                foreach (var dagger in Extension.Daggers.Where(x=>x.IsValid))
                {
                    DrawCircle(dagger.Position,450,dagger.Position.CountEnemyHeroesInRange(450)>0 ? System.Drawing.Color.LawnGreen : System.Drawing.Color.Red );
                    DrawCircle(dagger.Position,150,dagger.Position.CountEnemyHeroesInRange(450)>0 ? System.Drawing.Color.LawnGreen : System.Drawing.Color.Red );
                }
            }
        }
    }
}