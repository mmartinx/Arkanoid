using Microsoft.Xna.Framework;

namespace Arkanoid
{
    public interface ICollidable
    {
        Rectangle Bounds { get; }
        bool CollidesWithAny(ICollidable collidable);
    }
}