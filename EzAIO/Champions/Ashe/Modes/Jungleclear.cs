using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Ashe.Configs;
using static EzAIO.Champions.Ashe.Ashe;
using static EzAIO.Champions.Ashe.Damage;
namespace EzAIO.Champions.Ashe.Modes
{
    using static ChampionBases;
    static class Jungleclear
    {
        public static void CastQ()
        {
            if (!JungleclearMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var mob = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Player.GetRealAutoAttackRange()));
            if (mob == null)
            {
                return;
            }

            Q.Cast();
        }

        public static void CastW(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.WSliderButton.Value >= Player.ManaPercent)
            {
                return;
            }

            var mob = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(W.Range));
            if (mob == null)
            {
                return;
            }
            W.Cast(mob);
        }
    }
}