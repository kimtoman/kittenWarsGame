using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class SpreadGun : Gun
    {
        public SpreadGun(KittenWarsGame game)
            :base(game)
        {
            this.textureName = "spreadgun";
        }
    }
}
