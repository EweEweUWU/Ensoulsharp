using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Champions;
using SharpDX.Direct3D9;


namespace EzAIO{
    internal class Program
    {
        public static Font TextBold;
        public const string version = "1.0.0.1";
        private const string disc = "https://discord.gg/xuuUKAd7N2";
        private const string commit = version + " Kaisa and Vayne Added!";

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
            MSG(commit);
            MSG("Enter my Discord server! "+disc);
        }

        public static void DrawText(Font fuente, String text, float posx, float posy, SharpDX.ColorBGRA color)
        {
            fuente.DrawText(null, text, (int) posx, (int) posy, color);
        }
    }
}