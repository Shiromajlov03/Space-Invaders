using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Space_Invaders
{

    
    public class Enemy_Controller
    {
        public Vector2 posX {  get; private set; }
        public Vector2 posY { get; private set; }
        private Texture2D tex;
        public Vector2 movement { get; private set; }   
        public int windowHeight;
        public Enemy_Controller(Texture2D tex, Vector2 posX, Vector2 posY, Vector2 movement, int windowHeight)
        {
            this.tex = tex;
            this.posX = posX;
            this.posY = posY;
            this.movement = movement;
            this.windowHeight = windowHeight;
        }


        public void Update()
        {
            if (posY.Y < 0 || posY.Y > windowHeight - tex.Height)
            {
                movement = movement * 0;


            }
            posY = posY + movement;

            


        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(tex, posX+ posY , Color.White);
        }

       

    }

    

   

    
}
