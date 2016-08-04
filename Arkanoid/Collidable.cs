using Microsoft.Xna.Framework;

namespace Arkanoid
{
    public abstract class Collidable : ICollidable
    {
        protected readonly int width;
        protected readonly int height;
        protected Vector2 position;

        protected Collidable(int width, int height, Vector2 position)
        {
            this.width = width;
            this.height = height;
            this.position = position;
        }

        public Rectangle Bounds => new Rectangle((int)position.X, (int)position.Y, width, height);

        public bool CollidesWithRightOf(ICollidable collidable) =>
            Bounds.Intersects(collidable.Bounds);

        public bool CollidesWithLeftOf(ICollidable collidable) =>
            Bounds.Intersects(collidable.Bounds);

        public bool CollidesWithTopOf(ICollidable collidable) =>
            Bounds.Intersects(collidable.Bounds);

        public bool CollidesWithBottomOf(ICollidable collidable) =>
            Bounds.Intersects(collidable.Bounds);

        public bool CollidesWithAny(ICollidable collidable) =>
            Bounds.Intersects(collidable.Bounds);
    }
}
