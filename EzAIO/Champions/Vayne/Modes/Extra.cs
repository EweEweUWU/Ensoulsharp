using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Vayne.Configs;
namespace EzAIO.Champions.Vayne.Modes
{
    using static ChampionBases;
    static class Extra
    {
        public static void CastQ(AfterAttackEventArgs args)
        {
            if (!ComboMenu.QBool.Enabled)
            {
                return;
            }

            var target = args.Target as AIHeroClient;
            if (target == null || !Extension.ShouldCastQ(target))
            {
                return;
            }

            Q.Cast(Game.CursorPos);
        }
    }
}