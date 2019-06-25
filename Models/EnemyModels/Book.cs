using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Book : Enemy
    {
        //public static int Reward = 5;

        public Book()
        {
            this.Health = 150;
            this.Velocity = 5;
            this.PositionX = 640;
            this.PositionY = 300;
            this.Width = 70;
            this.Height = 70;
            Reward = 5;
            dead = remove = false;
            animation = AllAnimations.book;//.book sprite needed
        }
        public override void Move(Player player)
        {
            if (PositionX > player.PositionX)
            {
                PositionX -= Velocity;
                if (animation != AllAnimations.book)
                {
                    animation = AllAnimations.book;
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

            if (PositionY > player.PositionY)
            {
                PositionY -= Velocity;
                if (animation != AllAnimations.book)
                {
                    animation = AllAnimations.book;
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
            if (PositionX < player.PositionX)
            {
                PositionX += Velocity;
                if (animation != AllAnimations.book)
                {
                    animation = AllAnimations.book;
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
            if (PositionY < player.PositionY)
            {
                PositionY += Velocity;
                if (animation != AllAnimations.book)
                {
                    animation = AllAnimations.book;
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
}
