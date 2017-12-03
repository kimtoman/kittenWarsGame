using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class PierceGun : Gun
    {
        public PierceGun(KittenWarsGame game)
            :base(game)
        {
            this.textureName = "piercegun";
        }

        public override void Fire(int x, int y)
        {
            game.AddObject(new PierceBullet(game, x, y));
        }
    }
}
