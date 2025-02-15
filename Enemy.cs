using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public class Enemy
    {
        private Texture2D texture;
        private Vector2 position;
        GraphicsDeviceManager _graphics;

        private float speed;

        public Enemy(Vector2 startPosition, float speed, GraphicsDeviceManager graphics)
        {
            this.position = startPosition;
            this.speed = speed;
            _graphics = graphics;
        }

        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update(GameTime gameTime, Vector2 ballPosition)
        {
            if (ballPosition.Y < position.Y)
            {
                if (position.Y < 0)
                {
                    position.Y = 0;
                }
                else
                position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (ballPosition.Y > position.Y)
            {
                if (position.Y > _graphics.PreferredBackBufferHeight - texture.Height)
                {
                    position.Y = _graphics.PreferredBackBufferHeight - texture.Height;
                }
                else
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}