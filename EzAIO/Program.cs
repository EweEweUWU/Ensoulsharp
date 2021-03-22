using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using SharpDX.Direct3D9;
using static EzAIO.SupportedChamps;


namespace EzAIO{
    internal class Program
    {
        public static Font TextBold;
        public const string version = "1.0.6.0";    
        private const string disc = "https://discord.gg/xuuUKAd7N2";
        private const string commit = version + " Draven Added!"; 
        public static Menu champs;

        private Program()
        {
            new SupportedChamps();
        }
        

        public static void MSG(string mess)
        {
            Game.Print("<font color = '#FF0000'>[EzAIO] <font color = '#FFFFFF'>"+mess);
        }
        public static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }
        private static void OnGameLoad()
        {
            TextBold = new Font(Drawing.Direct3DDevice, new FontDescription
            {
                FaceName = "Tahoma",
                Height = 30,
                Weight = FontWeight.ExtraBold,
                OutputPrecision = FontPrecision.Default,
                Quality = FontQuality.ClearType,
            });
            if (ObjectManager.Player.IsDead)
            {
                return;
            }

            try
            {
                switch (GameObjects.Player.CharacterName)
                {
                    case "Ezreal":
                        Champions.Ezreal.Ezreal.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Kalista":
                        Champions.Kalista.Kalista.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Twitch":
                        Champions.Twitch.Twitch.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Lucian":
                        Champions.Lucian.Lucian.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Kaisa":
                        Champions.Kaisa.Kaisa.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Vayne":
                        Champions.Vayne.Vayne.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Katarina":
                        Champions.Katarina.Katarina.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    case "Draven":
                        Champions.Draven.Draven.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName+" Loaded!");
                        break;
                    default:
                        MSG(GameObjects.Player.CharacterName + " not supported!");
                        break;
                }
            }
            catch (Exception e)
            {
                MSG("Error loading the AIO.");
                throw;
            }

            champs = new Menu("AIOChamps", "[EzAIO] SupportedChamps", true);
            SupportedChamps.Initialize();
            champs.Attach();
            MSG(commit);
            MSG("Enter my Discord server! "+disc);
        }

        public static void DrawText(Font fuente, String text, float posx, float posy, SharpDX.ColorBGRA color)
        {
            fuente.DrawText(null, text, (int) posx, (int) posy, color);
        }
    }
}