using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINKI_Adventures
{
    public class Bullet : VisualObject
    {
        public Constants.DIRECTIONS Direction { get; set; }
        public bool RemoveMark { get; set; }
        public int Velocity { get; set; }

        public Bullet(Constants.DIRECTIONS direction, Player player)
        {
            Direction = direction;
            this.PositionX = player.PositionX+(player.Width/2);
            this.PositionY = player.PositionY+(player.Height/2);
            this.Width = 25;
            this.Height = 25;
            Velocity = 20;
            RemoveMark = false;
            Animation = AllAnimations.bullet;
        }

        public void Move()
        {
            if (Direction == Constants.DIRECTIONS.LEFT)
            {
                this.PositionX -= Velocity;
            }

            if (Direction == Constants.DIRECTIONS.RIGHT)
            {
                this.PositionX += Velocity;
            }

            if (Direction == Constants.DIRECTIONS.UP)
            {
                this.PositionY -= Velocity;
            }

            if (Direction == Constants.DIRECTIONS.DOWN)
            {
                this.PositionY += Velocity;
            }
        }
    }
}
