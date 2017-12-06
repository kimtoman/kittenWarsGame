using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace myGame
{
    class PowerUp : GameObject
    {
        private static System.Random rnd = new System.Random((int)DateTime.Now.Ticks);
        protected Texture2D powerUpLogo;
        protected string textureName = null;
        protected Gun gun;
        protected string managerName = "MANAGER";

        public int x;
        public int y;
        public int width;
        public int height;

        public PowerUp(KittenWarsGame game)
            : base(game)
        {
            // Get reference to gun object for collison detection
            gun = (Gun)game.GameObjectByName("GUN");
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public override void Initialize()
        {
            width = 75;
            height = 75;
            x = rnd.Next(0, 800);
            y = rnd.Next(0, 200);
        }

        public override void LoadContent()
        {
            powerUpLogo = Content.Load<Texture2D>(textureName);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(powerUpLogo, new Rectangle(x, y, width, height), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            y++;

            if(collisionDetection(gun))
            {
                var manager = (PowerUpManager)game.GameObjectByName(managerName);
                manager.ToggleActive();
                game.RemoveObject(this);
            }
            
            if (y == 480)
            {
                y = 50;
            }
        }

        protected bool collisionDetection(Gun gun)
        {
            return gun.Rectangle.Intersects(this.Rectangle);
        }
    }
}
