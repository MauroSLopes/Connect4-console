using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conect4_Console.Models
{
    internal class Direction
    {
        public static int[] verticalDirection = [1, 0];

        public static int[] horizontalDirection = [0, 1];

        public static int[] diagonalDirection = [-1, 1];

        public static int[] invertedDiagonalDirection = [-1, -1];

        public static int[] invertDirection(int[] direction)
        {
            return new int[] { -direction[0], -direction[1] };
        }
    }
}
