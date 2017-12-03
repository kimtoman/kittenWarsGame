using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace myGame
{
    class Bullet : GameObject
    {
        protected int width;
        protected int height;
        protected string textureName;
        
        public Texture2D bullet { get; private set; }
        public int x { get; protected set; }
        public int y { get; protected set; }

        public Bullet(KittenWarsGame game, int x, int y)
            : base(game)
        {
            this.textureName = "gunshot";
            this.x = x;
            this.y = y;
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public override void LoadContent()
        {
            bullet = Content.Load<Texture2D>(textureName);
        }

        public override void Initialize()
        {
            width = 50;
            height = 50;
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(bullet, new Rectangle(x, y, width, height), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            x -= 3;
            var kittens = game.GameObjectsOfType<Kitten>();
            foreach(var kitten in kittens)
            {
                if (collisionDetection(kitten))
                {
                    if (kitten.IsGood)
                    {
                        if(game.Score.ScoreCount != 0)
                        {
                            game.Score.ScoreCount--;
                        }
                        game.Score.NumGoodKilled++;
                        game.AddObject(new Kitten(game, true));
                    }
                    else
                    {
                        game.Score.ScoreCount++;
                        game.Score.NumBadKilled++;
                        game.AddObject(new Kitten(game, false));
                    }
                    game.RemoveObject(this);
                    game.RemoveObject(kitten);
                    break;
                }
            }    
        }

        protected bool collisionDetection(Kitten kitten)
        {
            return kitten.Rectangle.Intersects(this.Rectangle);
        }
    }
}
