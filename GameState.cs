using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myGame
{
    class GameState : GameObject
    {
        private bool gameOver;
        private bool didWin;
        private bool loggedIn;
        private Background winner;
        private Background loser;
        private Background main;
        private ScoreState score;
        private SpriteFont endGameMessage;
        private SpriteFont scoreBarText;
        private const int NUM_KITTENS = 10;

        //Game Timer in seconds
        private const float delay = 20; // seconds
        private float remainingDelay = delay;

        public GameState(KittenWarsGame game)
            : base(game)
        {
            this.score = game.Score;
            winner = new Background(game, "winner");
            loser = new Background(game, "loser");
            main = new Background(game, "space");
        }

        public override int DrawOrder
        {
            get
            {
                return 1;
            }
        }

        public override void LoadContent()
        {
            endGameMessage = Content.Load<SpriteFont>("score");
            scoreBarText = Content.Load<SpriteFont>("score");
            main.LoadContent();
            loser.LoadContent();
            winner.LoadContent();
        }

        public override void Initialize()
        {
            //Fill evil and good kitten x and y coordintes
            for (int i = 0; i < NUM_KITTENS; i++)
            {
                game.AddObject(new Kitten(game, false));
                game.AddObject(new Kitten(game, true));
            
            }
            loser.Initialize();
            winner.Initialize();
            
        }

        public override void Draw(GameTime gameTime)
        {
            DrawMainBackground();
            DrawScoreBar();


            if (gameOver)
            {
                if (didWin)
                {
                    DrawWinner();
                }
                else
                {
                    DrawLoser();
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            //Game timer (20 seconds)
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            remainingDelay -= timer;

            if (remainingDelay <= 0)
            {
                if (score.ScoreCount < 10)
                {
                    didWin = false;
                    gameOver = true;
                    remainingDelay = delay;
                }
                else
                {
                    didWin = true;
                    gameOver = true;
                    remainingDelay = delay;
                }

            }
        }

        protected void DrawScoreBar()
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(scoreBarText, "Score: " + score.ScoreCount, new Vector2(10, 10), Color.White);
            SpriteBatch.DrawString(scoreBarText, "Evil kittens killed: " + score.NumBadKilled, new Vector2(120, 10), Color.White);
            SpriteBatch.DrawString(scoreBarText, "Good kittens killed: " + score.NumGoodKilled, new Vector2(340, 10), Color.White);
            SpriteBatch.DrawString(scoreBarText, "Time left: 00:" + (int)remainingDelay, new Vector2(600, 10), Color.White);
            SpriteBatch.End();
        }
        protected void DrawWinner()
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(winner.background, new Rectangle(0, 0, 800, 480), Color.White);
            SpriteBatch.End();
        }

        protected void DrawLoser()
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(loser.background, new Rectangle(0, 0, 800, 480), Color.White);
            SpriteBatch.DrawString(endGameMessage, "LOSER! You didn't save enough good kittens!", new Vector2(150, 240), Color.Black);
            SpriteBatch.End();
        }

        protected void DrawMainBackground()
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(main.background, new Rectangle(0, 50, 800, 480), Color.White);
            SpriteBatch.End();
        }
    }
}
