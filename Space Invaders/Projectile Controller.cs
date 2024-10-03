using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;






namespace Space_Invaders
{
    public class Projectile_Controller
    {


        public int windowHeight;
        public Texture2D bulletTextureP;
        public Vector2 posBulletP;
        public bool shootP;
        public bool bulletAliveP = false;
        public bool collision = false;
        


        public Texture2D bodyTexturePmalfunction;
        public Vector2 posP;

        public Rectangle BoundingBox {  get; private set; }
        private float shootCooldown = 1f;
        private float shootTime = 0f;


        public Player_Controller player;

        public Projectile_Controller(Texture2D bulletTextureP, Vector2 posBulletP,Rectangle BoundingBox, bool shootP, bool bulletAliveP, bool collision, Texture2D bodyTexturePmalfunction, Vector2 posP, Player_Controller player) // int bodyPmalfunctioned
        {
            this.bulletTextureP = bulletTextureP;
            this.posBulletP = posBulletP;
            this.shootP = shootP;
            this.bulletAliveP = bulletAliveP;
            this.collision = collision;
            this.bodyTexturePmalfunction = bodyTexturePmalfunction;
            this.posP = posP;
            this.player = player;
            BoundingBox = new Rectangle((int)posBulletP.X, (int)posBulletP.Y, bulletTextureP.Width, bulletTextureP.Height);
            this.BoundingBox = BoundingBox;

        }
        public void Update(GameTime gameTime)
        {
            shootTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            shootP = Keyboard.GetState().IsKeyDown(Keys.Space);


            if (bulletAliveP)
            {
                posBulletP.Y = posBulletP.Y - 5;

                BoundingBox = new Rectangle((int)posBulletP.X,(int)posBulletP.Y,bulletTextureP.Width,bulletTextureP.Height);

                if (collision || posBulletP.Y < 0)
                {
                    bulletAliveP = false;
                    collision = false;
                    posBulletP.X = -bulletTextureP.Height;
                }
            }

            else if (shootP && !bulletAliveP)
            {
                bulletAliveP = true;
                shootTime = 0f;

                posBulletP.X = player.posP.X + bodyTexturePmalfunction.Width / 2 - bulletTextureP.Width / 2;
                posBulletP.Y = player.posP.Y;
                BoundingBox = new Rectangle((int)posBulletP.X, (int)posBulletP.Y, bulletTextureP.Width, bulletTextureP.Height);
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(bulletTextureP, posBulletP, Color.White);



        }


    }
}
