using EnsoulSharp;
using EnsoulSharp.SDK;

namespace EzAIO.Champions.Ezreal
{
    class Extension
    {
        public static bool HasEssenceFlux(AIBaseClient target,float range)
        {
            return target.IsValidTarget(range) && target.HasBuff("ezrealwattach");
        }
    }
}