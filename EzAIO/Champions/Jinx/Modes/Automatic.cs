using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void WOnImmobile()
        {
            if (!AutomaticMenu.WCCBool.Enabled)
            {
                return;
            }

            var target = GameObjects.EnemyHeroes.FirstOrDefault(x => x.IsStunned &&
                                                            x.IsValidTarget(W.Range));
            if (target == null)
            {
                return;
            }
            W.Cast(target);
            
        }

        public static void EOnImmobile()
        {
            if (!AutomaticMenu.ECCBool.Enabled)
            {
                return;
            }

            var target = GameObjects.EnemyHeroes.FirstOrDefault(x => x.IsStunned &&
                                                                     x.IsValidTarget(E.Range));
            if (target == null)
            {
                return;
            }

            E.Cast(target);
        }
    }
}