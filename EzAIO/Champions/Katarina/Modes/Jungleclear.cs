using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
namespace EzAIO.Champions.Katarina.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastQ()
        {
            if (!JungleclearMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            var mob = GameObjects.Jungle.Where(x => x.IsValidTarget(Q.Range)).MaxBy(X => X.MaxHealth);
            if (mob == null)
            {
                return;
            }

            Q.CastOnUnit(mob);
        }

        public static void CastE()
        {
            if (Extension.eDelay > Game.Time)
            {
                return;
            }

            if (!JungleclearMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }
            var mob = GameObjects.Jungle.Where(x => x.IsValidTarget(E.Range)).MaxBy(X => X.MaxHealth);
            if (mob == null)
            {
                return;
            }

            var dagger = Extension.Daggers.FirstOrDefault(
                x => x.Distance(mob) < 450 && x.DistanceToPlayer() <= E.Range + 50);
            if (dagger != null)
            {
                E.Cast(dagger.Position.Extend(mob.Position, 200));
            }
            else
            {
                E.Cast(mob.Position.Extend(GameObjects.Player.Position, -50));
            }
        }

        public static void CastW()
        {
            if (!JungleclearMenu.WBool.Enabled || !W.IsReady())
            {
                return;
            }
            var mob = GameObjects.Jungle.Where(x => x.IsValidTarget(W.Range)).MaxBy(X => X.MaxHealth);

            if (mob == null)
            {
                return;
            }

            if (W.Cast(mob.Position))
            {
                Extension.eDelay = Game.Time + .75f;
            }
        }
    }
}