using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Space_Invaders
{

    
    public class Enemy_Controller
    {
        public Vector2 pos;
        public Texture2D tex;
        public Vector2 movement;
        public int windowHeight;
        public Enemy_Controller(Texture2D tex, Vector2 pos, Vector2 movement, int windowHeight)
        {
            this.tex = tex;
            this.pos = pos;
            this.movement = movement;
            this.windowHeight = windowHeight;
        }
       

    }

    

   

    
}
