using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace myGame
{
    class SpreadBullet : Bullet
    {
        private int yIncrement;

        public SpreadBullet(KittenWarsGame game, int x, int y, int increment)
            :base(game, x, y)
        {
            this.textureName = "spreadbullet";
            yIncrement = increment;
        }
        public override void Initialize()
        {
            width = 25;
            height = 25;
        }

        public override void Update(GameTime gameTime)
        {
            x -= 3;
            y = y + yIncrement;

            var kittens = game.GameObjectsOfType<Kitten>();
            foreach (var kitten in kittens)
            {
                if (collisionDetection(kitten))
                {
                    if (kitten.IsGood)
                    {
                        if (game.Score.ScoreCount != 0)
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
    }


}
