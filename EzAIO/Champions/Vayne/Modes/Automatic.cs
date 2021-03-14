using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Automatic
    {
        public static void CastE()
        {
            if (!AutomaticMenu.EsSliderButton.Enabled)
            {
                return;
            }

            if (AutomaticMenu.EsSliderButton.Value <= GameObjects.Player.HealthPercent)
            {
                return;
            }

            var target = GameObjects.EnemyHeroes.Where(x => x.IsValidTarget(E.Range) &&
                                                            x.IsMelee && !x.IsInvulnerable)
                .MaxBy(x => x.TotalAttackDamage);
            
            if (target == null)
            {
                return;
            }

            E.CastOnUnit(target);
        
        }

        public static void SemiE()
        {
            if (!ComboMenu.ESmiKeybind.Active || !E.IsReady())
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x=>x.IsValidTarget(E.Range) &&
                                                                    x.Position.DistanceToPlayer()<550))
            {
                var pred = E.GetPrediction(target);
                for (var i = 40; i < 425; i += 125)
                {
                    var flags = NavMesh.GetCollisionFlags(
                        pred.UnitPosition.ToVector2().Extend(GameObjects.Player.Position.ToVector2(), -i).ToVector3());
                    if (flags.HasFlag(CollisionFlags.Wall) || flags.HasFlag(CollisionFlags.Building))
                    {
                        E.CastOnUnit(target);
                    }
                }
            }
        }
    }
}