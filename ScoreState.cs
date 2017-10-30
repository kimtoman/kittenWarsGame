using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myGame
{
    public class ScoreState
    {
        public ScoreState()
        {
        }

        public int ScoreCount { get; set; }
        public int NumGoodKilled { get; set; }
        public int NumBadKilled { get; set; }
    }
}
