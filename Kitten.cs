using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


namespace myGame
{
    class Kitten : GameObject
    {
        private static System.Random rnd = new System.Random((int)DateTime.Now.Ticks);

        private Texture2D kitten;
        public int x;
        public int y;
        public int width;
        public int height;
        public int startingY;
        private string textureName;
        bool isDead;

        public Kitten(KittenWarsGame game, bool IsGood)
            : base(game)
        {
            this.IsGood = IsGood;
            this.textureName = IsGood ? "pink" : "blue";
        }

        public override string Name { get { return "KITTEN"; } }

        public bool IsGood { get; private set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public override void LoadContent()
        {
            kitten = Content.Load<Texture2D>(textureName);
        }

        public override void Initialize()
        {
            isDead = false;
            x = rnd.Next(0, game.WindowWidth);
            y = rnd.Next(game.YAfterScoreBar, game.WindowHeight);
            startingY = y;
            width = 100;
            height = 100;
        }

        public override void Update(GameTime gameTime)
        {
            // Modify movement of Kittens to avoid cursor
            MouseState ms = Mouse.GetState();
            int x_pos = ms.X;
            int y_pos = ms.Y;

            if ((x - x_pos) < 1)
            {
                x--;
            }
            else
            {
                x++;
            }
            
            y++;
            if (y == game.WindowHeight)
            {
                y = game.YAfterScoreBar;
            }

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(kitten, new Rectangle(x, y, width, height), Color.White);
            SpriteBatch.End();
        }
    }
}
