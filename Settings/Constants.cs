using System;
using System.Collections.Generic;
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
            BARAKI = 2,
            VP_ISPIT = 3
        }

        // Map Constants
        public static readonly int mapLeftBound = 0;
        public static readonly int mapRightBound = 1280;
    }
}
