using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace myGame
{
    class Background : GameObject
    {
        public Texture2D background;
        private string textureName;

        //Background music
        private Song music;

        public Background(KittenWarsGame game, string textureName) 
            : base(game)
        {
            this.textureName = textureName;
        }

        public override void LoadContent()
        {
            background = Content.Load<Texture2D>(textureName);

            //Load music
            music = Content.Load<Song>("music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(music);

        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Rectangle(0, 50, game.WindowWidth, game.WindowHeight), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
