using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    abstract class Enemy
    {
        protected float X { get; set; }
        protected float Y { get; set; }
        protected float width { get; set; }
        protected float height { get; set; }

        public Animation animation;
        public abstract int Health { get; set; }
        public abstract int Velocity { get; set; }
        public abstract void Animate();
        public abstract void Move();
    }
}
