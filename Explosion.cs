using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myGame
{
    class Explosion : GameObject
    {
        private Texture2D explosion;
        private int x;
        private int y;
        private string textureName;
        //Game Timer in seconds
        private const float delay = 2; // seconds
        private float remainingDelay = delay;

        public Explosion(KittenWarsGame game, int x, int y) 
            : base(game)
        {
            this.textureName = "explode";
            this.x = x;
            this.y = y;
        }

        public override void LoadContent()
        {
            explosion = Content.Load<Texture2D>(textureName);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(explosion, new Rectangle(x, y, 100, 100), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            //Game timer (20 seconds)
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            remainingDelay -= timer;

            if (remainingDelay < 1)
            {
                game.RemoveObject(this);
            }
        }
    }
}
