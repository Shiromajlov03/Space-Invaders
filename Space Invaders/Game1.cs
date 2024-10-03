using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using SharpDX.XInput;
using static System.Formats.Asn1.AsnWriter;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        enum gameState 
        { 
            mainMenu, 
            Level1, 
            gameOver,
            
        }
        gameState current;
        
        
        //initialise everything for the enemy
       
        Vector2 enemyX; //enemy position
        Vector2 enemyY;
        Vector2 move; //enemy movement
        int windowHeight; //window height
        Texture2D enemyTex; //enemy texture
        Enemy_Controller enemy; //enemy
         bool enemyAlive; //if the enemy is alive or dead
        Vector2 enemypos; // enemies position
        Rectangle enemyHitbox; //enemies hitbox
        int scoreValue; //how much enemies give scorewise
        public Enemy_Controller[,] enemyArray;//creates a enemy array from the Enemy_Controller class
        //EnemyManager enemyMovement;
        bool moveDown;
        bool moveLeft;
        bool moveRight;

        //initialize everything for loosing

        private Texture2D lossTex; //loss texture change to loss screen later with enum
        private Vector2 lossPos; //loss position change to loss screen later with enum
        private SpriteFont spriteFont;
        Vector2 fontPos;

        int windowWidth; //window width
        Texture2D bodyTextureP; //players body texture
        Texture2D canonTextureP; //players canon texture
        Texture2D bulletTextureP; //bullet texture
        Vector2 posP; //player position
        Vector2 posBulletP; //players bullets position
        bool rightP; //going right
        bool leftP; //going left
        
        Player_Controller player; // player
        int score; //score
        int hp; // hp

        
        bool shootP; //shooting
        bool bulletAliveP = false; //is the bullet alive or dead
        bool collision = false; //has the bullet collided
        Rectangle bulletHitbox; //bullet hitbox


        Texture2D bodyTexturePmalfunction; //

        Projectile_Controller bulletP;
        private List<Projectile_Controller> bullets; // List to hold multiple bullets
        private float shootCooldown = 1f;  // Cooldown of 1 second
        private float timeSinceLastShot = 0f; //checking if the cooldown is done

        //main menu
        Texture2D startBackgroundTex;
        Texture2D startButtonTex;
        StartButton startButton;
        Vector2 startButtonPos;
        Texture2D animation;
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 200f;
        int frames = 0;
        Texture2D gameOver;
        List<Vector2> posList;
        Random rnd;
        Texture2D suprise;
        int randX;
        int randY;
        int stopX;
        int stopY;
        Vector2 suprisePos;

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
            current = gameState.mainMenu;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load in the enemy data
            enemyTex = Content.Load<Texture2D>("ball"); //insert enemy texture
            enemyX = new Vector2(0, 0);
            enemyY = new Vector2(0, 0);
            windowHeight = Window.ClientBounds.Height;
            windowWidth = Window.ClientBounds.Width;
            enemyHitbox = new Rectangle((int)enemyX.X,(int)enemyY.Y,enemyTex.Width,windowHeight);
            moveDown = false;
            moveLeft = true;
            moveRight = false;

            Vector2 enemypos = new Vector2(enemyX.X, enemyY.Y );

            lossPos = new Vector2(0,0); //where to put the loss screen
            lossTex = Content.Load<Texture2D>("lossTex"); //how the loss screen looks
            enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, enemyHitbox, move, windowHeight,windowWidth, enemyAlive, hp, scoreValue);
            enemyAlive = true;
            fontPos = new Vector2(windowWidth-200, 0);
            spriteFont = Content.Load<SpriteFont>("spritefont");


            
            startBackgroundTex = Content.Load<Texture2D>("Start Background");
            startButtonTex = Content.Load<Texture2D>("Start_Button");
            startButtonPos = new Vector2(windowWidth-925, windowHeight /2);
            startButton = new StartButton(startButtonTex, startButtonPos);
            animation = Content.Load<Texture2D>("SpriteSheet_Tanks");
            destRect = new Rectangle(450, 1000, 64, 60);
            gameOver = Content.Load<Texture2D>("gameOver");
            posList = new List<Vector2>();
            suprise = Content.Load<Texture2D>("fatPikachu");
           
            stopX = Window.ClientBounds.Width - suprise.Width;
            stopY = Window.ClientBounds.Height - suprise.Height;


            rnd = new Random();  // Initialize Random instance here
            stopX = Math.Max(1, Window.ClientBounds.Width - suprise.Width);
            stopY = Math.Max(1, Window.ClientBounds.Height - suprise.Height);

            for (int i = 0; i < 5; i++)
            {
                int randX = rnd.Next(0, stopX);
                int randY = rnd.Next(0, stopY);
                Vector2 suprisePos = new Vector2(randX, randY);
                posList.Add(suprisePos);
            }


            // place out the enemy locations
            enemyArray = new Enemy_Controller[5, 10];
                enemyArray = new Enemy_Controller[5, 10];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Vector2 enemyX = new Vector2(70 + j * 80, 0);
                        Vector2 enemyY = new Vector2(0, i * 80);
                        Vector2 move = new Vector2(1, 0);

                        // Assign different score values based on row or any other criteria
                        int enemyScore = 100; // Default score

                        //enemies in the top 2 rows give more points
                        if (i == 0)
                        {
                            enemyScore = 200;
                        }
                        else if (i == 1)
                        {
                            enemyScore = 150;
                        }

                        enemy = new Enemy_Controller(enemyTex, enemyX, enemyY, enemyHitbox, move, windowHeight, windowWidth, enemyAlive, hp, enemyScore);
                        enemyArray[i, j] = enemy;
                    }
                }
                //enemyMovement = new EnemyManager(enemyArray,enemy);


                // loads in player textures and bullet texture
                bodyTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Body");
                canonTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Canon");
                bulletTextureP = Content.Load<Texture2D>(@"SpriteSheet_Tanks_Bullet");

                //player position
                posP.X = Window.ClientBounds.Width / 2 - bodyTextureP.Width / 2;
                posP.Y = Window.ClientBounds.Height - bodyTextureP.Height * 3;
                //score and hp
                score = 0;
                hp = 5;


                player = new Player_Controller(windowWidth, bodyTextureP, canonTextureP, posP, rightP, leftP, hp);

                posBulletP.X = Window.ClientBounds.Width + 10;
                bodyTexturePmalfunction = bodyTextureP;
                bulletHitbox = new Rectangle((int)posBulletP.X, (int)posBulletP.Y, bulletTextureP.Width, bulletTextureP.Height);

                bulletP = new Projectile_Controller(bulletTextureP, posBulletP, bulletHitbox, shootP, bulletAliveP, collision, bodyTexturePmalfunction, posP, player);
                bullets = new List<Projectile_Controller>();  // Initialize the list to store bullets


                // TODO: use this.Content to load your game content here
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Window.Title = ("Space invaders");


            //update the enemy and check for damage

            if ( current == gameState.mainMenu)
            {
                if (startButton.isPressed())
                {
                   current  = gameState.Level1;  // Switch to Gameplay state
                }

                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (elapsed >= delay)
                {
                    if(frames >= 9)
                    {
                        frames = 0;
                    }
                    else
                    {
                        frames++;
                    }
                    elapsed = 0;
                }

                sourceRect = new Rectangle(32 * frames, 0, 32, 30);
            }
            if (current == gameState.Level1)
            {
                for (int i = 0; i < enemyArray.GetLength(0); i++)
                {
                    for (int j = 0; j < enemyArray.GetLength(1); j++)
                    {
                        if (enemyArray[i, j] != null)
                        {
                            enemyArray[i, j].Update(gameTime);
                        }
                        for (int k = 0; k < enemyArray.GetLength(1); k++)
                        {
                            for (int l = 0; l < enemyArray.GetLength(0); l++)
                            {
                                if (enemyArray[i, j] != null)
                                {


                                    if (enemyArray[i, j].posX.X < 1)
                                    {
                                        enemyArray[l, k].moveDown = true;
                                        enemyArray[l, k].moveLeft = false;
                                        enemyArray[l, k].moveRight = true;
                                        enemyArray[l, k].Update(gameTime);
                                    }
                                    if (enemyArray[i, j].posX.X > windowWidth - enemyTex.Width)
                                    {
                                        enemyArray[l, k].moveDown = true;
                                        enemyArray[l, k].moveLeft = true;
                                        enemyArray[l, k].moveRight = false;
                                        enemyArray[l, k].Update(gameTime);
                                    }
                                }
                            }

                        }
                        if (enemyArray[i, j] != null)
                        {
                            if (enemyArray[i, j].posY.Y > windowHeight - enemyArray[i, j].tex.Height && enemyArray[i, j].alive == true)
                            {
                                hp -= 1;
                                enemyArray[i, j].alive = false;
                            }
                        }
                    }
                }

                //enemyMovement.Update(gameTime);

                player.Update();


                // Update the cooldown timer
                timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Shooting logic with cooldown
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && timeSinceLastShot >= shootCooldown)
                {
                    ShootBullet();
                    timeSinceLastShot = 0f;  // Reset the cooldown timer after shooting
                }

                // Update all bullets
                for (int i = bullets.Count - 1; i >= 0; i--)
                {
                    bullets[i].Update(gameTime);

                    // Remove bullet if it is no longer alive (i.e., off-screen or collided)
                    if (!bullets[i].bulletAliveP)
                    {
                        bullets.RemoveAt(i);
                    }
                }


                //if the bullet touches an enemy they are dead
                // Update enemies and check for damage
                for (int i = 0; i < enemyArray.GetLength(0); i++)
                {
                    for (int j = 0; j < enemyArray.GetLength(1); j++)
                    {
                        if (enemyArray[i, j] != null && enemyArray[i, j].alive)
                        {
                            enemyArray[i, j].Update(gameTime);

                            // Check each bullet for collisions with the current enemy
                            foreach (var bullet in bullets)
                            {
                                if (bullet.BoundingBox.Intersects(enemyArray[i, j].BoundingBox) && bullet.bulletAliveP)
                                {
                                    // If a bullet hits the enemy, kill the enemy and add score
                                    score += enemyArray[i, j].scoreValue;  // Add the score value of the enemy
                                    enemyArray[i, j].alive = false;  // Mark enemy as dead
                                    bullet.bulletAliveP = false;     // Deactivate the bullet after hit
                                    break;  // Exit the loop as the enemy is now dead
                                }
                            }

                            // Handle enemies that reach the bottom of the screen
                            if (enemyArray[i, j].posY.Y > windowHeight - enemyArray[i, j].tex.Height && enemyArray[i, j].alive)
                            {
                                hp -= 1;
                                enemyArray[i, j].alive = false;
                            }
                        }
                    }
                }
                if (hp < 1)
                {
                    current = gameState.gameOver;
                }
                if (score > 6499)
                {
                    current = gameState.gameOver;
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        private void ShootBullet()
        {
            if (current == gameState.Level1)
            {
                // Create a new bullet at the player's position
                Vector2 bulletPosition = new Vector2(player.posP.X + bodyTextureP.Width / 2 - bulletTextureP.Width / 2, player.posP.Y);
                Projectile_Controller newBullet = new Projectile_Controller(bulletTextureP, bulletPosition, new Rectangle((int)bulletPosition.X, (int)bulletPosition.Y, bulletTextureP.Width, bulletTextureP.Height), false, true, false, bodyTextureP, player.posP, player);

                bullets.Add(newBullet);  // Add the new bullet to the list
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (current == gameState.mainMenu)
            {
                
                spriteBatch.Begin();

                spriteBatch.Draw(startBackgroundTex, new Rectangle(0, 0,1000,1400), Color.White);
                startButton.Draw(spriteBatch);
                spriteBatch.Draw(animation, destRect,sourceRect, Color.White);

                spriteBatch.End();
            }

            if (current == gameState.Level1)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();

                string output = "HP: " + hp + "      Score: " + score;
                spriteBatch.DrawString(spriteFont, output, fontPos, Color.Red);

                //draws the enemy into their position


                for (int i = 0; i < enemyArray.GetLength(0); i++)
                {

                    for (int j = 0; j < enemyArray.GetLength(1); j++)
                    {
                        if (enemyArray[i, j] != null && enemyArray[i, j].alive)
                        {
                            enemyArray[i, j].Draw(spriteBatch, Color.White);

                        }
                        //draws the top 2 rows different colors
                        if (i == 0)
                        {
                            enemyArray[i, j].Draw(spriteBatch, Color.Blue);
                        }
                        else if (i == 1)
                        {
                            enemyArray[i, j].Draw(spriteBatch, Color.Green);
                        }

                    }
                }


                
               

                if (hp > 1)
                {
                    player.Draw(spriteBatch);
                }
                // Draw all bullets
                foreach (var bullet in bullets)
                {
                    bullet.Draw(spriteBatch);
                }
                spriteBatch.End();

                // TODO: Add your drawing code here


            }

            if (current == gameState.gameOver)
            {

                spriteBatch.Begin();
                spriteBatch.Draw(startBackgroundTex, new Rectangle(0, 0, 1000, 1400), Color.White);
                spriteBatch.Draw(gameOver,new Vector2(150,700),Color.White);
                foreach (var pos in posList)
                {
                    spriteBatch.Draw(suprise, pos, Color.White);
                }
                spriteBatch.End();

            }
            base.Draw(gameTime);
        }
       
    }
}
