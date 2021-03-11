using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Combo
    {
        public static void CastE()
        {
            if (!ComboMenu.Estart.Enabled ||
                GameObjects.Player.Distance(Game.CursorPos) <= GameObjects.Player.GetRealAutoAttackRange())
            {
                return;
            }

            var etarget = TargetSelector.GetTarget(E.Range);
            if (etarget == null ||
                etarget.IsInvulnerable ||
                etarget.DistanceToPlayer() <= GameObjects.Player.GetRealAutoAttackRange(etarget))
            {
                return;
            }

            var posAfterE = GameObjects.Player.Position.Extend(Game.CursorPos, 425f);
            if (posAfterE.IsUnderEnemyTurret() ||
                posAfterE.CountEnemyHeroesInRange(1000f) >= 3 ||
                etarget.Distance(posAfterE) >= GameObjects.Player.GetRealAutoAttackRange())
            {
                return;
            }

            E.Cast(posAfterE);
        }

        public static void CastR()
        {
            if (Q.IsReady() || W.IsReady() || E.IsReady() || Extension.IsCulling())
            {
                return;
            }

            var rtarget = GameObjects.EnemyHeroes.Where(x =>
                x.IsValidTarget(R.Range) &&
                !x.IsInvulnerable).MinBy(o=>o.Health);
            if (rtarget == null ||
                Extension.HasPassive() &&
                rtarget.DistanceToPlayer() <= GameObjects.Player.GetRealAutoAttackRange(rtarget))
            {
                return;
            }

            if (ComboMenu.Rbool.Enabled)
            {
                R.Cast(rtarget);
            }
        }

        public static void SemiR()
        {
            if (!ComboMenu.RSemi.Active || !R.IsReady())
            {
                return;
            }

            var rtraget = TargetSelector.GetTarget(R.Range);
            if (rtraget == null)
            {
                return;
            }

            R.Cast(rtraget.Position);
        }
    }
}