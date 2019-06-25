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
        public bool IsDead { get; set; }

        public abstract void Move(Player player);
    }
}
