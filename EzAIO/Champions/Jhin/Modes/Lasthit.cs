using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Jhin.Damage;
using static EzAIO.Champions.Jhin.Configs;
using static EzAIO.Champions.Jhin.Jhin;
namespace EzAIO.Champions.Jhin.Modes
{
    using static ChampionBases;
    static class Lasthit
    {
        public static void CastQ()
        {
            if (!LasthitMenu.QSliderButton.Enabled)
            {
                return;
            }

            if (LasthitMenu.QSliderButton.Value >= Player.ManaPercent)
            {
                return;   
            }

            if (!Extension.IsReloading() && LasthitMenu.QReloadBool.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyMinions.Where(x =>
                x.IsValidTarget(Q.Range) && QDamage(x) >= x.Health - Player.CalculateDamage(x, DamageType.Physical, 1)))
            {
                Q.CastOnUnit(target);
            }
        }
    }
}