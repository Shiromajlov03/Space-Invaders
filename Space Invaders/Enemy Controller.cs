using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using SharpDX.Win32;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Space_Invaders
{

    
    public class Enemy_Controller
    {
        public Vector2 posX {  get; private set; }
        public Vector2 posY { get; private set; }
        private Texture2D tex;
        public Vector2 movement { get; private set; }   
        public int windowHeight;
        public bool loss = false;


    public Enemy_Controller(Texture2D tex, Vector2 posX, Vector2 posY, Vector2 movement, int windowHeight, bool loss)
        {
            this.tex = tex;
            this.posX = posX;
            this.posY = posY;
            this.movement = movement;
            this.windowHeight = windowHeight;
            this.loss = loss;
        }


        public void Update()
        {
            if (posY.Y < 0 || posY.Y > windowHeight - tex.Height)
            {
                movement = movement * 0;

                loss = true;

            }
            posY = posY + movement;

            

            


        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(tex, posX+ posY , Color.White);

           
        }

       

    }

    

   

    
}
