using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public static class TextureBuilder
    {
        public static Texture2D BuildTexture(int width, int height, Color color, SpriteBatch spriteBatch)
        {
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, width, height);
            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; ++i)
                data[i] = color;

            rect.SetData(data);
            return rect;
        }
    }
}
