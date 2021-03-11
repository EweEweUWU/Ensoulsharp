using System;
using System.Drawing;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using static EzAIO.Bases.DrawingBase;
using EzAIO.Champions.Kalista.Modes;

namespace EzAIO.Champions.Kalista
{
    sealed class Kalista : ChampionBases
    {
        public Kalista()
        {
            new Menus();
        }

        public static Menu maineMenu;

        public static void OnGameLoad()
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }

            Q = new Spell(SpellSlot.Q, 1150f);
            Q.SetSkillshot(.25f,80f,2100f,true,SpellType.Line);
            W = new Spell(SpellSlot.W, 5000f);
            E = new Spell(SpellSlot.E, 1000f);
            R = new Spell(SpellSlot.R, 1200f);
            maineMenu = new Menu("Kalista", "[EzAIO] EzKalista", true);
            Menus.Initialize();
            maineMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;
            Drawing.OnEndScene += OnEndScene;
        }

        private static void OnGameUpdate(EventArgs args)
        {
            Killsteal.CastQ();
            Killsteal.CastE();
            Harass.CastE();
            Automatic.CastR();
            Automatic.CastW();
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (Configs.AutomaticMenu.MinionsChase.Enabled)
                    {
                        if(Orbwalker.GetTarget() == null){
                            if(GameObjects.EnemyHeroes.Any(x => x.IsValidTarget(1300f) && GameObjects.Player.Distance(x) > GameObjects.Player.AttackRange)){
                                var minion = GameObjects.EnemyMinions.OrderBy(x => x.Distance(GameObjects.Player)).FirstOrDefault();
                                if(minion != null) Orbwalker.Orbwalk(minion,Game.CursorPos);
                            }
                        }
                    }
                    Combo.CastQ();
                    break;
                case OrbwalkerMode.Harass:
                    Harass.CastQ();
                    break;
                case OrbwalkerMode.LaneClear:
                    Jungleclear.CastQ();
                    Jungleclear.CastE();
                    Laneclear.CastE();
                    break;
                case OrbwalkerMode.LastHit:
                    Lasthit.CastE();
                    break;
            }
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
                DrawCircle(GameObjects.Player.Position,R.Range,Color.Cyan);
            }
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

            if (Configs.DrawConfig.Ecircle.Enabled)
            {
                DamageIndicator.eCircle();
            }
        }
    }
}