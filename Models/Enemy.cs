using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    abstract class Enemy : VisualObject
    {
        public bool dead, remove;
        public Animation animation;
        public int Health { get; set; }
        public int Velocity { get; set; }
        public int Reward { get; set; }

        public void Animate(Graphics g)
        {
            animation.Draw(g, PositionX, PositionY, Width, Height);
        }

        public bool Collision(Player player)
        {
            return Math.Abs(player.PositionX + player.Width * 0.5f - PositionX - Width * 0.5f) < 0.4f * (player.Width + Width) && PositionY + 8.0f < player.PositionY + player.Height && PositionY + 18.0f + player.Velocity > player.PositionY + player.Height && player.Velocity > 0;
        }

        public bool Collision(Bullet bullet)
        {
            return Math.Abs(bullet.PositionX + bullet.Width * 0.5f - PositionX - Width * 0.5f) < 0.4f * (bullet.Width + Width) && PositionY + 8.0f < bullet.PositionY + bullet.Height && PositionY + 18.0f + bullet.Velocity > bullet.PositionY + bullet.Height && bullet.Velocity > 0;
        }

        public abstract void Move(Player player);
    }
}
