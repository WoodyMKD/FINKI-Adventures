using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Paper : Enemy
    {
        //public static int Reward = 10;

        public Paper()
        {
            this.Health = 250;
            this.Velocity = 10;
            this.PositionX = 340;
            this.PositionY = 400;
            this.Width = 55;
            this.Height = 55;
            Reward = 10;
            IsDead = false;
            Animation = AllAnimations.paper;//.paper sprites needed
        }
        public override void Move(Player player)
        {
            if (PositionX > player.PositionX)
            {
                PositionX -= Velocity;
                if (Animation != AllAnimations.paper)
                {
                    Animation = AllAnimations.paper;
                    Animation.Restart();
                }
                else
                {
                    if (Animation.isAnimFinished())
                    {
                        Animation.Restart();
                    }
                }
            }

            if (PositionY > player.PositionY)
            {
                PositionY -= Velocity;
                if (Animation != AllAnimations.paper)
                {
                    Animation = AllAnimations.paper;
                    Animation.Restart();
                }
                else
                {
                    if (Animation.isAnimFinished())
                    {
                        Animation.Restart();
                    }
                }
            }
            if (PositionX < player.PositionX)
            {
                PositionX += Velocity;
                if (Animation != AllAnimations.paper)
                {
                    Animation = AllAnimations.paper;
                    Animation.Restart();
                }
                else
                {
                    if (Animation.isAnimFinished())
                    {
                        Animation.Restart();
                    }
                }
            }
            if (PositionY < player.PositionY)
            {
                PositionY += Velocity;
                if (Animation != AllAnimations.paper)
                {
                    Animation = AllAnimations.paper;
                    Animation.Restart();
                }
                else
                {
                    if (Animation.isAnimFinished())
                    {
                        Animation.Restart();
                    }
                }
            }
        }
    }
}
