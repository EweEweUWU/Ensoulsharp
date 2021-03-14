using System.Runtime.CompilerServices;
using SharpDX;

namespace EzAIO.Extras
{
    public static class NormalizedEx
    {
        public static Vector2 Normalized(this Vector2 vector)
        {
            return Vector2.Normalize(vector);
        }

        public static Vector3 Normalized(this Vector3 vector)
        {
            return Vector3.Normalize(vector);
        }
    }
}