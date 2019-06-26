using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public class Animation
    {
        public Bitmap[] spriteImages { get; set; }
        public int index { get; set; }

        public Animation(Bitmap[] images)
        {
            this.spriteImages = images;
            index = 0;
        }

        public void Draw(Graphics g, float x, float y, float width, float height)
        {
            // Draw the current animation sprite
            g.DrawImage(spriteImages[index], x, y, width, height);

            if (GameSettings.showHitBoxes)
                g.DrawRectangle(new Pen(Color.Black), x, y, width, height);
        }

        public void nextImage()
        {
            // Iterate through next image
            if (index < spriteImages.Length - 1)
            {
                ++index;
            }
        }

        public void Restart()
        {
            // Restart animation sprite index
            index = 0;
        }

        public bool isAnimFinished()
        {
            return index == spriteImages.Length-1;
        }
    }
}
