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
    class PierceBullet : Bullet
    {
        public PierceBullet(KittenWarsGame game, int x, int y)
            :base(game, x, y)
        {
            this.textureName = "piercebullet";
        }

        public override void Update(GameTime gameTime)
        {
            x -= 3;
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
                    game.RemoveObject(kitten);
                    break;
                }
            }
        }
    }

}
