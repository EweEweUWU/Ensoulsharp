using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Configs;

namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastE()
        {
            if (!AutomaticMenu.ECCBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.HasBuffOfType(BuffType.Stun) && 
                                                                    x.DistanceToPlayer()<E.Range))
            {
                E.Cast(target.Position);
            }
        }
    }
}