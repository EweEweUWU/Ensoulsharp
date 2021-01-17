using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;

namespace EzEzreal{
    internal class Program{
        private static Spell Q,W,E,R;
        private static Menu mainMenu;
        public static void Main(string[] args){
            GameEvent.OnGameLoad += OnGameLoad;
        }
        public static void OnGameLoad(){
            if(GameObjects.Player.CharacterName != "Ezreal") return;
            Q = new Spell(SpellSlot.Q,1200f);
            Q.SetSkillshot(.25f,120f,2000f,true,SpellType.Line);
            W = new Spell(SpellSlot.W,1200f);
            W.SetSkillshot(.25f,160f,1700f,false,SpellType.Line);
            E = new Spell(SpellSlot.E,475);
            R = new Spell(SpellSlot.R,4000f);
            R.SetSkillshot(1f,320f,2000f,false,SpellType.Line);

            mainMenu = new Menu("Ezreal","EzEzreal",true);
            var Combo = new Menu("Combo","Combo Settings");
            Combo.Add(new MenuBool("Quse","Use Q",true));
            Combo.Add(new MenuBool("Wuse","Use W",true));
            Combo.Add(new MenuBool("WonlyQ","^ Only if Q can hit",true));
            mainMenu.Add(Combo);
            var Harass = new Menu("Harass","Harass Settings");
            Harass.Add(new MenuBool("Quse","Use Q",true));
            Harass.Add(new MenuSlider("mana%","Mana porcent",50,0,100));
            mainMenu.Add(Harass);
            var Farm = new Menu("Farm","Lane Clear Settiings");
            Farm.Add(new MenuBool("Quse","Use Q",true));
            Farm.Add(new MenuBool("QonlyLH","^ Only for LastHit",true));
            Farm.Add(new MenuSlider("mana%","Mana porcent",50,0,100));
            mainMenu.Add(Farm);
            var Jungle = new Menu("Jungle","Jungle Settings");
            Jungle.Add(new MenuBool("Quse","Use Q",true));
            Jungle.Add(new MenuSlider("mana%","Mana porcent",50,0,100));
            mainMenu.Add(Jungle);
            var KS = new Menu("KS","KillSteal Settings");
            KS.Add(new MenuBool("Qks","Use Q",true));
            KS.Add(new MenuBool("Rks","Use R",true));
            mainMenu.Add(KS);
            var Misc = new Menu("Misc","Miscellaneous Settings");
            Misc.Add(new MenuKeyBind("Rmanual","Semi R on target",Keys.T,KeyBindType.Press));
            Misc.Add(new MenuBool("Qauto","Auto Q",true));
            Misc.Add(new MenuSlider("mana%","Mana porcent Q",50,0,100));
            mainMenu.Add(Misc);
            var Draw = new Menu("Draw","Draw Settings");
            Draw.Add(new MenuBool("qRange","Draw Q range",true));
            Draw.Add(new MenuBool("wRange","Draw W range",true));
            Draw.Add(new MenuBool("eRange","Draw E range",true));
            Draw.Add(new MenuBool("lista","Draw only if spell is ready",true));
            mainMenu.Add(Draw);

            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;
            Console.Write("EzEzreal loaded");
            Game.Print("Hi Buddy, enjoy whit EzEzreal.\nMaded by EweEwe");
        }
        private static void ComboLogic(){
            var target = TargetSelector.GetTarget(Q.Range);
            var input = Q.GetPrediction(target);
            var inputW = W.GetPrediction(target);
            if(mainMenu["Combo"].GetValue<MenuBool>("Wuse").Enabled){
                if(mainMenu["Combo"].GetValue<MenuBool>("WonlyQ").Enabled){
                    if(W.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High && Q.IsReady()){
                        W.Cast(inputW.UnitPosition);
                }
                if(!mainMenu["Combo"].GetValue<MenuBool>("WonlyQ").Enabled){
                    if(W.IsReady() && target.IsValidTarget() && inputW.Hitchance >= HitChance.High){
                        W.Cast(inputW.UnitPosition);
                    }
                }
            }
            if(mainMenu["Combo"].GetValue<MenuBool>("Quse").Enabled){
                if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High){
                    Q.Cast(input.UnitPosition);
                }
            }
        }
        }
        private static void HarassLogic(){
            var target = TargetSelector.GetTarget(Q.Range);
            var input = Q.GetPrediction(target);
            if(mainMenu["Harass"].GetValue<MenuSlider>("mana%").Value <= GameObjects.Player.ManaPercent){
                if(mainMenu["Harass"].GetValue<MenuBool>("Quse").Enabled){
                    if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High){
                        Q.Cast(input.UnitPosition);
                    }
                }
            }
        }
        private static void FarmLogic(){
            if(mainMenu["Farm"].GetValue<MenuSlider>("mana%").Value <= GameObjects.Player.ManaPercent){
                var minion = GameObjects.Minions.FirstOrDefault(x => x.IsValidTarget(Q.Range));
                var input = Q.GetPrediction(minion);
                
                if(minion != null){
                    if(mainMenu["Farm"].GetValue<MenuBool>("Quse").Enabled){
                        if(mainMenu["Farm"].GetValue<MenuBool>("QonlyLH").Enabled && Q.GetDamage(minion)>minion.Health-ObjectManager.Player.CalculateDamage(minion, DamageType.Physical,1)){
                            Q.Cast(input.UnitPosition);
                        }
                        if(!mainMenu["Farm"].GetValue<MenuBool>("QonlyLH").Enabled){
                            Q.Cast(input.UnitPosition);
                        }
                    }
                }
                
            }
        }
        private static void JungleLogic(){
            if(mainMenu["Jungle"].GetValue<MenuSlider>("mana%").Value <= GameObjects.Player.ManaPercent){
                var mobs = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Q.Range));
                var input = Q.GetPrediction(mobs,false);
                if(mobs != null){
                    if(mainMenu["Jungle"].GetValue<MenuBool>("Quse").Enabled){
                        Q.Cast(input.UnitPosition);
                    }
                }
            }
        }
        private static void KS(){
            if(mainMenu["KS"].GetValue<MenuBool>("Qks").Enabled){
                var target = TargetSelector.GetTarget(Q.Range);
                var input = Q.GetPrediction(target);
                if(target == null){
                    return;
                }
                if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High && Q.GetDamage(target) >= target.Health-ObjectManager.Player.CalculateDamage(target,DamageType.Physical,1)){
                    Q.Cast(input.UnitPosition);
                }
            }
            if(mainMenu["KS"].GetValue<MenuBool>("Rks").Enabled){
                var target = TargetSelector.GetTarget(R.Range);
                var input = R.GetPrediction(target);
                var savePos = 1300f;
                if(target == null){
                    return;
                }
                if(R.IsReady() && target.IsValidTarget() && !target.InRange(savePos) && input.Hitchance >= HitChance.High && R.GetDamage(target) >= target.Health-ObjectManager.Player.CalculateDamage(target,DamageType.Magical,1)){
                    R.Cast(input.UnitPosition);
                }
            }
        }
        private static void Misc(){
            if(mainMenu["Misc"].GetValue<MenuKeyBind>("Rmanual").Active){
                var target = TargetSelector.GetTarget(R.Range);
                var input = R.GetPrediction(target);
                if(R.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High){
                    R.Cast(input.UnitPosition);
                }
            }
            if(mainMenu["Misc"].GetValue<MenuSlider>("mana%").Value <= GameObjects.Player.ManaPercent){
                var target = TargetSelector.GetTarget(Q.Range);
                var input = Q.GetPrediction(target);
                if(mainMenu["Misc"].GetValue<MenuBool>("Qauto").Enabled){
                    if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.VeryHigh){
                        Q.Cast(input.UnitPosition);
                    }
                }
            }
        }

        private static void OnGameUpdate(EventArgs args){
            if(GameObjects.Player.IsDead) return;
            KS();
            Misc();
            switch (Orbwalker.ActiveMode){
                case OrbwalkerMode.Combo:
                    ComboLogic();
                    break;
                case OrbwalkerMode.LaneClear:
                    FarmLogic();
                    JungleLogic();
                    break;
            }
        }
        private static void OnDraw(EventArgs args){
            if(mainMenu["Draw"].GetValue<MenuBool>("lista").Enabled){
                if(mainMenu["Draw"].GetValue<MenuBool>("qRange").Enabled){
                    if(Q.IsReady()){
                        Render.Circle.DrawCircle(GameObjects.Player.Position, Q.Range,System.Drawing.Color.Cyan,1);
                    }
                }
                if(mainMenu["Draw"].GetValue<MenuBool>("wRange").Enabled){
                    if(W.IsReady()){
                        Render.Circle.DrawCircle(GameObjects.Player.Position, W.Range,System.Drawing.Color.Silver,1);
                    }
                }
                if(mainMenu["Draw"].GetValue<MenuBool>("eRange").Enabled){
                    if(E.IsReady()){
                        Render.Circle.DrawCircle(GameObjects.Player.Position, E.Range,System.Drawing.Color.Yellow,1);
                    }

                }
            }
        }
    }
}
