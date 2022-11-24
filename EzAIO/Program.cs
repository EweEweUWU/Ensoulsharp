using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Rendering;
using EnsoulSharp.SDK.Rendering.Caches;
using EzAIO.Bases;
using EzAIO.Utilities.BaseUlt;
using SharpDX.Direct3D9;
using static EzAIO.SupportedChamps;
using EzAIO.Utilities.BaseUlt;


namespace EzAIO
{
    internal class Program
    {
        public static FontCache TextBold;
        public const string version = "1.0.10.0";
        private const string disc = "[REMOVED]";
        private const string commit = "Updated";
        public static Menu util;

        private Program()
        {
            new SupportedChamps();
        }


        public static void MSG(string mess)
        {
            Game.Print("<font color = '#FF0000'>[EzAIO] <font color = '#FFFFFF'>" + mess);
        }
        public static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }
        private static void OnGameLoad()
        {
            TextBold = TextRender.CreateFont(30);
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
                        BaseUlt.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Kalista":
                        Champions.Kalista.Kalista.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Twitch":
                        Champions.Twitch.Twitch.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Lucian":
                        Champions.Lucian.Lucian.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Kaisa":
                        Champions.Kaisa.Kaisa.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Vayne":
                        Champions.Vayne.Vayne.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Katarina":
                        Champions.Katarina.Katarina.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Draven":
                        Champions.Draven.Draven.OnGameLoad();
                        BaseUlt.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Jinx":
                        Champions.Jinx.Jinx.OnGameLoad();
                        BaseUlt.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Tristana":
                        Champions.Tristana.Tristana.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Jhin":
                        Champions.Jhin.Jhin.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
                        break;
                    case "Ashe":
                        Champions.Ashe.Ashe.OnGameLoad();
                        BaseUlt.OnGameLoad();
                        MSG(GameObjects.Player.CharacterName + " Loaded!");
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

            util = new Menu("AIOChamps", "[EzAIO] Utilities", true);
            Initialize();
            Menus.Initialize();
            EzAIO.Developer.Menus.Initialize();
            util.Attach();
            MSG(commit);
            MSG("New Discord server " + disc);
        }

        public static void DrawText(FontCache fuente, String text, float posx, float posy, SharpDX.ColorBGRA color)
        {
            fuente.Draw(text, (int)posx, (int)posy, color);
        }
    }
}