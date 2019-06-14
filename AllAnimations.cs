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
        // All possible animations
        public static Animation main_up;
        public static Animation main_down;
        public static Animation main_left;
        public static Animation main_right;

        public static void InitializeAnimations()
        {
            //Main character animation initialization
            main_up = new Animation(new Bitmap[] {
                Properties.Resources.up
            }, true);

            main_down = new Animation(new Bitmap[] {
                Properties.Resources.down
            }, true);

            main_left = new Animation(new Bitmap[] {
                Properties.Resources.left
            }, true);

            main_right = new Animation(new Bitmap[] {
                Properties.Resources.right
            }, true);
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
