using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;


        //initialise everything for the enemy
        public List<Enemy_Controller> enemyList; //creates a enemy list from the Enemy_Controller class
        public Vector2 enemyX; //enemy position
        public Vector2 enemyY;
        public Vector2 move; //enemy movement
        public int windowHeight; //window height
        public Texture2D enemyTex; //enemy texture
        public Enemy_Controller enemy;
        


        //initialize everything for loosing
        public bool lost;
        private Texture2D lossTex;
        private Vector2 lossPos;
        public Vector2 windowBottom;





        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //change the screen size
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
            enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight, lost);
            enemyList = new List<Enemy_Controller>();
            windowHeight = Window.ClientBounds.Height;
            lost = false;
            lossPos = new Vector2(0, 0); //where to put the loss screen
            lossTex = Content.Load<Texture2D>("lossTex"); //how the loss screen looks
            windowBottom = new Vector2(1400, 1400);

            // place out the enemy locations
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    Vector2 enemyX = new Vector2 (j * 105,0);
                    Vector2 enemyY = new Vector2 (0, i * 100);
                    Vector2 move = new Vector2 (0, 10);
                    
                    enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight, lost);
                    enemyList.Add(enemy);



                }


                // TODO: use this.Content to load your game content here
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            //update the enemy
            foreach (Enemy_Controller enemy in enemyList) { 
            enemy.Update();

               
            }
            



            //check if you have lost
            
           


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

            if (enemy.loss == true)
            {

                spriteBatch.Draw(lossTex, lossPos, Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            

            base.Draw(gameTime);
        }
    }
}
