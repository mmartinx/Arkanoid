using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Brick : Collidable
    {
        private readonly Texture2D brick;
        private readonly SpriteBatch spriteBatch;
        private readonly Color color = Color.LightGoldenrodYellow;

        public Brick(int width, int height, Vector2 position, SpriteBatch spriteBatch) : base(width, height, position)
        {
            this.spriteBatch = spriteBatch;
            brick = TextureBuilder.BuildTexture(width, height, color, spriteBatch);
        }

        public Brick(int width, int height, Vector2 position, SpriteBatch spriteBatch, Texture2D texture) : base(width, height, position)
        {
            this.spriteBatch = spriteBatch;
            brick = texture;
        }

        public void Draw(GameTime draw)
        {
            spriteBatch.Draw(brick, position);   
        }

        public static IEnumerable<Brick> GenerateBricks(int width, int height, int rows, int cols, SpriteBatch spriteBatch)
        {
            Texture2D texture = TextureBuilder.BuildTexture(width, height, color, spriteBatch);
            for (var y = 0; y < cols; ++y)
            {
                for (var x = 0; x < rows; ++x)
                {
                    yield return new Brick(width, height, new Vector2(x * width, y * height), spriteBatch, texture);
                }
            }
        }
    }
}
