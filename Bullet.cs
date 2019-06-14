using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINKI_Adventures
{
    class Bullet
    {
        public string Direction { get; set; }
        public static int Velocity = 20;
        public PictureBox bullet { get; set; }
        public Animation animation;
        public float X, Y, width, height;
        public Color Color { get; set; }
        public Bullet(string direction, Player player)
        {
            Direction = direction;
            bullet = new PictureBox();
            this.X = player.X+(player.width/2);
            this.Y = player.Y+(player.height/2);
            this.width = player.width - 95;
            this.height = player.height - 95;
            Color = Color.White;
        }
        public void Animate(Graphics g)
        {
            // Draw the current bullet animation sprite
            animation.Draw(g, X, Y, width, height);
        }
        public void Move()
        {
            if (Direction == "left")
            {
                MoveLeft();
            }
            if (Direction == "right")
            {
                MoveRight();
            }
            if (Direction == "down")
            {
                MoveDown();
            }
            if (Direction == "up")
            {
                MoveUp();
            }
        }
        public void MoveLeft()
        {
            this.X -= Velocity;

            if (animation != AllAnimations.main_left)
            {
                animation = AllAnimations.main_left;
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
            this.X += Velocity;

            if (animation != AllAnimations.main_right)
            {
                animation = AllAnimations.main_right;
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
            this.Y -= Velocity;

            if (animation != AllAnimations.main_up)
            {
                animation = AllAnimations.main_up;
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

        public void MoveDown()
        {
            this.Y += Velocity;

            if (animation != AllAnimations.main_down)
            {
                animation = AllAnimations.main_down;
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
    }
}
