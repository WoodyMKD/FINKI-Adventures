using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures.Models.EnemyModels
{
    public class Boss : Enemy
    {
        public Point targetLocation { get; set; }

        public Boss(int posX, int posY)
        {
            this.Health = 150;
            this.Damage = 40;
            this.Velocity = 8;
            this.PositionX = posX;
            this.PositionY = posY;
            this.Width = 125;
            this.Height = 125;
            this.Reward = 5;
            this.Animation = AllAnimations.boss;

            this.targetLocation = Constants.BossTargetLocations[Constants.randomGenerator.Next(4)];
        }

        public override void Move(Player p)
        {
            if (PositionX > targetLocation.X)
            {
                PositionX -= Velocity;
            }

            if (PositionY > targetLocation.Y)
            {
                PositionY -= Velocity;
            }

            if (PositionX < targetLocation.X)
            {
                PositionX += Velocity;
            }

            if (PositionY < targetLocation.Y)
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
