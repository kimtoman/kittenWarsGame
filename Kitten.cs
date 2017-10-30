using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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
        private string textureName;
        private bool isDead;

        public Kitten(KittenWarsGame game, bool IsGood)
            : base(game)
        {
            this.IsGood = IsGood;
            this.textureName = IsGood ? "pink" : "blue";
        }

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
            x = rnd.Next(0, 800);
            y = rnd.Next(50, 500);
            width = 100;
            height = 100;
        }

        public override void Update(GameTime gameTime)
        {
            y++;
            if (y == 480)
            {
                y = 50;
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
