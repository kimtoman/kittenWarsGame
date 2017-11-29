using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class PowerUpPierce : PowerUp
    {
        public PowerUpPierce(KittenWarsGame game)
            :base(game)
        {
            this.textureName = "poweruppierce";
        }
    }
}
