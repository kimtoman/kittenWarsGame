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
        public Explosion(KittenWarsGame game, String textureName) 
            : base(game)
        {
            this.textureName = textureName;
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
            throw new NotImplementedException();
        }
    }
}
