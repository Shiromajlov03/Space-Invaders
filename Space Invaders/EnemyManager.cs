using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Space_Invaders
{
    internal class EnemyManager
    {

        Game1 game1;
        
        public EnemyManager(Game1 game1)
        {
        this.game1 = game1;
            
        }

        public void Update(GameTime gameTime)
        {


            //foreach (Enemy_Controller game1.enemy in game1.enemyArray)
            //{
            //    if (game1.enemyArray[i, j] != null)
            //    {
            //        if (game1.enemyAlive == true)
            //        {
            //            move = new Vector2(1, 0);
            //            if (enemyX.X < 1)
            //            {
            //                move = new Vector2(0, 0);
            //                moveDown = true;
            //                moveLeft = false;
            //                moveRight = true;
            //            }
            //            if (enemyX.X > windowWidth - enemyTex.Width && moveRight == true)
            //            {
            //                move = new Vector2(0, 0);
            //                moveDown = true;
            //                moveLeft = true;
            //                moveRight = false;
            //            }
            //            if (moveDown == true)
            //            {

            //                move = new Vector2(0, 120);
            //                enemyY = enemyY + move;

            //                moveDown = false;

            //            }

            //            if (moveLeft == true)
            //            {
            //                move = new Vector2(-3, 0);
            //                enemyX = enemyX + move;
            //                enemyY = enemyY + new Vector2(0, 0);
            //            }
            //            if (moveRight == true)
            //            {
            //                move = new Vector2(3, 0);
            //                enemyX = enemyX + move;
            //                enemyY = enemyY + new Vector2(0, 0);
            //            }
            //        }
            //    }
            //}

        }
    }
}
