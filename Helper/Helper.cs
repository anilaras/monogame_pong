using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Helper
{
    public static Vector2 CenterOrigin(Texture2D texture)
    {
        return new Vector2(texture.Width / 2, texture.Height / 2);
    }
    
    public static void TextCenter(GraphicsDeviceManager graphicsDeviceManager, SpriteFont font, string text, SpriteBatch spriteBatch, Color color)
    {
        spriteBatch.DrawString(font,
         "Hello World",
          new Vector2(graphicsDeviceManager.PreferredBackBufferWidth / 2 - font.MeasureString(text).X / 2, graphicsDeviceManager.PreferredBackBufferHeight / 2 - font.MeasureString(text).Y / 2), color);
 
    }
    
    public static void TextCenter(GraphicsDeviceManager graphicsDeviceManager, SpriteFont font, string text, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font,
         text,
          new Vector2(graphicsDeviceManager.PreferredBackBufferWidth / 2 - font.MeasureString(text).X / 2, graphicsDeviceManager.PreferredBackBufferHeight / 2 - font.MeasureString(text).Y / 2), Color.White);
 
    }
    public static void TextCenterTop(GraphicsDeviceManager graphicsDeviceManager, SpriteFont font, string text, SpriteBatch spriteBatch, Color color)
    {
        spriteBatch.DrawString(font,
         text,
          new Vector2(graphicsDeviceManager.PreferredBackBufferWidth / 2 - font.MeasureString(text).X / 2, 0), color);
 
    }

    public static Vector2 TextMiddlePoint(SpriteFont font, string text)
    {
        return font.MeasureString(text) / 2;
    }
}