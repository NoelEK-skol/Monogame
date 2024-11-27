using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;
    SpriteFont fontScore;
    SpriteFont Vinst;

    Rectangle paddleLeft = new Rectangle(10, 200, 20, 100);
    Rectangle paddleRight = new Rectangle(770, 200, 20, 100);

    Ball ball;

    int scoreLeftPlayer = 0;
    int scoreRightPlayer = 0;
    bool gameOver = false;
    string strWin = "";

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        pixel = Content.Load<Texture2D>("Pixel");
        fontScore = Content.Load<SpriteFont>("Score");
        Vinst = Content.Load<SpriteFont>("Vinst");
        ball = new Ball(pixel);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        if(!gameOver){

            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.W) && paddleLeft.Y > 0){
                paddleLeft.Y-=8;
            }
            if (kState.IsKeyDown(Keys.S) && paddleLeft.Y + paddleLeft.Height < 480){
                paddleLeft.Y+=8;
            }

            if (kState.IsKeyDown(Keys.Up) && paddleRight.Y > 0){
                paddleRight.Y-=8;
            }
            if (kState.IsKeyDown(Keys.Down) && paddleRight.Y + paddleRight.Height < 480){
                paddleRight.Y+=8;
            }

            ball.update();
            
            if(ball.Rectangle.X <= 0){
                ball.Reset();
                scoreRightPlayer ++;
            }

            if(ball.Rectangle.X + ball.Rectangle.Width >= 800){
                ball.Reset();
                scoreLeftPlayer ++;
            }
            if(scoreLeftPlayer == 10){
                scoreLeftPlayer = 0;
                scoreRightPlayer = 0;
                strWin = "Left won!";
                gameOver = true;
            }
            if(scoreRightPlayer == 10){
                scoreLeftPlayer = 0;
                scoreRightPlayer = 0;
                strWin = "Right won!";
                gameOver = true;
            }
        }


        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore, scoreLeftPlayer.ToString(), new Vector2(30,10), Color.DarkOrange);
        _spriteBatch.DrawString(fontScore, scoreRightPlayer.ToString(), new Vector2(710,10), Color.DarkOrange);
        if(gameOver){
            _spriteBatch.DrawString(Vinst, strWin, new Vector2(275,40), Color.Black);
        }

        _spriteBatch.Draw(pixel,paddleLeft,Color.HotPink); //ritar ut figurer och ändrar färg
        _spriteBatch.Draw(pixel,paddleRight,Color.HotPink);
        ball.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
