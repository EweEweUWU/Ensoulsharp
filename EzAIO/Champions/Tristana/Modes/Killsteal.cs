using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Tristana.Damage;
using static EzAIO.Champions.Tristana.Configs;
using static EzAIO.Champions.Tristana.Tristana;
namespace EzAIO.Champions.Tristana.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void CastR()
        {
            if (!KillstealMenu.RBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(Player.GetRealAutoAttackRange(x)) &&
                                                                    EDamage(x)+RDamage(x)>=x.Health-
                                                                    Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    !x.IsInvulnerable))
            {
                R.CastOnUnit(target);
                break;
            }
        }
    }
}