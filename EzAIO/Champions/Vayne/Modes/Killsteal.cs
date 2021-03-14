using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastE()
        {
            if (KillstealMenu.EBool.Enabled)
            {
                return;
            }

            if (!Extension.Attacked)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(Extension.KillableWithE))
            {
                E.CastOnUnit(target);
                break;
            }
        }
    }
}