using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Damage;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Killsteal
    {
        public static void Cast()
        {
            if (Q.IsReady() && KillstealMenu.QBool.Enabled)
            {
                CastQ();
            }

            if (W.IsReady() && KillstealMenu.WBool.Enabled)
            {
                CastW();
            }

            if (R.IsReady() && Extension.IsUltShooting() && KillstealMenu.RShoot.Enabled)
            {   
                CastR();
            }
        }

        public static void CastQ()
        {
            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(Q.Range) &&
                                                                      QDamage(x) >= x.Health -
                                                                      Player.CalculateDamage(x, DamageType.Physical,
                                                                          1) &&
                                                                      !x.IsInvulnerable))
            {
                Q.CastOnUnit(target);
            }
        }

        public static void CastW()
        {
            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(W.Range) &&
                                                                      WDamage(x) >= x.Health -
                                                                      Player.CalculateDamage(x, DamageType.Physical,
                                                                          1) &&
                                                                      !x.IsInvulnerable))
            {
                var winput = W.GetPrediction(target);
                if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }

        public static void CastR()
        {
            if (!R.IsReady())
            {
                return;
            }
            foreach (var target in Extension.EnemiesInsideCone().Where(x =>
                RDamage(x) >= x.Health - Player.CalculateDamage(x, DamageType.Physical, 1)))
            {
                var rinput = Jhin.RShot.GetPrediction(target);
                if (rinput.Hitchance >= HitChance.High && Jhin.RShot.IsInRange(rinput.CastPosition))
                {
                    Jhin.RShot.Cast(rinput.CastPosition);
                }
            }
        }
    }
}