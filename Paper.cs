using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Paper : Enemy
    {
        public static int Reward = 10;

        public Paper()
        {
            this.Health = 250;
            this.Velocity = 50;
            this.X = 340;
            this.Y = 1500;
            this.width = 100;
            this.height = 100;
            dead = remove = false;
            animation = AllAnimations.paper;//.paper sprites needed
        }
        public override void Move(Player player)
        {
            if (X > player.X)
            {
                X -= Velocity;
                if (animation != AllAnimations.paper)
                {
                    animation = AllAnimations.paper;
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

            if (Y > player.Y)
            {
                Y -= Velocity;
                if (animation != AllAnimations.paper)
                {
                    animation = AllAnimations.paper;
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
            if (X < player.X)
            {
                X += Velocity;
                if (animation != AllAnimations.paper)
                {
                    animation = AllAnimations.paper;
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
            if (Y < player.Y)
            {
                Y += Velocity;
                if (animation != AllAnimations.paper)
                {
                    animation = AllAnimations.paper;
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
