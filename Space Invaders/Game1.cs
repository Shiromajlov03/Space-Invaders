using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        public List<Enemy_Controller> enemyList; //creates a enemy list from the Enemy_Controller class
        public Vector2 enemyX; //enemy position
        public Vector2 enemyY;
        public Vector2 move; //enemy movement
        public int windowHeight; //window height
        public Texture2D enemyTex; //enemy texture
        public Enemy_Controller enemy; 
        
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1400;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load in the enemy data
            enemyTex = Content.Load<Texture2D>("ball"); //insert enemy texture
            enemyX = new Vector2(0, 0);
            enemyY = new Vector2(0, 0);
            windowHeight = Window.ClientBounds.Height;
            enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight);
            enemyList = new List<Enemy_Controller>();
            windowHeight = Window.ClientBounds.Height;


            // place out the enemy locations
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    Vector2 enemyX = new Vector2 (j * 105,0);
                    Vector2 enemyY = new Vector2 (0, i * 100);
                    Vector2 move = new Vector2 (0, 2);
                    
                    enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight);
                    enemyList.Add(enemy);



                }


                // TODO: use this.Content to load your game content here
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Enemy_Controller enemy in enemyList) { 
            enemy.Update();
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //draws the enemy into their position
            for (int i = 0; i < enemyList.Count ; i++)
            {
               

                    enemyList[i].Draw(spriteBatch);

                
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
