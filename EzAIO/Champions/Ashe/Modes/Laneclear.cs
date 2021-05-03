using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Ashe;
using static EzAIO.Champions.Ashe.Damage;
namespace EzAIO.Champions.Ashe.Modes
{
    using static ChampionBases;
    static class Laneclear
    {
        public static void CastQ()
        {
            if (!LaneclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LaneclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var minion = GameObjects.EnemyMinions.FirstOrDefault(x => x.IsValidTarget(Player.GetRealAutoAttackRange()));
            if (minion == null)
            {
                return;
            }

            if (!Extension.IsQActive())
            {
                Q.Cast();
            }
        }
    }
}