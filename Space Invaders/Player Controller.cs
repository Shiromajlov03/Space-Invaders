using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Space_Invaders
{
     public class Player_Controller
    {

       
        public int windowWidth;
        public Texture2D bodyTextureP;
        public Texture2D canonTextureP;
       
        public Vector2 posP;
        
        public bool rightP;
        public bool leftP;
        public int hp;

        public Player_Controller(int windowWidth, Texture2D bodyTextureP, Texture2D canonTextureP, Vector2 posP, bool rightP, bool leftP, int hp)
        {
            this.windowWidth = windowWidth;
            this.bodyTextureP = bodyTextureP;
            this.canonTextureP = canonTextureP;
            this.posP = posP;
            this.rightP = rightP;
            this.leftP = leftP;
            this.hp = hp;
        }


        public void Update()
        {
            leftP = Keyboard.GetState().IsKeyDown(Keys.Left);
            rightP = Keyboard.GetState().IsKeyDown(Keys.Right);







            if (rightP && posP.X < windowWidth - bodyTextureP.Width)
                posP.X = posP.X + 5;


            if (leftP && posP.X > 1)
                posP.X = posP.X - 5;

           

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bodyTextureP, posP, Color.White);
            spriteBatch.Draw(canonTextureP, new Vector2(posP.X + bodyTextureP.Width / 2 - canonTextureP.Width / 2, posP.Y), Color.White);
        }



    }




}

