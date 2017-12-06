using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace myGame
{
    
    public class Menu : GameObject

    {
        private Button playGame;
        private Button exit;
        private Button playAgain;
        private Texture2D mouse;
        private int x;
        private int y;
        private int playGameX;
        private int playGameY;
        private int exitX;
        private int exitY;
        public bool isStart { get; private set; }
        public bool isActive;
        MouseState currentMouseState;
        MouseState lastMouseState;
        Background background;
        public bool play { get; private set; }

        public Menu(KittenWarsGame game)
            :base(game)
        {
            playGameX = game.WindowWidth / 3;
            playGameY = game.WindowHeight / 3;
            exitX = game.WindowWidth / 3;
            exitY = (game.WindowHeight / 2) + 50;

            background = new Background(game, "menuBackground");
            playGame = new Button(game, "Play", playGameX, playGameY);
            playAgain = new Button(game, "Play Again", playGameX, playGameY);
            exit = new Button(game, "Exit", exitX, exitY);
            isStart = true;
            isActive = false;
        }
        
        public override void Initialize()
        {
            
            isStart = true;
            isActive = false;
            playGame.Initialize();
            exit.Initialize();
        }
        public override void LoadContent()
        {
            background.LoadContent();
            playGame.LoadContent();
            exit.LoadContent();
            playAgain.LoadContent();
            mouse = Content.Load<Texture2D>("hand");
        }
        public override void Draw(GameTime gameTime)
        {
            background.Draw(gameTime);
            if (isStart)
            {
                playGame.Draw(gameTime);
            } else
            {
                playAgain.Draw(gameTime);
            }
            playGame.Draw(gameTime);

            exit.Draw(gameTime);

            SpriteBatch.Begin();
            
            SpriteBatch.Draw(mouse, new Rectangle(x, y, 50, 50), Color.White);
            
            SpriteBatch.End();
            
        }

        public override void Update(GameTime gameTime)
        {
            playGame.Update(gameTime);
            exit.Update(gameTime);
            playAgain.Update(gameTime);
            //Check for single mouse click
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (lastMouseState.LeftButton == ButtonState.Released &&
                currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (playGame.isHovering(currentMouseState))
                {
                    this.isStart = false;
                    this.play = true;
                    this.isActive = true;
                }

                if (playAgain.isHovering(currentMouseState))
                {
                    this.play = true;
                    this.isActive = true;
                }

                if (exit.isHovering(currentMouseState))
                {
                    game.Exit();
                }
            }
            this.x = currentMouseState.X;
            this.y = currentMouseState.Y;
            
        }
    }
}
