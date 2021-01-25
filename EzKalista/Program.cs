using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;
using SharpDX.Direct3D9;
using Font = SharpDX.Direct3D9.Font;

namespace EzKalista{
    internal class Program{
        public static Font TextBold;
        
        private static Spell Q,W,E,R;
        private static Menu mainMenu;
        public static void Main(string[] args){
            GameEvent.OnGameLoad += OnGameLoad;
        }
        public static void OnGameLoad(){
            TextBold = new Font(
                Drawing.Direct3DDevice, new FontDescription{
                    FaceName = "Tahoma",Height = 30, Weight =FontWeight.ExtraBold, OutputPrecision = FontPrecision.Default, Quality = FontQuality.ClearType,
                }
            );
            
            if(GameObjects.Player.CharacterName != "Kalista") return;
            Q = new Spell(SpellSlot.Q,1150f);
            Q.SetSkillshot(.25f,80f,2100f,true,SpellType.Line);
            W = new Spell(SpellSlot.W,5000f);
            E = new Spell(SpellSlot.E,1000f);
            R = new Spell(SpellSlot.R,1200f);

            mainMenu = new Menu("Kalista","EzKalista",true);
            
            var Combo = new Menu("Combo","Combo Settings");
            Combo.Add(new MenuBool("Quse","Use Q",true));
            mainMenu.Add(Combo);
            
            var Harass = new Menu("Harass","Harass Settings");
            Harass.Add(new MenuBool("Quse","Use Q",true));
            Harass.Add(new MenuBool("Eharassmin","Kill minion to harass",true));
            Harass.Add(new MenuSlider("mana%","Mana percentage",50,0,100));
            mainMenu.Add(Harass);
            
            var KS = new Menu("KS","Kill Steal Settings");
            KS.Add(new MenuBool("Quse","Use Q",true));
            KS.Add(new MenuBool("Euse","Use E",true));
            mainMenu.Add(KS);

            var Farm = new Menu("Farm","LaneClear Settings");
            Farm.Add(new MenuBool("Euse","Use E",true));
            Farm.Add(new MenuSlider("Eminion","^ Minions to cast E",3,1,5));
            Farm.Add(new MenuSlider("mana%","Mana percentage",50,0,100));
            mainMenu.Add(Farm);

            var Jungle = new Menu("Jungle","Jungle Settings");
            Jungle.Add(new MenuBool("Quse","Use Q",true));
            Jungle.Add(new MenuBool("Euse","Use E",true));
            mainMenu.Add(Jungle);

            var Misc = new Menu("Misc","Miscellaneous Settings");
            Misc.Add(new MenuBool("Rally","Save Ally whit R",true));
            Misc.Add(new MenuSlider("health%","^ Health percentage",10,0,100));
            Misc.Add(new MenuBool("wDrake","Automatic W to Drake",true));
            Misc.Add(new MenuBool("wBaron","Automatic W to Baron",true));
            mainMenu.Add(Misc);

            var Draw = new Menu("Draw","Draw Settings");
            Draw.Add(new MenuBool("qRange","Draw Q range",true));
            Draw.Add(new MenuBool("eRange","Draw E Eange",true));
            Draw.Add(new MenuBool("eDamageChamps","Draw E Damage on champions",true));
            Draw.Add(new MenuBool("eDamageJG","Draw E damage on Dragon and Baron",true));
            Draw.Add(new MenuBool("lista","Draw range only if spell is ready"));
            mainMenu.Add(Draw);

            mainMenu.Attach();
            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;
            Console.Write("EzKalista loaded");
            Game.Print("Hi Buddy, enjoy whit EzKalista.\nMaded by EweEwe");
        }
        private static void ComboLogic(){
            var target = TargetSelector.GetTarget(Q.Range);
            var input = Q.GetPrediction(target);
            if(mainMenu["Combo"].GetValue<MenuBool>("Quse").Enabled){
                if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High){
                    Q.Cast(input.UnitPosition);
                }
            }
        }
        private static void HarassLogic(){
            var target = TargetSelector.GetTarget(Q.Range);
            var input = Q.GetPrediction(target);
            if(target == null){
                return;
            }
            if(mainMenu["Harass"].GetValue<MenuSlider>("mana%").Value <= GameObjects.Player.ManaPercent){
                if(mainMenu["Harass"].GetValue<MenuBool>("Quse").Enabled){
                    if(Q.IsReady() && target.IsValidTarget(Q.Range) && input.Hitchance >= HitChance.High){
                        Q.Cast(input.UnitPosition);
                    }
                }
            }
        }
        private static void AutoEChase(){
            foreach(var enemy in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(E.Range) && x.HasBuff("kalistaexpungemarker"))){
                if(enemy == null) return;
                foreach(var minion in GameObjects.EnemyMinions.Where(z => z.IsValidTarget(E.Range) && z.HasBuff("kalistaexpungemarker"))){
                    if(minion == null) return;
                    var Edmg = E.GetDamage(minion);
                    if(mainMenu["Harass"].GetValue<MenuBool>("Eharassmin").Enabled){
                        if(E.IsReady() && !GameObjects.Player.InAutoAttackRange(enemy) && Edmg>minion.Health-ObjectManager.Player.CalculateDamage(minion, DamageType.Physical,1)){
                            E.Cast();
                        }
                    }
                }
            }
        }
        private static void SaveAlly(){
            var allyR = GameObjects.AllyHeroes.FirstOrDefault(x=> x.HasBuff("kalistacoopstrikeally"));
            if(allyR == null){
                return;
            }
            if(mainMenu["Misc"].GetValue<MenuBool>("Rally").Enabled){
                if(R.IsReady() && allyR.DistanceToPlayer()<=R.Range && allyR.HealthPercent <=  mainMenu["Misc"].GetValue<MenuSlider>("health%").Value){
                    R.Cast();
                }
            }
        }
        private static void KSLogic(){
            foreach(var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(Q.Range))){
                var input = Q.GetPrediction(TargetSelector.GetTarget(Q.Range));
                if(target == null){
                    return;
                }
                if(mainMenu["KS"].GetValue<MenuBool>("Euse").Enabled){
                    if(E.IsReady()){
                        if(GameObjects.EnemyHeroes.Any(x => x.IsValidTarget(E.Range) && E.GetDamage(target)>target.Health-ObjectManager.Player.CalculateDamage(target, DamageType.Physical,1))){
                            E.Cast();
                        }
                    }
                }
                if(mainMenu["KS"].GetValue<MenuBool>("Quse").Enabled){
                    if(Q.IsReady() && target.IsValidTarget() && input.Hitchance >= HitChance.High && Q.GetDamage(target)>= target.Health-GameObjects.Player.CalculateDamage(target, DamageType.Physical,1)){
                        Q.Cast(input.UnitPosition);
                    }
                }
            }
        }
        private static void LaneClearLogic(){
            int cont = 0;
            foreach(var minion in GameObjects.EnemyMinions.Where(x => x.IsValidTarget(E.Range))){
                var Edmg = E.GetDamage(minion);
                if(Edmg>minion.Health-ObjectManager.Player.CalculateDamage(minion, DamageType.Physical,1) && minion.HasBuff("kalistaexpungemarker")){
                    cont++;
                }
                if(cont >0){
                    if(mainMenu["Farm"].GetValue<MenuBool>("Euse").Enabled){
                        if(cont >= mainMenu["Farm"].GetValue<MenuSlider>("Eminion").Value && E.IsReady()){
                            E.Cast();
                        }
                    }
                }
            }
        }
        private static void JungleLogic(){
            var mobs = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(E.Range));
            var inpput = Q.GetPrediction(mobs);
            if(mobs == null) return;
            if(mainMenu["Jungle"].GetValue<MenuBool>("Euse").Enabled){
                var Edmg = E.GetDamage(mobs);
                if(mobs.Name.Contains("Dragon") || mobs.Name.Contains("Baron") || mobs.Name.Contains("Herald") || mobs.Name.Contains("golem")){
                    Edmg = Edmg/2;
                }                                   
                if(Edmg>mobs.Health){
                    E.Cast();
                }
            }
            if(mainMenu["Jungle"].GetValue<MenuBool>("Quse").Enabled){
                if(mobs.IsValidTarget(Q.Range) && inpput.Hitchance >= HitChance.High){
                    Q.Cast(inpput.UnitPosition);
                }
            }
        }
        private static void WLogic(){
            var Drakepos = new Vector3(9866f, 4414f, -71f);
            var Baronpos = new Vector3(5007f,10471f,-71f);
            if(mainMenu["Misc"].GetValue<MenuBool>("wDrake").Enabled){
                if(GameObjects.Player.Distance(Drakepos)<= W.Range){
                    W.Cast(Drakepos);
                }
            }
            if(mainMenu["Misc"].GetValue<MenuBool>("wBaron").Enabled){
                if(GameObjects.Player.Distance(Baronpos)<= W.Range){
                    W.Cast(Baronpos);
                }
            }
        }
                       
        private static void OnGameUpdate(EventArgs args){
            if(GameObjects.Player.IsDead) return;
            WLogic();
            AutoEChase();
            KSLogic();
            SaveAlly();
            switch (Orbwalker.ActiveMode){
                case OrbwalkerMode.Combo:
                    ComboLogic();
                    break;
                case OrbwalkerMode.Harass:
                    HarassLogic();
                    break;
                case OrbwalkerMode.LaneClear:
                    LaneClearLogic();
                    JungleLogic();
                    break;
            }
        }
        public static void DrawText(Font fuente, String text, float posx, float posy, SharpDX.ColorBGRA color){
            fuente.DrawText(null,text,(int)posx,(int)posy,color);
        }
        private static void OnDraw(EventArgs args){
            if(mainMenu["Draw"].GetValue<MenuBool>("lista").Enabled){
                if(mainMenu["Draw"].GetValue<MenuBool>("qRange").Enabled){
                    if(Q.IsReady()){
                        Render.Circle.DrawCircle(GameObjects.Player.Position,Q.Range,System.Drawing.Color.Cyan);
                    }
                }
                if(mainMenu["Draw"].GetValue<MenuBool>("eRange").Enabled){
                    if(E.IsReady()){
                        Render.Circle.DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.BlueViolet);
                    }
                }
            }else{
                if(mainMenu["Draw"].GetValue<MenuBool>("qRange").Enabled){
                    Render.Circle.DrawCircle(GameObjects.Player.Position,Q.Range,System.Drawing.Color.Cyan);
                }
                if(mainMenu["Draw"].GetValue<MenuBool>("eRange").Enabled){
                    Render.Circle.DrawCircle(GameObjects.Player.Position,E.Range,System.Drawing.Color.BlueViolet);
                }
            }
            if(mainMenu["Draw"].GetValue<MenuBool>("eDamageChamps").Enabled){
                foreach(var target in GameObjects.EnemyHeroes.Where(z => !z.IsDead && z.IsVisible)){
                    var targetpos = target.HPBarPosition;
                    var DamagePorcnt = (E.GetDamage(target)/target.Health +target.PhysicalShield)*100;
                    var toychato = new Vector2(targetpos.X+50,targetpos.Y-45);
                    if(DamagePorcnt != 0){
                        DrawText(TextBold,Math.Round(DamagePorcnt).ToString()+"%",targetpos.X+50,targetpos.Y-70,SharpDX.Color.White);
                    }
                    
                }
            }
            if(mainMenu["Draw"].GetValue<MenuBool>("eDamageJG").Enabled){
                foreach(var mobs in GameObjects.Jungle.Where(x => x.IsValidTarget(E.Range))){
                    if(mobs == null ) return;
                    if(mobs.Name.Contains("Dragon") || mobs.Name.Contains("Baron") || mobs.Name.Contains("Herald")){
                        var mobs2 = mobs.Position;
                        var mobpos = mobs.HPBarPosition;
                        var Edmg = E.GetDamage(mobs)/2;
                        var DamagePorcnt = (Edmg/mobs.Health+mobs.PhysicalShield)*100;
                        var VectorPos = new Vector2(mobpos.X+50,mobpos.Y-45);
                        if(DamagePorcnt != 0){
                            DrawText(TextBold,Math.Round(DamagePorcnt).ToString()+"%",mobpos.X+50,mobpos.Y-70,SharpDX.Color.White);
                        }
                    }
                }
            }
        }
    }
}
