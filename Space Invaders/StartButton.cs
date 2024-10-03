
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class StartButton
    {
        private Texture2D tex;
        private Vector2 pos;
        private Rectangle buttonRectangle;
        private MouseState currentMouseState, previusMouseState;
        private Color buttonColor;
        
        public StartButton(Texture2D tex, Vector2 pos) 
        { 
        
            this.tex = tex;
            this.pos = pos;
            buttonColor = Color.White;
            buttonRectangle = new Rectangle((int) pos.X, (int)pos.Y, tex.Width,tex.Height);
        
        }
        
        public bool isPressed()
        {
            currentMouseState = Mouse.GetState();
            if (buttonRectangle.Contains(currentMouseState.Position))
            {
                buttonColor = Color.Gray;

                if(currentMouseState.LeftButton == ButtonState.Pressed && previusMouseState.LeftButton == ButtonState.Released)
                {
                    previusMouseState = currentMouseState;
                    return true;
                }
            }
            else
            {
                buttonColor = Color.White;

            }
            previusMouseState = currentMouseState;
            return false;
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            

            spriteBatch.Draw(tex, pos, buttonColor);

           
        }
    }

    
    

    
}
