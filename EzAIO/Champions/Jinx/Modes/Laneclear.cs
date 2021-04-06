using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jinx.Configs;
using static EzAIO.Champions.Jinx.Jinx;
using static EzAIO.Champions.Jinx.Damage;
namespace EzAIO.Champions.Jinx.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QSliderButton.Enabled || !LaneclearMenu.SwapBool.Enabled)
            {
                return;
            }
            if (LaneclearMenu.QSliderButton.Value > Player.ManaPercent)
            {
                if (Extension.ActivatedRockets)
                {
                    Q.Cast();
                }
                return;
            }

            var minion = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(Extension.RocketRange) &&
                                                             Player.GetAutoAttackDamage(x)>=x.Health)
                .OrderBy(x => x.MaxHealth).ThenByDescending(x => x.Health).FirstOrDefault();
            if (minion == null || !minion.IsValid)
            {
                return;
            }

            if (Extension.Swap(minion))
            {
                Q.Cast();
            }
        }

        public static void CastQAOE()
        {
            if (!LaneclearMenu.QSliderButton.Enabled)
            {
                return;
            }
            if (LaneclearMenu.QSliderButton.Value > Player.ManaPercent)
            {
                if (Extension.ActivatedRockets)
                {
                    Q.Cast();
                }
                return;
            }

            foreach (var minion in GameObjects.EnemyMinions.Where(x=>x.IsValidTarget(Extension.RocketRange)))
            {
                if (Extension.KillableMinionsCount(minion) < LaneclearMenu.QCountSlider.Value)
                {
                    continue;
                }

                if (!Extension.ActivatedRockets)
                {
                    Q.Cast();
                    return;
                }
            }
        }
    }
}