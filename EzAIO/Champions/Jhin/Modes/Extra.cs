using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using EzAIO.Extras;
using static EzAIO.Champions.Jhin.Damage;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
using static EzAIO.Extras.Helps;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Extra
    {
        public static void CastQ(BeforeAttackEventArgs args)
        {
            var target = args.Target as AIBaseClient;
            if (!Extension.Has4Shot() || target.Health <= Player.GetAutoAttackDamage(target))
            {
                return;
            }

            if (!ComboMenu.QBool.Enabled)
            {
                return;
            }

            Q.CastOnUnit(target);
        }

        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!ComboMenu.QBool.Enabled)
            {
                return;
            }

            Q.CastOnUnit(args.Target);
        }

        public static void CastE()
        {
            if (!ComboMenu.EBool.Enabled)
            {
                return;
            }
            if (ComboMenu.EReloadBool.Enabled || !Extension.Has4Shot())
            {
                return;
            }

            var target = GameObjects.EnemyHeroes.FirstOrDefault(x=>x.IsValidTarget(E.Range));
            
            if (target == null)
            {
                return;
            }
            var einput = E.GetPrediction(target);
            if (einput.Hitchance >= HitChance.High && E.IsInRange(einput.CastPosition))
            {
                E.Cast(einput.CastPosition);
            }
        }
    }
}