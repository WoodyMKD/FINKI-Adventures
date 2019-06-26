using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public class Book : Enemy
    {
        public Book(int posX, int posY)
        {
            this.Health = 150;
            this.Damage = 40;
            this.Velocity = 8;
            this.PositionX = posX;
            this.PositionY = posY;
            this.Width = 70;
            this.Height = 70;
            this.Reward = 5;
            this.Animation = AllAnimations.book;
        }

        public override void Move(Player player)
        {
            if (PositionX > player.PositionX)
            {
                PositionX -= Velocity;
            }

            if (PositionY > player.PositionY)
            {
                PositionY -= Velocity;
            }

            if (PositionX < player.PositionX)
            {
                PositionX += Velocity;
            }

            if (PositionY < player.PositionY)
            {
                PositionY += Velocity;
            }

            updateAnimation();
        }

        public void updateAnimation()
        {
            if (Animation.isAnimFinished())
            {
                Animation.Restart();
            }
        }
    }
}
