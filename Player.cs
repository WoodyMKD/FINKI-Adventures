using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Player
    {
        //public float X, Y, width, height;
        public float X { get; set; }
        public float Y { get; set; }
        public float width { get; set; }
        public float height { get; set; }

        public Animation animation;
        public string Direction { get; set; }
        public int Health { get; set; }
        public int Velocity { get; set; }
        public int Score { get; set; }

        public Player()
        {
            this.X = 540;
            this.Y = 1300;
            this.width = 100;
            this.height = 100;
            animation = AllAnimations.main_up;
            Direction = "up";
        }

        public void Animate(Graphics g)
        {
            // Draw the current player animation sprite
            animation.Draw(g, X, Y, width, height);
        }

        public void MoveLeft()
        {
            this.X -= 10;

            if(animation != AllAnimations.main_left)
            {
                animation = AllAnimations.main_left;
                Direction = "left";
                animation.Restart();
            }
            else
            {
                if (animation.isAnimFinished())
                {
                    animation.Restart();
                }
            }
        }

        public void MoveRight()
        {
            this.X += 10;

            if (animation != AllAnimations.main_right)
            {
                animation = AllAnimations.main_right;
                Direction = "right";
                animation.Restart();
            }
            else
            {
                if (animation.isAnimFinished())
                {
                    animation.Restart();
                }
            }
        }

        public void MoveUp()
        {
            this.Y -= 10;

            if (animation != AllAnimations.main_up)
            {
                animation = AllAnimations.main_up;
                Direction = "up";
                animation.Restart();
            }
            else
            {
                if(animation.isAnimFinished())
                {
                    animation.Restart();
                }
            }
        }

        public void MoveDown()
        {
            this.Y += 10;

            if (animation != AllAnimations.main_down)
            {
                animation = AllAnimations.main_down;
                Direction = "down";
                animation.Restart();
            }
            else
            {
                if (animation.isAnimFinished())
                {
                    animation.Restart();
                }
            }
        }

        public void resetPosition()
        {
            this.X = 540;
            this.Y = 1300;
            this.width = 100;
            this.height = 100;
        }
    }
}
