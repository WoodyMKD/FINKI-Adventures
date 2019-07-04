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
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Animation Animation { get; set; }

        public bool isInsideMap()
        {
            // Object is considered in map if 50% of the height of the body is inside the map 
            float objectVerticalBound = 0.5f * Height;
            int wallBounds = 0;
            if (GameSettings.mapHasWalls) wallBounds = GameSettings.wallBounds;
            
            if (PositionY > (GameSettings.mapUpperBoundY - objectVerticalBound))
            {
                if (PositionY < (GameSettings.mapLowerBoundY + objectVerticalBound))
                {
                    if (PositionX > (Constants.mapLeftBound + wallBounds))
                    {
                        if(PositionX < (Constants.mapRightBound - wallBounds))
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
            // Draw sprites
            Animation.Draw(g, PositionX - Width / 2, PositionY - Height / 2, Width, Height);

            if (GameSettings.showHitBoxes)
                g.DrawRectangle(new Pen(Color.Tomato), PositionX - Width / 2, PositionY - Height / 2, Width, Height);
        }

        public bool hasCollided(VisualObject obj)
        {
            Rectangle firstHitBox = new Rectangle(PositionX - Width/2, PositionY - Height/2, Width, Height);
            Rectangle secondHitBox = new Rectangle(obj.PositionX - obj.Width/2, obj.PositionY - obj.Height/2, obj.Width, obj.Height);

            return firstHitBox.IntersectsWith(secondHitBox);    
        }
    }
}
