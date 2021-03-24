using System;
using System.Drawing;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
using static EzAIO.Bases.DrawingBase;
using EzAIO.Champions.Ezreal.Modes;

namespace EzAIO.Champions.Ezreal
{
    // Ported from EntropyAIO
    
    sealed class Ezreal : ChampionBases
    {
        public Ezreal()
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
            Q = new Spell(SpellSlot.Q, 1200f) {AddHitBox = true};
            Q.SetSkillshot(.25f*4, 100f, float.MaxValue, true, SpellType.Line); //120
            W = new Spell(SpellSlot.W, 1200f) {AddHitBox = true};
            W.SetSkillshot(.25f*4, 130f, float.MaxValue, false, SpellType.Line); //160
            E = new Spell(SpellSlot.E, 475f);
            R = new Spell(SpellSlot.R, 5000f) {AddHitBox = true};
            R.SetSkillshot(1f*2, 160f, float.MaxValue, false, SpellType.Line); //320
            
            mainMenu = new Menu("Ezreal", "[EzAIO] EzEzreal",true);
            Menus.Initialize();
            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;

        }

        private static void OnGameUpdate(EventArgs args)
        {
            Killsteal.CastQ();
            Killsteal.CastR();
            if (R.IsReady())
            {
                if (mainMenu["Automatic"].GetValue<MenuSliderButton>("safe").Enabled)
                {
                    if (GameObjects.Player.CountEnemyHeroesInRange(
                        mainMenu["Automatic"].GetValue<MenuSliderButton>("safe").Value) == 0)
                    {
                        Automatic.OnImmobile();
                    }
                }
                else
                {
                    Automatic.OnImmobile();
                }
                
                Combo.SemiR();
            }

            if (Q.IsReady())
            {
                Automatic.CastQ();
            }
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    if (mainMenu["Combo"].GetValue<MenuSliderButton>("priority").Enabled &&
                        GameObjects.Player.ManaPercent <=
                        mainMenu["Combo"].GetValue<MenuSliderButton>("priority").Value)
                    {
                        Combo.CastW();
                        Combo.CastQ();
                    }
                    else
                    {
                        Combo.CastW();
                        Combo.CastQ();
                    }
                    break;
                case OrbwalkerMode.Harass:
                    Harass.CastW();
                    Harass.CastQ();
                    break;
                case OrbwalkerMode.LaneClear:
                    LaneClear.CastQ();
                    JungleClear.CastW();
                    JungleClear.CastQ();
                    Structureclear.CastW();
                    break;
                case OrbwalkerMode.LastHit:
                    Lasthit.CastQ();
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
                DrawCircle(GameObjects.Player.Position,mainMenu["Automatic"].
                    GetValue<MenuSlider>("rRange").Value,Color.Cyan);
            }
        }
        
    }
}