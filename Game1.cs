using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongGame;
using YourNamespace;
using static Helper;

namespace monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    Point gameResolution = new Point(400, 400); // This can be whatever resolution your game renders at

    Player player;
    Enemy enemy;
    Ball ball;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = gameResolution.Y;
        _graphics.PreferredBackBufferWidth = gameResolution.X;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new Player(new Vector2(10,0), 200, _graphics);
        enemy = new Enemy(new Vector2(gameResolution.X - 20, 0), 200, _graphics);
        ball = new Ball(new Vector2(gameResolution.X/2, gameResolution.Y/2), new Vector2(5, 5), gameResolution.X, gameResolution.Y);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player.LoadContent(Content.Load<Texture2D>("Sprites/player"));
        enemy.LoadContent(Content.Load<Texture2D>("Sprites/player"));
        ball.LoadContent(Content.Load<Texture2D>("ball"));
        Score.LoadContent(Content.Load<SpriteFont>("font"));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.Update(gameTime);
        enemy.Update(gameTime, ball.getBallPosition());
        ball.Update(gameTime);
        
        if(player.GetBounds().Intersects(ball.GetBounds()))
        {
            ball.velocity.X = -(ball.velocity.X + 1);
        }

        if(enemy.GetBounds().Intersects(ball.GetBounds()))
        {
            ball.velocity.X = -(ball.velocity.X + 1);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {

        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);
        enemy.Draw(_spriteBatch);
        Score.Draw( _graphics ,_spriteBatch);
        _spriteBatch.End();
        
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

}
