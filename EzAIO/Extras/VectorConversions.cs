using EnsoulSharp.SDK;
using SharpDX;

namespace EzAIO.Extras
{
    public static class VectorConversions
    {
        public static Vector2 To2D(this Vector3 vector3)
        {
            return new Vector2(vector3.X, vector3.Z);
        }

        public static Vector3 To3D2(this Vector2 vector2)
        {
            return new Vector3(vector2.X, GameObjects.Player.Position.Z, vector2.Y);
        }

        public static Vector3 ToFlat3D(this Vector2 vector2)
        {
            return new Vector3(vector2.X, 0, vector2.Y);
        }

        public static Vector3 ToFlat3D(this Vector3 vector3)
        {
            return new Vector3(vector3.X, 0, vector3.Y);
        }
    }
}