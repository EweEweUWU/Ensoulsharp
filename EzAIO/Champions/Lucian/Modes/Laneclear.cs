using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Lucian.Configs;
namespace EzAIO.Champions.Lucian.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QSlider.Enabled)
            {
                return;
            }

            if (LaneclearMenu.QSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(Q.Range) &&
                                                              x.DistanceToPlayer() <= Q.Range).ToList();
            foreach (var minion in minions)
            {
                if (GameObjects.EnemyMinions.Count(x => Extension.QRectangle(minion).IsInside(x.Position)) >=
                    LaneclearMenu.QCount.Value)
                {
                    Q.CastOnUnit(minion);
                }
            }
        }

        public static void CastW()
        {
            if (!LaneclearMenu.WSlider.Enabled)
            {
                return;
            }

            if (LaneclearMenu.WSlider.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(W.Range) &&
                                                              x.DistanceToPlayer() <= W.Range).ToList();
            var farmLocation = W.GetCircularFarmLocation(minions, W.Width);
            if (farmLocation.MinionsHit < LaneclearMenu.WCount.Value)
            {
                return;
            }

            W.Cast(farmLocation.Position);
        }
    }
}