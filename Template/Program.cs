using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SFK.MenuUI;
using SharpDX;

namespace Template
{
    internal class Program
    {
        private static Spell Q , W , E , R; //Define that Q,W,E,R are spells.
        private static Menu menu; //Define menu as Menu.
        private static void Main(string[] args){
            GameEvent.OnGameLoad += OnGameLoad; //Define the Event.
        }

        private static void OnGameLoad(EventArgs args){
            if(GameObjects.Player.CharacterName != "YourChampionName") return; //Check if the champion you are playing with is the same as the one you enter here. 
                        //If they are the same, it will execute the rest of the script.
            Q = new Spell(SpellSlot.Q, 1500f); //Making Q as Spell. You need to put the range of the spell (number used as example).
            W = new Spell(SpellSlot.W); //Making W as Spell. If the spell it selfcast (no need range) Leave the space (Like Draven's W).
            E = new Spell(SpellSlot.E, 575f); //Making E as Spell.
            R = new Spell(SpellSlot.R,5000f); //Making R as Spell. In case that R its a Global Ult put a higher number as range. be realistic, don't put 999999999

            //Set the skillshot (delay, width, speed, bool collision (true-false),Spell type (Line, Arc, Circle, Cone, None))
            //If the spell isn't a skillshot dont put here.
            Q.SetSkillShot(0f,0f,0f,true,SpellType.Line);
            E.SetSkillShot(0f,0f,0f,false,SpellType.Circle);
            R.SetSkillShot(0f,0f,0f,true,SpellType.Arc);

            menu = new Menu("NameOfMenu","Name Displayed on Game",true); //Creating a Menu. Example = new Menu("ashe","Ashe Menu", true); true at the end indicates that this menu will be in root

            var Combo = new Menu("combo","Combo Settings"); //Making a SubMenu.
            Combo.Add(new MenuBool("useq","Use Q",true)); //Adding an item to the SubMenu. Menu type Bool (true or false).
            Combo.Add(new MenuSlider("enemies","Don't use Q if Mana >= x%",50,1,100)); //Adding an Item to the SubMenu. Menu type Slider.
            Combo.Add(new MenuKeyBind("semiR","R Semi Cast",Keys.T,KeyBinType.Press)); //Adding an Item to the SubMenu. Menu type KeyBind.
            menu.Add(Combo); //Adding the SubMenu to the main Menu.

            var Draw = new Menu("draw","Draw Settings"); //Making a SubMenu.
            Draw.Add(new MenuBool("qRange","Draw Q range",true)); //Adding an Item to the SubMenu. Menu type Bool (true or false).
            menu.Add(Draw); //Adding the SubMenu to the main Menu.

            menu.Attach();

            GameEvent.OnGameTick += OnGameUpdate;
            Drawing.OnDraw += OnDraw;
        }
        private static void OnGameUpdate(EventArgs args){
            switch (Orbwalker.ActiveMode)
            { //This switch will be in charge of verifying in which mode the Orbwalker is being used at that moment.
                case OrbwalkerMode.Combo: 
                    //In the event that the Orbwalker is in Combo mode. The function that we have defined will be executed.
                    ComboLogic();
                    break;
            }

        }
        private static void ComboLogic(){
            var target = TargetSelector.GetTarget(Q.Range) //Getting a target in the Q range.
            if(target == null) return; //if there is no target, do nothing.

            if(menu[Combo].GetValue<MenuBool>("useQ").Enabled && Q.IsReady()){ //cheking if Use Q in Combo is active and if W is ready to cast.
                var prediction = Q.GetPrediction(target); //Get the prediction of the target movement.
                if(prediction.Hitchanche >= Hitchanche.High){ //check if there are high chances of hitting the skillshot
                    Q.Cast(prediction.CastPosition); //Cast Q on the predicted target place.
                }
            }
        }
        private static void OnDraw(EventArgs args){ //All render events
            if(menu["Draw"].GetValue<MenuBool>("qRange").Enabled){
                Render.Circle.DrawCircle(GameObjects.Player.Position, Q.Range, System.Drawing.Color.White); //Render a circle in the Player pos with Q Range radius
            }
        }
    }
}