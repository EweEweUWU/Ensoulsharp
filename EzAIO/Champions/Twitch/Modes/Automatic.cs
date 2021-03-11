using EnsoulSharp;
using EnsoulSharp.SDK.Utility;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Configs;
namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastQ()
        {
            if (!AutomaticMenu.Qsilent.Active || !Q.IsReady())
            {
                return;
            }
            Q.Cast();
            DelayAction.Add((int)(Q.Delay+300),
                ()=>ObjectManager.Player.Spellbook.CastSpell(SpellSlot.Recall));
        }
    }
}