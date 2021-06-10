using System.Linq;
using EnsoulSharp.SDK;
using EzAIO.Bases;
using static EzAIO.Champions.Katarina.Configs;
namespace EzAIO.Champions.Katarina.Modes
{
    using static ChampionBases;
    static class Harass
    {
        public static void CastHarass()
        {
            var hMode = HarassMenu.HarassModeList.Index;
            if (hMode == 0)
            {
                CastQ();
                if (!Q.IsReady() || !HarassMenu.QBool.Enabled)
                {
                    CastE();
                }
                CastW();
            }

            if (hMode == 1)
            {
                CastE();
                CastW();
                CastQ();
            }
        }

        private static void CastQ()
        {
            if (!HarassMenu.QBool.Enabled || !Q.IsReady())
            {
                return;
            }

            var qtarget = Q.GetTarget();
            if (qtarget == null)
            {
                return;
            }

            Q.CastOnUnit(qtarget);
        }

        private static void CastW()
        {
            if (!HarassMenu.WBool.Enabled || !W.IsReady())
            {
                return;
            }

            var wtarget = W.GetTarget();
            if (wtarget == null)
            {
                return;
            }

            W.Cast();
        }

        private static void CastE()
        {
            if (!HarassMenu.EBool.Enabled || !E.IsReady())
            {
                return;
            }

            var daggerTarget = E.GetTarget();
            if (daggerTarget != null)
            {
                var dagger = Extension.Daggers.FirstOrDefault(
                    x => x.Distance(daggerTarget) < 450 && x.DistanceToPlayer() <= E.Range + 250);
                if (dagger != null)
                {
                    E.Cast(dagger.Position.Extend(daggerTarget.Position, 200));
                }
            }

            var etarget = E.GetTarget();
            var eMode = HarassMenu.EModeList.Index;
            if (etarget != null)
            {
                if (HarassMenu.ESaveBool.Enabled)
                {
                    return;
                }

                if (eMode == 0)
                {
                    E.Cast(etarget.Direction.Extend(etarget.Position, -50));
                }

                if (eMode == 1)
                {
                    E.Cast(etarget.Direction.Extend(etarget.Position, 50));
                }

                if (eMode == 2)
                {
                    if (!R.IsReady() || R.Level == 0)
                    {
                        E.Cast(etarget.Direction.Extend(etarget.Position, 50));
                    }

                    if (R.IsReady())
                    {
                        E.Cast(etarget.Direction.Extend(etarget.Position, -50));
                    }
                }
            }
            
        }
    }
}