using System.Collections.Generic;
using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX;

namespace EzAIO.Utilities.BaseUlt
{
    public class Bases
    {
        public class BaseChamps
        {
            public bool IsRecall = false;
            public bool Teleporting = false;
            
            public int NetworkID { get; set; }
            public Vector3 PosBase { get; set; }
            public Teleport.TeleportStatus TStatus { get; set; }
            public Teleport.TeleportType TType { get; set; }
            public int Duration { get; set; }
            public int Start { get; set; }

            public BaseChamps(AIHeroClient target, Vector3 pos, Teleport.TeleportStatus status,
                Teleport.TeleportType type, int duration, int start)
            {
                NetworkID = target.NetworkId;
                PosBase = pos;
                TStatus = status;
                TType = type;
                Duration = duration;
                Start = start;
            }
        }
        public static List<BaseChamps> GetChamps = new List<BaseChamps>();
        public static List<AIBaseClient> BaseULTChamps = new List<AIBaseClient>();
        public static int Delay = 0;
        public static int Speed = 0;
    }
}