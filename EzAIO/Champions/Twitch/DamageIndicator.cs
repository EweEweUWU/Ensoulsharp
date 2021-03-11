using System;
using System.Linq;
using EnsoulSharp.SDK;
using SharpDX;
using static EzAIO.Program;
using static EzAIO.Champions.Twitch.Configs;
using static EzAIO.Champions.Twitch.Damage;
namespace EzAIO.Champions.Twitch
{
    static class DamageIndicator
    {
        public static void EChamps()
        {
            if (!DrawConfig.Edmg.Enabled)
            {
                return;
            }

            foreach (var target in GameObjects.EnemyHeroes.Where(x => x.IsVisible &&
                                                                      !x.IsDead &&
                                                                      Extension.HasPoisonEffect(x, 15000f)))
            {
                var targetpos = target.HPBarPosition;
                var DMGporcent = MathUtil.Clamp((EDamage(target) / target.Health + target.AllShield) * 100, 0,100);
                if (DMGporcent != 0)
                {
                    DrawText(TextBold,Math.Round(DMGporcent).ToString()+"%",targetpos.X+50,targetpos.Y-70,(DMGporcent>=100) ? SharpDX.Color.Cyan : SharpDX.Color.White);
                }
            }
        }

        public static void EMobs()
        {
            if (!DrawConfig.EDmgJG.Enabled)
            {
                return;
            }
            foreach (var mobs in GameObjects.Jungle.Where(x => x.IsVisible &&
                                                               !x.IsDead && Extension.HasPoisonEffect(x, 15000f)))
            {
                if (mobs == null)
                {
                    return;
                }
                var mobpos = mobs.HPBarPosition;
                var DMGporcent = MathUtil.Clamp((EDamage(mobs) / mobs.Health + mobs.PhysicalShield) * 100, 0, 100);
                if (DMGporcent != 0)
                {
                    DrawText(TextBold,Math.Round(DMGporcent).ToString()+"%",mobpos.X+50,mobpos.Y-70,(DMGporcent>=100) ? SharpDX.Color.Cyan : SharpDX.Color.White);
                }

            }
        }
    }
}