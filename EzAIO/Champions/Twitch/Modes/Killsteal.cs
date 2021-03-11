using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Twitch.Damage;
using static EzAIO.Champions.Twitch.Configs;
namespace EzAIO.Champions.Twitch.Modes
{
    using static ChampionBases;
    class Killsteal
    {
        public static void CastE()
        {
            if (!KillstealMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }

            if(GameObjects.EnemyHeroes.Any(x=>x.IsValidTarget(E.Range) && Extension.HasPoisonEffect(x,E.Range) &&
                                              EDamage(x)>= x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Mixed,1)))
            {
                E.Cast();
            }
        } 
    }
}