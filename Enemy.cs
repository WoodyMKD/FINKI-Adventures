using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    abstract class Enemy
    {
        protected float X, Y, width, height;
        public bool dead, remove;
        public Animation animation;
        public int Health { get; set; }
        public int Velocity { get; set; }
        public void Animate(Graphics g)
        {
            animation.Draw(g, X, Y, width, height);
        }
        public abstract void Move(Player player);
    }
}
