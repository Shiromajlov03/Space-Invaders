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
        public Vector2 posX { get; private set; }
        public Vector2 posY;
        public Texture2D tex;
        public Vector2 movement;
        public int windowHeight { get; private set; }
        public bool alive = true;
        public int hp;
        public Projectile_Controller bullet;
        public Vector2 finalPos;
        
        
       


    public Enemy_Controller(Texture2D tex, Vector2 posX, Vector2 posY, Vector2 movement, int windowHeight, bool alive, int hp, Projectile_Controller bullet)
        {
            this.tex = tex;
            this.posX = posX;
            this.posY = posY;
            this.movement = movement;
            this.windowHeight = windowHeight;
            this.alive = alive;
            this.hp = hp;
            this.bullet = bullet;

    }
        


        public void Update()
        {
            //stop moving if too low down
            if (posY.Y < 0 || posY.Y > windowHeight - tex.Height)
            {
                movement = movement * 0;
                
                
                
               
               

               

            }
            
            
            posY = posY + movement;
            finalPos = new Vector2(posX.X, posY.Y);
            
            
           

            


        }

        public void Draw(SpriteBatch spriteBatch) {

            //if the enemy is alive draw it
            if (alive == true)
            {
                spriteBatch.Draw(tex, posX + posY, Color.White);
            }

        }



        }

    

   

    
}
