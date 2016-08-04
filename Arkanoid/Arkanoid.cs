using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class Arkanoid : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Paddle paddle;
        private Ball[] balls;
        private List<Brick> bricks;

        public Arkanoid()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 256;
            graphics.PreferredBackBufferHeight = 240;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            paddle = new Paddle(50, 10, new Vector2(120, 200), spriteBatch);

            balls = new Ball[]
            {
                new Ball(4, 4, new Vector2(100, 100), spriteBatch)
            };

            bricks = Brick.GenerateBricks(16, 5, 16, 8, spriteBatch).ToList();
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            base.Update(gameTime);

            foreach (var ball in balls)
            {
                ball.Update(paddle, ref bricks);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                paddle.TryMoveLeft();
            }
            if (state.IsKeyDown(Keys.Right))
            {
                paddle.TryMoveRight();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            paddle.Draw(gameTime);
            foreach (var ball in balls)
            {
                ball.Draw(gameTime);
            }

            foreach (var brick in bricks)
            {
                brick.Draw(gameTime);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
