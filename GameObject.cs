using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    public abstract class GameObject : IUpdateable, IDrawable
    {
        protected KittenWarsGame game;

        public GameObject(KittenWarsGame game)
        {
            this.game = game;
        }

        public virtual string Name { get; }

        public virtual int DrawOrder { get { return 0; } }

        public virtual bool Enabled { get { return true; } }

        public virtual int UpdateOrder { get { return 0; } }

        public virtual bool Visible { get { return true; } }

        protected ContentManager Content { get { return game.Content; } }

        protected SpriteBatch SpriteBatch { get { return game.SpriteBatch; } }

        protected GraphicsDevice GraphicsDevice { get { return game.GraphicsDevice; } }

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public virtual void LoadContent() { }

        public virtual void Initialize() { }

        public abstract void Draw(GameTime gameTime);

        public abstract void Update(GameTime gameTime);
    }
}
