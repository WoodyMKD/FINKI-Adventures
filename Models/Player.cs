using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    class Player : VisualObject
    {
        public Animation animation { get; set; }
        public Constants.DIRECTIONS Direction { get; set; }
        public int Health { get; set; }
        public int Velocity { get; set; }
        public int Score { get; set; }

        public Player()
        {
            this.PositionX = 540;
            this.PositionY = 1300;
            this.Width = 100;
            this.Height = 100;
            this.animation = AllAnimations.main_up;
            this.Direction = Constants.DIRECTIONS.UP;
        }

        public void Animate(Graphics g)
        {
            // Draw the current player animation sprite
            animation.Draw(g, PositionX - Width/2, PositionY - Height / 2, Width, Height);
        }

        public void Move(Constants.DIRECTIONS direction)
        {
            if (direction == Constants.DIRECTIONS.LEFT)
            {
                if (PositionX > Constants.mapLeftBound)
                {
                    this.PositionX -= 10;
                    Direction = Constants.DIRECTIONS.LEFT;
                    updateAnimation();
                }
            }

            if (direction == Constants.DIRECTIONS.RIGHT)
            {
                if (PositionX < Constants.mapRightBound)
                {
                    this.PositionX += 10;
                    Direction = Constants.DIRECTIONS.RIGHT;
                    updateAnimation();
                }
            }

            if (direction == Constants.DIRECTIONS.UP)
            {
                if (PositionY > GameSettings.mapUpperBoundY)
                {
                    this.PositionY -= 10;
                    Direction = Constants.DIRECTIONS.UP;
                    updateAnimation();
                }
            }

            if (direction == Constants.DIRECTIONS.DOWN)
            {
                this.PositionY += 10;
                Direction = Constants.DIRECTIONS.DOWN;
                updateAnimation();
            }
        }

        public void updateAnimation()
        {
            Animation prevAnimation = animation;

            if(Direction == Constants.DIRECTIONS.LEFT)
                animation = AllAnimations.main_left;
            else if (Direction == Constants.DIRECTIONS.RIGHT)
                animation = AllAnimations.main_right;
            else if (Direction == Constants.DIRECTIONS.UP)
                animation = AllAnimations.main_up;
            else if (Direction == Constants.DIRECTIONS.DOWN)
                animation = AllAnimations.main_down;

            if(prevAnimation != animation)
            {
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

        public void resetPosition()
        {
            this.PositionX = 540;
            this.PositionY = 1300;
            this.Width = 100;
            this.Height = 100;
        }
    }
}
