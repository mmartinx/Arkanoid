using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Paddle : Collidable
    {
        private const int moveBy = 3;
        private readonly Texture2D paddle;
        private readonly SpriteBatch spriteBatch;

        public Paddle(int width, int height, Vector2 position, SpriteBatch spriteBatch) : base(width, height, position)
        {
            this.spriteBatch = spriteBatch;
            paddle = TextureBuilder.BuildTexture(width, height, Color.Chocolate, spriteBatch);
        }

        public bool TryMoveLeft()
        {
            if (position.X - moveBy > 0)
            {
                position.X-= moveBy;
                return true;
            }
            else
            {
                position.X = 0;
                return false;
            }
        }

        public bool TryMoveRight()
        {
            if (position.X + width < 256)
            {
                position.X+= moveBy;
                return true;
            }
            else
            {
                position.X = 256 - width;
                return false;
            }
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(paddle, position);   
        }
    }
}
