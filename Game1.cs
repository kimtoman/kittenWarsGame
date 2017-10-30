//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
//using System.Collections.Generic;
//using System.Windows.Forms;
//namespace myGame
//{
//    /// <summary>
//    /// Kitty War
//    /// Get a score of 20 within 20 seconds to win
//    /// Score increases as you kill evil kittens
//    /// Score decreases as you kill good kittens
//    /// </summary>
    
//    public class KittenWarsGame1 : Game
//    {
//        public GraphicsDeviceManager graphics;
//        public SpriteBatch SpriteBatch;

//        //2D images
//        private List<Kitten> KittenCollection;
//        private List<Bullet> Bullets;

//        private Texture2D goodKitten;
//        private Texture2D gun;
//        private Texture2D explosion;
//        private Texture2D winner;
//        private Texture2D loser;
//        private Texture2D shot;

//        //Text
//        private SpriteFont font;

//        //Background music
//        private Song music;
       
//        //Score variables
//        private int scoreCount;
//        private int numGoodKilled;
//        private int numBadKilled;
//        private const int NUM_KITTENS = 10;

//        //X and Y coordinates
//        private List<int> evilX;
//        private List<int> evilY;
//        private List<int> goodX;
//        private List<int> goodY;
//        private List<int> shotX;
//        private List<int> shotY;
//        private int gunX;
//        private int gunY;
//        private int deadX;
//        private int deadY;

//        //Number of active shots
//        private int shotIndex;

//        //Boolean values for dead sprite, win/lose, and end of game
//        private bool isDead;
//        private bool didWin;
//        private bool gameOver;
//        private bool loggedIn;
//        //Mouse states for single click detection
//        private MouseState lastMouseState;
//        private MouseState currentMouseState;

//        //Collision detection variables
//        private Point goodFrameSize = new Point(50, 50);
//        private Point evilFrameSize = new Point(50, 50);
//        private Point shotFrameSize = new Point(50, 50);

//        private int shotCollRectOffset = 5;
//        private int goodCollRectOffset = 5;
//        private int evilCollRectOffset = 5;

//        //Game Timer in seconds
//        private const float delay = 20; // seconds
//        private float remainingDelay = delay;

//        private TextBox username;
//        private TextBox password;
//        //Random number generator
//        System.Random rnd = new System.Random();

//        //Constructor
//        public KittenWarsGame()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//        }

//        public ScoreState Score { get; private set; }
//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize()
//        {
//            Score = new ScoreState();

//            evilX = new List<int>();
//            goodX = new List<int>();
//            evilY = new List<int>();
//            goodY = new List<int>();
//            shotX = new List<int>();
//            shotY = new List<int>();
//            username = new TextBox();
//            password = new TextBox();
//            isDead = false;
//            didWin = false;
//            gameOver = false;
//            loggedIn = false;
//            shotIndex = 0;
//            scoreCount = 0;
//            numBadKilled = 0;
//            numGoodKilled = 0;

//            //Fill evil and good kitten x and y coordintes
//            for (int i = 0; i < NUM_KITTENS; i++)
//            {
//                evilX.Add(rnd.Next(0, 800));
//                goodX.Add(rnd.Next(0, 800));
//                evilY.Add(rnd.Next(50, 500));
//                goodY.Add(rnd.Next(50, 500));

//            }
//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent()
//        {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            SpriteBatch = new SpriteBatch(GraphicsDevice);

//            //Load textures
//            goodKitten = Content.Load<Texture2D>("pink");
//            evilKitten = Content.Load<Texture2D>("blue");
//            gun = Content.Load<Texture2D>("gun");
//            explosion = Content.Load<Texture2D>("explode");
//            background = Content.Load<Texture2D>("space");
//            winner = Content.Load<Texture2D>("winner");
//            loser = Content.Load<Texture2D>("loser");
//            shot = Content.Load<Texture2D>("gunShot");

//            //Load text
//            font = Content.Load<SpriteFont>("score");

