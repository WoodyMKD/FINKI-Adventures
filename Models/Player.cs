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
            this.Health = 100;
            this.Width = 100;
            this.Height = 100;
            this.Animation = AllAnimations.main_up;
            this.Direction = Constants.DIRECTIONS.UP;
        }

        public void Move()
        {
            int wallBounds = 0;
            if (GameSettings.mapHasWalls) wallBounds = GameSettings.wallBounds;

            if (Direction == Constants.DIRECTIONS.LEFT)
            {
                if (PositionX > Constants.mapLeftBound + wallBounds)
                {
                    this.PositionX -= 10;
                }
            }

            if (Direction == Constants.DIRECTIONS.RIGHT)
            {
                if (PositionX < Constants.mapRightBound - wallBounds)
                {
                    this.PositionX += 10;
                }
            }

            if (Direction == Constants.DIRECTIONS.UP)
            {
                if (!GameSettings.mapHasWalls && PositionY > GameSettings.mapUpperBoundY ||
                    GameSettings.mapHasWalls && PositionY > wallBounds && PositionY > GameSettings.mapUpperBoundY)
                {
                    this.PositionY -= 10;
                }
            }

            if (Direction == Constants.DIRECTIONS.DOWN)
            {
                if (GameSettings.mapHasWalls && PositionY < 1500 - wallBounds)
                {
                    this.PositionY += 10;
                }
                else if(!GameSettings.mapHasWalls)
                {
                    this.PositionY += 10;
                }
            }

            updateAnimation();
        }

        public void updateAnimation()
        {
            if(Direction == Constants.DIRECTIONS.LEFT && Animation != AllAnimations.main_left)
                Animation = AllAnimations.main_left;
            else if (Direction == Constants.DIRECTIONS.RIGHT && Animation != AllAnimations.main_right)
                Animation = AllAnimations.main_right;
            else if (Direction == Constants.DIRECTIONS.UP && Animation != AllAnimations.main_up)
                Animation = AllAnimations.main_up;
            else if (Direction == Constants.DIRECTIONS.DOWN && Animation != AllAnimations.main_down)
                Animation = AllAnimations.main_down;
            
            if (Animation.isAnimFinished())
            {
                Animation.Restart();
            }
            else
            {

                AllAnimations.main_up.nextImage();
                AllAnimations.main_down.nextImage();
                AllAnimations.main_left.nextImage();
                AllAnimations.main_right.nextImage();
            }
        }

        public void resetPosition(Constants.LEVELS level)
        {
            if (level != Constants.LEVELS.ISPIT)
            {
                this.PositionX = 540;
                this.PositionY = 1300;
            } 
            else
            {
                this.PositionX = 1170;
                this.PositionY = 600;
            }

            this.Width = 100;
            this.Height = 100;
        }
    }
}
