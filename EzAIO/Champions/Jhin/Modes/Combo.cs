using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Combo
    {
        public static void CastQ()
        {
            var target = Q.GetTarget(Q.Range);
            if (target == null)
            {
                return;
            }

            if (ComboMenu.QBool.Enabled && ComboMenu.QReloadBool.Enabled)
            {
                Q.CastOnUnit(target);
            }
        }

        public static void CastW()
        {
            if (!ComboMenu.WBool.Enabled)
            {
                return;
            }

            if (Extension.IsUltShooting())
            {
                return;
            }

            var target = TargetSelector.GetTargets(W.Range,DamageType.Physical).Where(x => x.IsMarked() &&
                                                                       !x.IsInvulnerable &&
                                                                       (x.HasBuffOfType(BuffType.Slow) ||
                                                                        !ComboMenu.WCCBool.Enabled)).ToList();
            foreach (var enemy in target)
            {
                var winput = W.GetPrediction(enemy);
                if (winput.Hitchance >= HitChance.High && W.IsInRange(winput.CastPosition))
                {
                    W.Cast(winput.CastPosition);
                }
            }
        }

        public static void CastR()
        {
            if (!ComboMenu.RBool.Enabled)
            {
                return;
            }

            var validTarget = Extension.EnemiesInsideCone().ToList();
            if (validTarget.Any())
            {
                if (ComboMenu.RCursor.Enabled)
                {
                    var target = validTarget.MinBy(x => x.Distance(Game.CursorPos));
                    if (target == null)
                    {
                        return;
                    }

                    var rshotinput = RShot.GetPrediction(target);
                    if (rshotinput.Hitchance >= HitChance.High && RShot.IsInRange(rshotinput.CastPosition))
                    {
                        RShot.Cast(rshotinput.CastPosition);
                    }
                }
                else
                {
                    var target = validTarget.FirstOrDefault();
                    if (target == null)
                    {
                        return;
                    }
                    var rshotinput = RShot.GetPrediction(target);
                    if (rshotinput.Hitchance >= HitChance.High && RShot.IsInRange(rshotinput.CastPosition))
                    {
                        RShot.Cast(rshotinput.CastPosition);
                    }
                }
            }
            else
            {
                RShot.Cast(Game.CursorPos);
            }
        }
    }
}