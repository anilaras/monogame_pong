using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;

        GraphicsDeviceManager _graphics;

        public Player(Vector2 startPosition, float speed, GraphicsDeviceManager graphics)
        {
            this.position = startPosition;
            this.speed = speed;
            _graphics = graphics;
        }

        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            float updatedPlayerSpeed = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (state.IsKeyDown(Keys.Up))
            {
                if (position.Y <= 0)
                {
                    position.Y = 0;
                }
                else
                    position.Y -= updatedPlayerSpeed;
            }

            if (state.IsKeyDown(Keys.Down))
            {
                if (position.Y >= _graphics.PreferredBackBufferHeight - texture.Height)
                {
                    position.Y = _graphics.PreferredBackBufferHeight - texture.Height;
                }
                else
                    position.Y += updatedPlayerSpeed;
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