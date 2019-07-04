using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINKI_Adventures
{
    public static class Constants
    {
        // Enumerators
        public enum DIRECTIONS
        {
            LEFT, RIGHT, UP, DOWN
        }

        public enum LEVELS
        {
            KAMPUS_DVOR = 1,
            BARAKI_VLEZ = 2,
            ISPIT = 3
        }

        public static readonly Point[] BossTargetLocations = new Point[] {
            new Point { X = 285, Y = 275 },
            new Point { X = 285, Y = 640 },
            new Point { X = 1020, Y = 275 },
            new Point { X = 1020, Y = 640 }
        };

    // Map Constants
        public static readonly int mapLeftBound = 0;
        public static readonly int mapRightBound = 1280;

        // Random
        public static Random randomGenerator = new Random();
    }
}
