using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class AllAnimations
    {
        // Player Animations
        public static Animation main_up;
        public static Animation main_down;
        public static Animation main_left;
        public static Animation main_right;

        // Bullet Animations
        public static Animation bullet;

        // Book enemy Animations
        public static Animation book;

        // Paper enemy Animations
        public static Animation paper;

        public static void InitializeAnimations()
        {
            //Main character animation initialization
            main_up = new Animation(new Bitmap[] {
                Properties.Resources.up
            });

            main_down = new Animation(new Bitmap[] {
                Properties.Resources.down
            });

            main_left = new Animation(new Bitmap[] {
                Properties.Resources.left
            });

            main_right = new Animation(new Bitmap[] {
                Properties.Resources.right
            });


            //Bullet
            bullet = new Animation(new Bitmap[] {
                Properties.Resources.bullet
            });


            //Enemies
            book = new Animation(new Bitmap[] {
                Properties.Resources.bullet //sprite should be changed
            });

            paper = new Animation(new Bitmap[] {
                Properties.Resources.bullet //sprite should be replaced with multiple paper sprites
            });
        }

        public static void nextImage()
        {
            // Iterate through the next image
            main_up.nextImage();
            main_down.nextImage();
            main_left.nextImage();
            main_right.nextImage();
        }
    }
}
