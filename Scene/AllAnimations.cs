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


        // Paper enemy Animations
        public static Animation boss;

        public static void InitializeAnimations()
        {
            //Main character animation initialization
            main_up = new Animation(new Bitmap[] {
                Properties.Resources.up_left_leg,
                Properties.Resources.up_right_leg
            });

            main_down = new Animation(new Bitmap[] {
                Properties.Resources.down_left_leg,
                Properties.Resources.down_right_leg
            });

            main_left = new Animation(new Bitmap[] {
                Properties.Resources.left_left_leg,
                Properties.Resources.left_right_leg
            });

            main_right = new Animation(new Bitmap[] {
                Properties.Resources.right_left_leg,
                Properties.Resources.right_right_leg
            });


            //Bullet
            bullet = new Animation(new Bitmap[] {
                Properties.Resources.bullet
            });


            //Enemies
            book = new Animation(new Bitmap[] {
                Properties.Resources.book1,
                Properties.Resources.book2,
                Properties.Resources.book3,
                Properties.Resources.book4,
                Properties.Resources.book5,
                Properties.Resources.book6,
                Properties.Resources.book7,
                Properties.Resources.book8,
                Properties.Resources.book9
            });

            paper = new Animation(new Bitmap[] {
                Properties.Resources.paper //sprite should be replaced with multiple paper sprites
            });

            boss = new Animation(new Bitmap[] {
                Properties.Resources.boss_empty,
                Properties.Resources.boss_sl,
                Properties.Resources.boss_empty,
                Properties.Resources.boss_as,
                Properties.Resources.boss_empty,
                Properties.Resources.boss_ds,
                Properties.Resources.boss_empty,
                Properties.Resources.boss_gm,
                Properties.Resources.boss_empty
            });
        }

        public static void nextImage()
        {
            // Iterate through the next image
            book.nextImage();
        }
    }
}
