using static EzAIO.Champions.Jhin.Jhin;
using static EzAIO.Bases.ChampionBases;
namespace EzAIO.Champions.Ashe
{
    static class Extension
    {
        public static bool IsQActive()
        {
            return Player.HasBuff("AsheQAttack");
        }
    }
}