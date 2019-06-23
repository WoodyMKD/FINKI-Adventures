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
        public int Reward { get; set; }
        public void Animate(Graphics g)
        {
            animation.Draw(g, X, Y, width, height);
        }
        public bool Collision(Player player)
        {
            return Math.Abs(player.X + player.width * 0.5f - X - width * 0.5f) < 0.4f * (player.width + width) && Y + 8.0f < player.Y + player.height && Y + 18.0f + player.Velocity > player.Y + player.height && player.Velocity > 0;
        }
        public bool Collision(Bullet bullet)
        {
            return Math.Abs(bullet.X + bullet.width * 0.5f - X - width * 0.5f) < 0.4f * (bullet.width + width) && Y + 8.0f < bullet.Y + bullet.height && Y + 18.0f + bullet.Velocity > bullet.Y + bullet.height && bullet.Velocity > 0;
        }
        public abstract void Move(Player player);
    }
}
