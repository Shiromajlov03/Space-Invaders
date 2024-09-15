using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        public List<Enemy_Controller> enemyList;
        public Vector2 enemyX;
        public Vector2 enemyY;
        public Vector2 move;
        public int windowHeight;
        public Texture2D enemyTex;
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load in the enemy data
            enemyTex = Content.Load<Texture2D>("enemy_PlaceHolder"); //insert enemy texture
            enemyX = new Vector2(0, 0);
            move = new Vector2(0, 5);
            windowHeight = Window.ClientBounds.Height;
            enemy = new Enemy_Controller(enemyTex, enemyX, move, windowHeight);
            enemyList = new List<Enemy_Controller>();
            windowHeight = Window.ClientBounds.Height;


            // place out the enemy locations
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j< 3; j++)
                {
                    Vector2 enemyX = new Vector2(j * 50);
                   
                    move = new Vector2(0, 5);
                    enemy = new Enemy_Controller (enemyTex , enemyX, move, windowHeight);
                    enemyList.Add(enemy);
                    
                }

            }


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Enemy_Controller enemy in enemyList)
            {

                enemy.Draw(spriteBatch);

            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
