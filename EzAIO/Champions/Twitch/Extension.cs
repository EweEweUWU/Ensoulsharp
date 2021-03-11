using EnsoulSharp;
using EnsoulSharp.SDK;
namespace EzAIO.Champions.Twitch
{
    class Extension
    {
        public static bool HasPoisonEffect(AIBaseClient target, float range)
        {
            return target.IsValidTarget(range) && target.HasBuff("TwitchDeadlyVenom");
        }

        public static bool HasInvisibleEffect(AIBaseClient player)
        {
            return player.HasBuff("TwitchHideInShadows");
        }

        public static bool HasFullEffect(AIBaseClient player)
        {
            return player.HasBuff("TwitchFullAutomatic");
        }

        public static int BuffStacks(AIBaseClient target)
        {
            return target.GetBuffCount("TwitchDeadlyVenom");
        }
    }
}