using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YourNamespace;

namespace PongGame
{
    public class Ball
    {
        private Texture2D texture;
        private Vector2 position;
        public Vector2 velocity;
        private int screenWidth;
        private int screenHeight;
        private float scale = 0.2f;
        public Ball(Vector2 initialPosition, Vector2 initialVelocity, int screenWidth, int screenHeight)
        {
            this.position = initialPosition;
            this.velocity = initialVelocity;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public Vector2 getBallPosition()
        {
            return position;
        }

        public void LoadContent(Texture2D texture)
        {
            this.texture = texture;
            // Change the color of the loaded texture
            Color[] data = new Color[texture.Width * texture.Height];
            texture.GetData(data);
            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i].A != 0) // Ignore transparent pixels
                {
                    data[i] = Color.Red; // Change to desired color
                }
            }
            texture.SetData(data);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            // Check for collision with screen boundaries
            if (position.X <= 0)
            {
                Score.AddPoints(1, false);
                Reset(new Vector2(screenWidth / 2, screenHeight / 2), new Vector2(5, new Random().Next(1,5+Score.getEnemyScore())));
            }
            if(position.X + (texture.Width * scale) >= screenWidth)
            {
                Score.AddPoints(1, true);
                Reset(new Vector2(screenWidth / 2, screenHeight / 2), new Vector2(5, new Random().Next(1,5+Score.getPlayerScore())));
            }

            if (position.Y <= 0 || position.Y + (texture.Height * scale) >= screenHeight)
            {
                velocity.Y = -velocity.Y;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void Reset(Vector2 newPosition, Vector2 newVelocity)
        {
            position = newPosition;
            velocity = newVelocity;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int) (texture.Width * scale), (int) (texture.Height * scale));
        }
    }
}