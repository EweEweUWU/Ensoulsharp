using System.Collections.Generic;
using System.Linq;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;
using static EzAIO.Bases.ChampionBases;

namespace EzAIO.Champions.Draven
{
    public class Extension
    {
        public static readonly List<Mark> Marks = new List<Mark>();

        public class Mark
        {
            public Mark(GameObject obj, int newtworkId, Vector3 pos, int endTime)
            {
                this.Object = obj;
                this.NewtworkId = newtworkId;
                this.Pos = pos;
                this.EndTime = endTime;
            }
            public GameObject Object { get; }
            public int NewtworkId { get; }
            public Vector3 Pos { get; }
            public int EndTime { get; }
        }

        public static readonly float MarksBoudingRadius = 150 - GameObjects.Player.BoundingRadius;
        public static readonly float[] WBoost = {0f, 1.4f, 1.45f, 1.5f, 1.55f, 1.6f, 1.6f};
        public static float eDelay = 0f;

        public static int GetNumberAxesActives()
        {
            var buffCount = (int) GameObjects.Player.GetBuffCount("DravenSpinningAttack");
            var markCount = Marks.Count();
            var flyingAxes = GameObjects.AllGameObjects.Count(x =>
                x.IsValid && x is MissileClient && x.Name.Contains("DravenSpinningAttack"));
            return buffCount + markCount + flyingAxes;
        }

        public static bool IsMarkNormallyCatchable(Mark mark)
        {
            return GameObjects.Player.MoveSpeed * (mark.EndTime - Game.Time) >= mark.Object.DistanceToPlayer();
        }

        public static bool IsMarkBoostedCatchable(Mark mark)
        {
            var boosSpeed = GameObjects.Player.MoveSpeed * WBoost[W.Level];
            return boosSpeed * (mark.EndTime - Game.Time) >= mark.Object.DistanceToPlayer();
        }

        public static bool HasAxeInHand()
        {
            return GameObjects.Player.HasBuff("DravenSpinningAttack");
        }

        public static bool CanCatchAxe()
        {
            return Marks.Any(x => x.Object.DistanceToPlayer() < MarksBoudingRadius);
        }
    }
}