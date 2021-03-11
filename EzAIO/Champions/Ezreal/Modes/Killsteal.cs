using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EzAIO.Bases;
namespace EzAIO.Champions.Ezreal.Modes
{
    using static Damage;
    using static Ezreal;
    using static ChampionBases;
    
    static class Killsteal
    {
        internal static void CastQ()
        {
            if (!mainMenu["Killsteal"].GetValue<MenuBool>("q").Enabled || !Q.IsReady())
            {
                return;
            }
            

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>
                x.IsValidTarget(Q.Range) &&
                QDamage(x)>= x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Physical,1) &&
                !x.IsInvulnerable))
            {
                var qinput = Q.GetPrediction(target);
                if (qinput.Hitchance >= HitChance.High)
                {
                    Q.Cast(qinput.UnitPosition);
                }

            }
        }
        internal static void CastR()
        {
            if (!mainMenu["Killsteal"].GetValue<MenuBool>("r").Enabled || !Q.IsReady())
            {
                return;
            }
            foreach (var target in GameObjects.EnemyHeroes.Where(x=>
                x.IsValidTarget(mainMenu["Automatic"].GetValue<MenuSlider>("rRange").Value) &&
                RDamage(x)>= x.Health-GameObjects.Player.CalculateDamage(x,DamageType.Magical,1) &&
                !x.IsInvulnerable))
            {
                var rinput = R.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High)
                {
                    R.Cast(rinput.UnitPosition);
                }

            }
        }
    }
}