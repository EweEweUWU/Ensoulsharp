using EnsoulSharp;
using EnsoulSharp.SDK;
using SharpDX.Direct3D9;

namespace EzAIO.Champions.Kalista
{
    class Extension
    {
        public static bool HasRendBuff(AIBaseClient target, float range)
        {
            return target.IsValidTarget(range) && target.HasBuff("kalistaexpungemarker");
        }

        public static bool HasRBuff(AIHeroClient target, float range)
        {
            return target.IsValidTarget(range) && target.HasBuff("kalistacoopstrikeally");
        }
    }
}