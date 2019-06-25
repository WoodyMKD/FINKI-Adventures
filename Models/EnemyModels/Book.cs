using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public class Book : Enemy
    {
        public Book()
        {
            this.Health = 150;
            this.Velocity = 5;
            this.PositionX = 640;
            this.PositionY = 300;
            this.Width = 70;
            this.Height = 70;
            Animation = AllAnimations.book;
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
