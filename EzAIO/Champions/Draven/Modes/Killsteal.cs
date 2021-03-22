using System.Linq;
using EnsoulSharp;
using static EzAIO.Champions.Draven.Damage;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Draven.Configs;
namespace EzAIO.Champions.Draven.Modes
{
    using static ChampionBases;
    class Killsteal
    {
        public static void Cast()
        {
            if (E.IsReady())
            {
                if (CastE())
                {
                    return;
                }
            }

            if (R.IsReady())
            {
                CastR();
            }
            
        }

        public static bool CastE()
        {
            if (!KillstealMenu.EBool.Enabled)
            {
                return false;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(E.Range) &&
                                                                    EDamage(x)>=x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    x.DistanceToPlayer()>GameObjects.Player.GetRealAutoAttackRange() &&
                                                                    !x.IsInvulnerable))
            {
                var einput = E.GetPrediction(target);
                if (einput.Hitchance >= HitChance.High)
                {
                    return E.Cast(einput.UnitPosition);
                }
            }

            return false;
        }

        public static void CastR()
        {
            if (!KillstealMenu.RBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(R.Range) &&
                                                                    RDamage(x)>=x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Physical,1) &&
                                                                    x.Distance(Game.CursorPos)>GameObjects.Player.GetRealAutoAttackRange() &&
                                                                    !x.IsInvulnerable))
            {
                var rInput = R.GetPrediction(target);
                if (rInput.Hitchance >= HitChance.High)
                {
                    R.Cast(rInput.UnitPosition);
                }
                return;
            }
        }
    }
}