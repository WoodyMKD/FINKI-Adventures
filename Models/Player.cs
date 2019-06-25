using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public class Player : VisualObject
    {
        public Constants.DIRECTIONS Direction { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }

        public Player()
        {
            this.PositionX = 640;
            this.PositionY = 1300;
            this.Width = 100;
            this.Height = 100;
            this.Animation = AllAnimations.main_up;
            this.Direction = Constants.DIRECTIONS.UP;
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
            Animation prevAnimation = Animation;

            if(Direction == Constants.DIRECTIONS.LEFT)
                Animation = AllAnimations.main_left;
            else if (Direction == Constants.DIRECTIONS.RIGHT)
                Animation = AllAnimations.main_right;
            else if (Direction == Constants.DIRECTIONS.UP)
                Animation = AllAnimations.main_up;
            else if (Direction == Constants.DIRECTIONS.DOWN)
                Animation = AllAnimations.main_down;

            if(prevAnimation != Animation)
            {
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

        public void resetPosition()
        {
            this.PositionX = 540;
            this.PositionY = 1300;
            this.Width = 100;
            this.Height = 100;
        }
    }
}
