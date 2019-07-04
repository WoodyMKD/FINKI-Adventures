using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public abstract class Enemy : VisualObject
    {
        public int Health { get; set; }
        public int Reward { get; set; }
        public int Damage { get; set; }
        public bool IsDead { get; set; }
        public int Velocity { get; set; }

        public abstract void Move(Player player);

        public void showHealth(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            g.DrawString(String.Format("{0}%", Health), new Font("Arial", 16), new SolidBrush(Color.Red), 
                new Point((int)this.PositionX, (int)(this.PositionY - Width / 2 - 10)), sf);
        }
    }
}
