using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_SnakeGame
{
    class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public Coordinates Neighbour (Direction heading)
        {
            Coordinates neighbour = new Coordinates(X, Y);

            switch (heading)
            {
                case Direction.North:
                    neighbour.Y--;
                    break;

                case Direction.South:
                    neighbour.Y++;
                    break;

                case Direction.East:
                    neighbour.X++;
                    break;

                case Direction.West:
                    neighbour.X--;
                    break;
            }

            return neighbour;
        }
    }
}