//            //Load music
//            music = Content.Load<Song>("music");
//            MediaPlayer.IsRepeating = true;
//            MediaPlayer.Play(music);
//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// game-specific content.
//        /// </summary>
//        protected override void UnloadContent()
//        {
//            // TODO: Unload any non ContentManager content here
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime)
//        {
//            //I have no idea what this is, why is this here?
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || 
//                Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
//                Exit();

//            //Gun x and y  values equal mouse x and y values
//            MouseState mouseState = Mouse.GetState();
//            gunX = mouseState.X;
//            gunY = mouseState.Y;

//            //Incriment y coordinate to fall down the screen
//            //Set y back to 50 when at end of screen
//            for (int i = 0; i < NUM_KITTENS; i++)
//            {
//                evilY[i]++;
//                goodY[i]++;
//                if (evilY[i] == 480)
//                {
//                    evilY[i] = 50;
//                }
//                if (goodY[i] == 480)
//                {
//                    goodY[i] = 50;
//                }
//            }

//            //Move shot, left, accross the screen 
//            if (shotIndex != 0) {
//            for (int i = 0; i < shotIndex; i++)
//            {
//                shotX[i] = shotX[i] - 3;
//            }
//        }
//            //Game timer (20 seconds)
//            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
//            remainingDelay -= timer;
//            if (remainingDelay <= 0)
//            {
//                if (scoreCount < 10)
//                {
//                    didWin = false;
//                    gameOver = true;
//                    remainingDelay = delay;
//                }
//                else
//                {
//                    didWin = true;
//                    gameOver = true;
//                    remainingDelay = delay;
//                }
//            }

           
//            //Check for single mouse click
//            lastMouseState = currentMouseState;
//            currentMouseState = Mouse.GetState();
//            if (lastMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && 
//                currentMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
//            {
//                    shotX.Add(mouseState.X);
//                    shotY.Add(mouseState.Y);
//                    shotIndex++;
//            }
            
//            //Check if good kitten killed
//            if (CollideGood())
//            {
//                if (scoreCount != 0)
//                {
//                    scoreCount--;
//                }
//                numGoodKilled++;
//                isDead = true;

//            }

//            //Check if evil kitten killed
//            if (CollideEvil())
//            {
//                scoreCount++;
//                numBadKilled++;
//                isDead = true;
//            }

//        }

//        /// <summary>
//        /// Draw background, kittens, gun, text
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.Black);

//            SpriteBatch.Begin();
//            SpriteBatch.Draw(background, new Rectangle(0, 50, 800, 480), Color.White);
//            SpriteBatch.Draw(gun, new Rectangle(gunX, gunY, 100, 100), Color.White);
//            SpriteBatch.End();

//            DrawScoreBar();
//            DrawKittens();
//            DrawShot();

//            if (isDead)
//            {
//                DrawExplosion();
//                isDead = false;
//            }
//            if (gameOver)
//            {
//                if (didWin)
//                {
//                    DrawWinner();
//                }
//                else
//                {
//                    DrawLoser();
//                }
//            }
//            base.Draw(gameTime);
//        }
//        protected void DrawScoreBar()
//        {
//            SpriteBatch.Begin();
//            SpriteBatch.DrawString(font, "Score: " + scoreCount, new Vector2(10, 10), Color.White);
//            SpriteBatch.DrawString(font, "Evil kittens killed: " + numBadKilled, new Vector2(120, 10), Color.White);
//            SpriteBatch.DrawString(font, "Good kittens killed: " + numGoodKilled, new Vector2(340, 10), Color.White);
//            SpriteBatch.DrawString(font, "Time left: 00:" + (int)remainingDelay, new Vector2(600, 10), Color.White);
//            SpriteBatch.End();
//        }
//        protected void DrawKittens()
//        {
//            for (int i = 0; i < NUM_KITTENS; i++)
//            {
//                SpriteBatch.Begin();
//                SpriteBatch.Draw(goodKitten, new Rectangle(goodX[i], goodY[i], 100, 100), Color.White);
//                SpriteBatch.Draw(evilKitten, new Rectangle(evilX[i], evilY[i], 100, 100), Color.White);
//                SpriteBatch.End();
//            }
//        }

