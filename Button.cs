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
    public class Button : GameObject
    {
        private string text;
        private Texture2D background;
        private Texture2D hover;
        private Texture2D buttonState;
        private SpriteFont spriteText;
        private int middleX;
        private int middleY;
        private int x;
        private int y;
        private int width;
        private int height;
        private bool hovering;
        public Button(KittenWarsGame game, string text, int x, int y) :base(game)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            hovering = false;
        }
        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("button");
            hover = Content.Load<Texture2D>("hover");
            spriteText = Content.Load<SpriteFont>("score");
        }
        public override void Initialize()
        {
            this.height = 100;
            this.width = 300;

            this.middleX = (width / 3) + x + 22;
            this.middleY = (height / 3) + y;
            buttonState = background;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            if (hovering)
            {
                SpriteBatch.Draw(hover, new Rectangle(x, y, width, height), Color.White);
            } else
            {
                SpriteBatch.Draw(background, new Rectangle(x, y, width, height), Color.White);
            }
            SpriteBatch.DrawString(spriteText, text, new Vector2(middleX, middleY), Color.Black);
            SpriteBatch.End();
            
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            if (isHovering(mouseState))
            {
                hovering = true;
            } else
            {
                hovering = false;
            }
        } 

        public bool isHovering(MouseState mouse)
        {

            return (mouse.X >= this.x && mouse.X <= this.x + width && mouse.Y >= this.y && mouse.Y <= this.y + height);
        }
    }
}
