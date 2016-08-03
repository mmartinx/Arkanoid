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

        public Rectangle Bounds => new Rectangle((int)(position.X - width / 2), (int)(position.Y - height / 2), width, height);

        public bool CollidesWithRightOf(ICollidable collidable) =>
                Bounds.Right >= collidable.Bounds.Left && 
                Bounds.Top >= collidable.Bounds.Bottom &&
                Bounds.Bottom <= collidable.Bounds.Top;

        public bool CollidesWithLeftOf(ICollidable collidable) =>
                Bounds.Left <= collidable.Bounds.Right &&
                Bounds.Top >= collidable.Bounds.Bottom &&
                Bounds.Bottom <= collidable.Bounds.Top;

        public bool CollidesWithTopOf(ICollidable collidable) =>
                Bounds.Bottom >= collidable.Bounds.Top &&
                Bounds.Right >= collidable.Bounds.Left &&
                Bounds.Left <= collidable.Bounds.Right;

        public bool CollidesWithBottomOf(ICollidable collidable) =>
                Bounds.Top >= collidable.Bounds.Bottom &&
                Bounds.Right >= collidable.Bounds.Left &&
                Bounds.Left <= collidable.Bounds.Right;

        public bool CollidesWithAny(ICollidable collidable) =>
            CollidesWithBottomOf(collidable) || CollidesWithTopOf(collidable) ||
            CollidesWithLeftOf(collidable) || CollidesWithRightOf(collidable);
    }
}
