using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Kaisa.Configs;
namespace EzAIO.Champions.Kaisa.Modes
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

            if (JungleclearMenu.QSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            if (GameObjects.Jungle.Any(x => x.IsValidTarget(Q.Range)))
            {
                Q.Cast();
            }
            
        }

        public static void CastW(AfterAttackEventArgs args)
        {
            if (!JungleclearMenu.WSliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.WSliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var target = args.Target as AIMinionClient;
            if (target == null)
            {
                return;
            }

            if (target.GetBuffCount("kaisapassivemarker") != 3)
            {
                return;
            }

            W.Cast(target.Position);
        }

        public static void CastE()
        {
            if (!JungleclearMenu.ESliderButton.Enabled)
            {
                return;
            }

            if (JungleclearMenu.ESliderButton.Value >= GameObjects.Player.ManaPercent)
            {
                return;
            }

            var target = GameObjects.Jungle.FirstOrDefault(x => x.IsValidTarget(Q.Range));
            if (target == null)
            {
                return;
            }
            E.Cast();
        }
    }
}