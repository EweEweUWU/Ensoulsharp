using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using static EzAIO.Champions.Katarina.Configs;

namespace EzAIO.Champions.Katarina
{
    static class Extension
    {
        public static float eDelay = 0f;
        public static float rDealy = 0f;
        public static bool rTrigger = false;
        public static bool CastingR = false;
        public static List<GameObject> Daggers = new List<GameObject>();

        public static void GetDagger()
        {
            Daggers = MiscellaneousMenu.DetectLanded.Enabled
                ? GameObjects.AllGameObjects.Where(x => x.Name.Contains("_Dagger_Ground_")).ToList()
                : GameObjects.AllGameObjects.Where(x => x.Name.Contains("W_Indicator_Ally")).ToList();
        }

        public static void Magnet(BeforeMoveEventArgs args)
        {
            if (!MiscellaneousMenu.Magnet.Enabled)
            {
                return;
            }

            var dagger = Daggers.Where(x => x.IsValid &&
                                            x.DistanceToPlayer() < 500).OrderBy(x => x.DistanceToPlayer())
                .FirstOrDefault();
            if (dagger == null)
            {
                return;
            }

            if (dagger.Position.DistanceToPlayer() > 100)
            {
                args.MovePosition = dagger.Position;
            }
        }
    }
}