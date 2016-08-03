using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Ball : Collidable
    {
        public Vector2 dir = Vector2.One;
        private readonly Texture2D ball;
        private readonly SpriteBatch spriteBatch;

        public Ball(int width, int height, Vector2 position, SpriteBatch spriteBatch) : base(width, height, position)
        {
            this.spriteBatch = spriteBatch;
            ball = TextureBuilder.BuildTexture(width, height, Color.White, spriteBatch);
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(ball, position);
        }

        public void Update(Paddle paddle)
        {
            if (this.CollidesWithTopOf(paddle) || this.Bounds.Top <= 0)
            {
                dir.Y *= -1;
                dir *= new Vector2(1.2f, 1.2f);
            }

            if (this.Bounds.Left <= 0 || this.Bounds.Right >= 256)
            {
                dir.X *= -1;
                dir *= new Vector2(1.2f, 1.2f);
            }

            position += dir;
        }
    }
}
