using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace myGame
{
    public class ActivityMessage : GameObject
    {
        public int x { get; private set; }
        public int y { get; private set; }
        private SpriteFont Message;
        private string message;
        private int height;
        private int width;
        Texture2D rect;
        private int middleX;
        private int middleY;
        private const float delay = 2; // seconds
        private float remainingDelay = delay;
        Vector2 coor = new Vector2(10, 20);
        public ActivityMessage(KittenWarsGame game, int x, int y, string message)
            : base(game)
        {
            this.x = x;
            this.y = y;
            this.message = message;
        }

        public override void LoadContent()
        {
            Message = Content.Load<SpriteFont>("score");
        }
        public override void Initialize() {
            this.height = 50;
            this.width = 200;
            
            this.middleX = (width/6) + x;
            this.middleY = (height/6) + y;
            
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            DrawRectangle(new Rectangle(x, y, width, height), Color.Fuchsia);
            SpriteBatch.DrawString(Message, this.message, new Vector2(middleX, middleY), Color.Black);
            SpriteBatch.End();


        }

        public override void Update(GameTime gameTime)
        {
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            remainingDelay -= timer;

            if (remainingDelay < 1)
            {
                game.RemoveObject(this);
            }
        }

        private void DrawRectangle(Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(game.GraphicsDevice, width, height);
                Color[] data = new Color[width * height];
                for (int i = 0; i < data.Length; ++i) { data[i] = Color.Chocolate; }
                rect.SetData(data);
            }
            SpriteBatch.Draw(rect, coords, color);
            
        }
    }
}
