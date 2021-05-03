using EnsoulSharp.SDK.MenuUI;
using static EzAIO.Program;
namespace EzAIO
{
    class SupportedChamps
    {
        private static Menu champs;
        public SupportedChamps()
        {
            Initialize();
        }
        public static void Initialize()
        {
            champs = new Menu("AIOSupport", "Supported Champs");
            var TOPMenu = new Menu("TOP", "TOP")
            {
                new MenuSeparator("sep1", "Vayne")
            };
            var JGMenu = new Menu("JG", "Jungle")
            {
                new MenuSeparator("sep1", "Twicth")
            };
            var MIDMEnu = new Menu("MID", "MID")
            {
                new MenuSeparator("sep1", "Katarina"),
                new MenuSeparator("sep2", "Lucian")
            };
            var ADCMenu = new Menu("ADC", "ADC")
            {
                new MenuSeparator("sep11","Ashe"),
                new MenuSeparator("sep7","Draven"),
                new MenuSeparator("sep1", "Ezreal"),
                new MenuSeparator("sep10", "Jhin"),
                new MenuSeparator("sep8","Jinx"),
                new MenuSeparator("sep2", "Kaisa"),
                new MenuSeparator("sep3", "Kalista"),
                new MenuSeparator("sep4", "Lucian"),
                new MenuSeparator("sep9", "Tristana"),
                new MenuSeparator("sep5", "Twitch"),
                new MenuSeparator("sep6", "Vayne")
            };
            var SUPPMenu = new Menu("SUPP", "SUP")
            {
                new MenuSeparator("sep1", "Not yet :p")
            };
            var menuList = new[]
            {
                TOPMenu,
                JGMenu,
                MIDMEnu,
                ADCMenu,
                SUPPMenu
            };
            foreach (var menu in menuList)
            {
                champs.Add(menu);
            }

            util.Add(champs);
        }
    }
}