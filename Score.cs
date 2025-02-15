using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourNamespace
{
    public static class Score
    {
        static int _playerScore;
        static int _enemyScore;
        static private SpriteFont _font;
        static private Color _color = Color.White;


        public static void LoadContent(SpriteFont font)
        {
            _font = font;
        }
        
        public static int getPlayerScore()
        {
            return _playerScore;
        }
        
        public static int getEnemyScore()
        {
            return _enemyScore;
        }
        
        public static void AddPoints(int points, bool isPlayer)
        {
            if (isPlayer)
                _playerScore += points;
            else
                _enemyScore += points;
        }

        public static void Reset()
        {
            _playerScore = 0;
            _enemyScore = 0;
        }

        public static void Draw(GraphicsDeviceManager graphicsDeviceManager, SpriteBatch spriteBatch)
        {
            Helper.TextCenterTop(graphicsDeviceManager, _font, $"{_playerScore} | {_enemyScore}", spriteBatch, _color);
            //spriteBatch.DrawString(_font, $"{_playerScore} | {_enemyScore}", _position, _color);
        }
    }
}