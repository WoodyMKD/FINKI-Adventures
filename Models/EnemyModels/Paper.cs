using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Paper : Enemy
    {
        public Paper(int posX, int posY)
        {
            this.Health = 10;
            this.Damage = 20;
            this.Velocity = 10;
            this.PositionX = posX;
            this.PositionY = posY;
            this.Width = 55;
            this.Height = 55;
            this.Reward = 10;
            this.IsDead = false;
            this.Animation = AllAnimations.paper;
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
        }
    }
}
