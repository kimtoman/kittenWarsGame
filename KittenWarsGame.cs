using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGame
{
    public class KittenWarsGame : Game
    {
        protected List<GameObject> gameObjects;
        protected Dictionary<string, GameObject> gameObjectLookup;
        public ScoreState Score { get; private set; }

        public KittenWarsGame()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            gameObjects = new List<GameObject>();
            gameObjectLookup = new Dictionary<string, GameObject>();
            Score = new ScoreState();

            gunObject = new Gun(this);
            gameStateObject = new GameState(this);
            managerObject = new PowerUpManager(this);
        }

        public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        public IEnumerable<GameObject> GameObjects
        {
            get { return gameObjects; }
        }

        public IEnumerable<T> GameObjectsOfType<T>()
            where T: GameObject
        {
            return gameObjects.OfType<T>();
        }

        public GameObject GameObjectByName(string name)
        {
            if (gameObjectLookup.ContainsKey(name))
            {
                return gameObjectLookup[name];
            } 
            else
            {
                return null;
            }
        }

        public void AddObject(GameObject obj)
        {
            obj.LoadContent();
            obj.Initialize();
            if (!string.IsNullOrEmpty(obj.Name))
            {
                if (!gameObjectLookup.ContainsKey(obj.Name))
                {
                    gameObjectLookup.Add(obj.Name, obj);
                }
                else
                {
                    gameObjectLookup[obj.Name] = obj;
                }
            }
            gameObjects.Add(obj);
        }

        public void RemoveObject(GameObject obj)
        {
            // obj.UnloadContent
            if (!string.IsNullOrEmpty(obj.Name))
            {
                if (gameObjectLookup.ContainsKey(obj.Name))
                {
                    gameObjectLookup.Remove(obj.Name);
                }
            }

            gameObjects.Remove(obj);
        }

        private Gun gunObject;
        private GameState gameStateObject;
        private PowerUpManager managerObject;

        protected override void LoadContent()
        {
            base.LoadContent();

            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Initialize()
        {
            base.Initialize();

            AddObject(gunObject);
            AddObject(gameStateObject);
            AddObject(managerObject);
            managerObject.Dispense();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.Black);

            foreach (var gameObject in gameObjects.OrderByDescending(obj => obj.DrawOrder))
            {
                gameObject.Draw(gameTime);
            }
        }
    }
}
