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
    class Gun : GameObject
    {
        private Texture2D gun;
        private int x;
        private int y;
        int width;
        int height;
        private string textureName;
        //Mouse states for single click detection
        private MouseState lastMouseState;
        private MouseState currentMouseState;

        public Gun(KittenWarsGame game) 
            : base(game)
        {
            this.textureName = "gun";
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public override string Name { get { return "GUN"; } }

        public override void LoadContent()
        {
            gun = Content.Load<Texture2D>(textureName);
        }

        public override void Initialize()
        {
            width = 100;
            height = 100;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(gun, new Rectangle(x, y, width, height), Color.White);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            x = mouseState.X;
            y = mouseState.Y;
            
            //Check for single mouse click
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (lastMouseState.LeftButton == ButtonState.Released &&
                currentMouseState.LeftButton == ButtonState.Pressed)
            {
                game.AddObject(new Bullet(game, mouseState.X, mouseState.Y));
            }
        }

    }
}
