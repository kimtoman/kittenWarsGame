﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    class PowerUpSpread : PowerUp
    {
        public PowerUpSpread(KittenWarsGame game)
            :base(game)
        {
            this.textureName = "powerupspread";
        }
    }
}
