using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public abstract class VisualObject
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Animation Animation { get; set; }
        public int Velocity { get; set; }

        public bool isInsideMap()
        {
            // Object is considered in map if 50% of the height of the body is inside the map 
            float objectVerticalBound = 0.5f * Height;
            
            if (PositionY > GameSettings.mapUpperBoundY - objectVerticalBound)
            {
                if (PositionY < GameSettings.mapLowerBoundY + objectVerticalBound)
                {
                    if (PositionX > Constants.mapLeftBound)
                    {
                        if(PositionX < Constants.mapRightBound)
                        {
                            return true;
                        } return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public void Animate(Graphics g)
        {
            // Draw the current player animation sprite
            Animation.Draw(g, PositionX - Width / 2, PositionY - Height / 2, Width, Height);
        }

        public bool hasCollided(VisualObject obj)
        {
            Rectangle firstHitBox = new Rectangle((int)PositionX, (int)PositionY, (int)Width - 20, (int)Height - 20);
            Rectangle secondHitBox = new Rectangle((int)obj.PositionX, (int)obj.PositionY, (int)obj.Width - 20, (int)obj.Height - 20);

            return firstHitBox.IntersectsWith(secondHitBox);    
        }
    }
}