//        protected void DrawExplosion()
//        {
//            SpriteBatch.Begin();
//            SpriteBatch.Draw(explosion, new Rectangle(deadX, deadY, 200, 200),Color.White);
//            SpriteBatch.End();
//        }
//        protected void DrawWinner()
//        {
//            SpriteBatch.Begin();
//            SpriteBatch.Draw(winner, new Rectangle(0, 0, 800, 480), Color.White);
//            SpriteBatch.End();
//        }

//        protected void DrawLoser()
//        {
//            SpriteBatch.Begin();
//            SpriteBatch.Draw(loser, new Rectangle(0, 0, 800, 480), Color.White);
//            SpriteBatch.DrawString(font, "LOSER! You didn't save enough good kittens!", new Vector2(150, 240), Color.Black);
//            SpriteBatch.End();
//        }
//        protected void DrawShot()
//        {
//            for (int i = 0; i < shotIndex; i++)
//            {
//                SpriteBatch.Begin();
//                SpriteBatch.Draw(shot, new Rectangle(shotX[i], shotY[i], 50, 50), Color.White);
//                SpriteBatch.End();
//            }
//        }

//        protected void DrawLogin()
//        {

//        }
//        //Collision detection for evil kittens and gun shot
//        protected bool CollideEvil()
//        {
//            for (int j = 0; j < shotIndex; j++)
//            {
//                Rectangle gunRect = new Rectangle(
//                    shotX[j] + shotCollRectOffset,
//                    shotY[j] + shotCollRectOffset,
//                    (shotFrameSize.X - (shotCollRectOffset * 2)),
//                    (shotFrameSize.Y - (shotCollRectOffset * 2)));

//                for (int i = 0; i < NUM_KITTENS; i++)
//                {
//                    Rectangle evilRect = new Rectangle(
//                        evilX[i] + evilCollRectOffset,
//                        evilY[i] + evilCollRectOffset,
//                        (evilFrameSize.X - (evilCollRectOffset * 2)),
//                        (evilFrameSize.Y - (evilCollRectOffset * 2)));
//                    if (gunRect.Intersects(evilRect))
//                    {
//                        shotX.Remove(shotX[j]);
//                        shotY.Remove(shotY[j]);
//                        shotIndex--;
//                        deadX = evilX[i];
//                        deadY = evilY[i];
//                        evilX.Add(rnd.Next(0, 800));
//                        evilY.Add(rnd.Next(50, 500));
//                        evilX.Remove(evilX[i]);
//                        evilY.Remove(evilY[i]);
                       
//                        return true;
//                    }
//                }
//            }

//            return false;
//        }

//        //Collision detection for good kittens and gun shot
//        protected bool CollideGood()
//        {
//            for (int j = 0; j < shotIndex; j++)
//            {
//                Rectangle gunRect = new Rectangle(
//                    shotX[j] + shotCollRectOffset,
//                    shotY[j] + shotCollRectOffset,
//                    (shotFrameSize.X - (shotCollRectOffset * 2)),
//                    (shotFrameSize.Y - (shotCollRectOffset * 2)));

//                for (int i = 0; i < NUM_KITTENS; i++)
//                {
//                    Rectangle goodRect = new Rectangle(
//                        goodX[i] + goodCollRectOffset,
//                        goodY[i] + goodCollRectOffset,
//                        (goodFrameSize.X - (goodCollRectOffset * 2)),
//                        (goodFrameSize.Y - (goodCollRectOffset * 2)));
//                    if (gunRect.Intersects(goodRect))
//                    {
//                        shotX.Remove(shotX[j]);
//                        shotY.Remove(shotY[j]);
//                        shotIndex--;
//                        deadX = goodX[i];
//                        deadY = goodY[i];
//                        goodX.Add(rnd.Next(0, 800));
//                        goodY.Add(rnd.Next(50, 500));
//                        goodX.Remove(goodX[i]);
//                        goodY.Remove(goodY[i]);
             
//                        return true;
//                    }
//                }
//            }
//            return false;
//        }
//    }
//}
