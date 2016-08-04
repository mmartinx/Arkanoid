using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Brick : Collidable
    {
        private readonly Texture2D brick;
        private readonly SpriteBatch spriteBatch;
        public Brick(int width, int height, Vector2 position, SpriteBatch spriteBatch) : base(width, height, position)
        {
            this.spriteBatch = spriteBatch;
            brick = TextureBuilder.BuildTexture(width, height, Color.LightGoldenrodYellow, spriteBatch);
        }

        public void Draw(GameTime draw)
        {
            spriteBatch.Draw(brick, position);   
        }

        public static IEnumerable<Brick> GenerateBricks(int width, int height, int rows, int cols, SpriteBatch spriteBatch)
        {
            for (var y = 0; y < cols; ++y)
            {
                for (var x = 0; x < rows; ++x)
                {
                    yield return new Brick(width, height, new Vector2(x * width, y * height), spriteBatch);
                }
            }
        }
    }
}
