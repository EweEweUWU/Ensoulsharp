using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using EzAIO.Extras;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastQ()
        {
            if (!HarassMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (HarassMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            foreach (var target in Helps.GetBestEnemyHeroesInRange(Q.Range).Where(x=>x.IsValidTarget()))
            {
                Q.CastOnUnit(target);
                break;
            }
        }
    }
}