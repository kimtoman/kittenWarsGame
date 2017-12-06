using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class SpreadGun : Gun
    {
        const int UPWARD_SPREAD = 2;
        const int DOWNWARD_SPREAD = -2;

        public SpreadGun(KittenWarsGame game)
            :base(game)
        {
            this.textureName = "spreadgun";
        }

        public override void Fire(int x, int y)
        {
            // create the middle bullet
            game.AddObject(new SpreadBullet(game, x, y, 0));

            // create upper and lower bullets
            game.AddObject(new SpreadBullet(game, x, y, UPWARD_SPREAD));
            game.AddObject(new SpreadBullet(game, x, y, DOWNWARD_SPREAD));
        }
    }
}
