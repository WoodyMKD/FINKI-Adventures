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
        public int Velocity { get; set; }
        public Animation animation;
        public float X, Y, width, height;
        public Color Color { get; set; }
        public bool remove { get; set; }
        public Bullet(string direction, Player player)
        {
            Direction = direction;
            this.X = player.X+(player.width/2);
            this.Y = player.Y+(player.height/2);
            this.width = 25;
            this.height = 25;
            Velocity = 20;
            Color = Color.White;
            remove = false;
            animation = AllAnimations.bullet;

            Console.WriteLine("Created bullet");
        }

        public void Animate(Graphics g)
        {
            // Draw the current bullet animation sprite
            animation.Draw(g, X, Y, width, height);
        }
        //Bullet out of scene
        public bool OutOfScene(int w, int h)
        {
            return X + width <= w || Y + height <= h;
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
        }

        public void MoveRight()
        {
            this.X += Velocity;
        }

        public void MoveUp()
        {
            this.Y -= Velocity;
        }

        public void MoveDown()
        {
            this.Y += Velocity;
        }
    }
}
