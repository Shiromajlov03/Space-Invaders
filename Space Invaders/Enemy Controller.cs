using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using SharpDX.Win32;
using SharpDX.XAudio2;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Space_Invaders
{


    public class Enemy_Controller
    {
        public Vector2 posX;
        public Vector2 posY;
        public Texture2D tex;
        public Vector2 movement;
        public int windowHeight { get; private set; }
        public int windowWidth { get; private set; }
        public bool alive = true;
        public int scoreValue;
        public int hp;
        public Vector2 finalPos;
        public Rectangle BoundingBox { get; private set; }
        public bool moveDown = false;
        public bool moveLeft = true;
        public bool moveRight = false;



        public Enemy_Controller(Texture2D tex, Vector2 posX, Vector2 posY, Rectangle BoundingBox, Vector2 movement, int windowHeight, int windowWidth, bool alive, int hp, int scoreValue)
        {
            this.tex = tex;
            this.posX = posX;
            this.posY = posY;
            this.movement = movement;
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
            this.alive = alive;
            this.hp = hp;
            this.scoreValue = scoreValue;
            BoundingBox = new Rectangle((int)posX.X,(int)posY.Y,tex.Width,tex.Height);
            this.BoundingBox = BoundingBox;
           

            
        }
        


        public void Update(GameTime gameTime)
        {
            if (alive == true)
            {
                movement = new Vector2(1, 0);
                
                if (moveDown == true)
                {

                    movement = new Vector2(0, 80);
                    posY = posY + movement;

                    moveDown = false;

                }

                if (moveLeft == true)
                {
                    movement = new Vector2(-1, 0);
                    posX = posX + movement;
                    posY = posY + new Vector2(0, 0);
                }

                if (moveRight == true)
                {
                    movement = new Vector2(1, 0);
                    posX = posX + movement;
                    posY = posY + new Vector2(0, 0);
                }




                finalPos = new Vector2(posX.X, posY.Y);

                
                
                BoundingBox = new Rectangle((int)posX.X, (int)posY.Y, tex.Width, tex.Height);






            }
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {

            //if the enemy is alive draw it
            if (alive == true)
            {
                spriteBatch.Draw(tex, new Vector2(posX.X, posY.Y), color); ;
            }

        }



    }

    

   

    
}
