using System;

namespace MarsProject.Models
{
    public class Plateau
    {
        public  Plateau(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                X = x;
                Y = y;
            }
            else
                throw new ArgumentException(ErrorMessages.DimensionMessage, "dimension");
        }
        public int X { get; set; }

        public int Y { get; set; }
    }
}
