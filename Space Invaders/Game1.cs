using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.XInput;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;


        //initialise everything for the enemy
         List<Enemy_Controller> enemyList; //creates a enemy list from the Enemy_Controller class
        Vector2 enemyX; //enemy position
        Vector2 enemyY;
        Vector2 move; //enemy movement
        int windowHeight; //window height
        Texture2D enemyTex; //enemy texture
        Enemy_Controller enemy;
         bool enemyAlive;
        Vector2 enemypos;
        


        //initialize everything for loosing
       
        private Texture2D lossTex;
        private Vector2 lossPos;
        


        int windowWidth;
        Texture2D bodyTextureP;
        Texture2D canonTextureP;
        Texture2D bulletTextureP;
        Vector2 posP;
        Vector2 posBulletP;
        bool rightP;
        bool leftP;
        
        Player_Controller player;
        int score;
        int hp;

        
        bool shootP;
        bool bulletAliveP = false;
        bool collision = false;

        Texture2D bodyTexturePmalfunction; ///

        Projectile_Controller bulletP;




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
            windowWidth = Window.ClientBounds.Width;
            enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight, enemyAlive, hp);
            enemyList = new List<Enemy_Controller>();
            Vector2 enemypos = new Vector2(enemyX.X, enemyY.Y );

            lossPos = new Vector2(0,0); //where to put the loss screen
            lossTex = Content.Load<Texture2D>("lossTex"); //how the loss screen looks
           
            enemyAlive = true;



            // place out the enemy locations
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    Vector2 enemyX = new Vector2 (j * 105,0);
                    Vector2 enemyY = new Vector2 (0, i * 100);
                    Vector2 move = new Vector2 (0, 2);
                    
                    enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, move, windowHeight, enemyAlive, hp);
                    enemyList.Add(enemy);
                   


                }


                

                bodyTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Body");
                canonTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Canon");
                bulletTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Bullet");


                posP.X = Window.ClientBounds.Width / 2 - bodyTextureP.Width / 2;
                posP.Y = Window.ClientBounds.Height - bodyTextureP.Height * 3;
                 
                score = 0;
                hp = 20;

                



                player = new Player_Controller(windowWidth, bodyTextureP, canonTextureP, posP, rightP, leftP, hp);

                posBulletP.X = Window.ClientBounds.Width + 10;
                bodyTexturePmalfunction = bodyTextureP;

                bulletP = new Projectile_Controller(bulletTextureP, posBulletP, shootP, bulletAliveP, collision, bodyTexturePmalfunction, posP, player);



                // TODO: use this.Content to load your game content here
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Window.Title = ("Space invaders Score: " + score + " hp: " + hp);


            //update the enemy and check for damage


            foreach (Enemy_Controller enemy in enemyList)
            {
                enemy.Update();
                if (enemy.posY.Y < 0 || enemy.posY.Y > windowHeight - enemy.tex.Height && enemy.alive == true)
                {
                    hp -= 1;
                    enemy.alive = false;







                }


            }
           
            player.Update();

            bulletP.Update();


            //if the bullet touches an enemy they are dead
            foreach (Enemy_Controller enemy in enemyList)
            {
                if (posBulletP == enemypos)
                {
                    score += 100;
                    enemyAlive = false;
                }
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

           
                for (int i = 0; i < enemyList.Count; i++)
                {




                    enemyList[i].Draw(spriteBatch);



                }

           
            //if your hp drops bellow 1 you get oofed
            if (hp < 1)
            {

                spriteBatch.Draw(lossTex, lossPos, Color.White);

                
            }

            if (hp > 1)
            {
                player.Draw(spriteBatch);
            }
            bulletP.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            

            base.Draw(gameTime);
        }
    }
}
