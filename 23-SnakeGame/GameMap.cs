using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_SnakeGame
{
    class GameMap
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private Terrain[,] _map;
        private readonly Random _random = new Random();

        public Terrain[,] Map
        {
            get
            {
                return (Terrain[,])_map.Clone();
            }
        }

        public GameMap(int width, int height)
        {
            if (width < 3)
                throw new ArgumentOutOfRangeException("Map needs some width");
            if (height < 3)
                throw new ArgumentOutOfRangeException("Map needs some height");

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Generates a new map, places walls all around
        /// </summary>
        public void CreateMap()
        {
            _map = new Terrain[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (x == 0 || y == 0 || x == Width - 1 || y == Height -1)
                        _map[x, y] = Terrain.Wall;
                    else
                        _map[x, y] = Terrain.Grass;
                }
            }
        }

        /// <summary>
        /// Places a new unit of food into a random place (except snake positions)
        /// </summary>
        /// <param name="snake"></param>
        public void PlaceFood(Snake snake)
        {
            Coordinates location = new Coordinates();
            do
            {
                location.X = _random.Next(1, Width - 1); //avoid wall
                location.Y = _random.Next(1, Height - 1); //avoid wall
            }
            while (snake.IsInSnake(location)); //avoid snake

            _map[location.X, location.Y] = Terrain.Food;
        }

        /// <summary>
        /// Returns terrain at specified location
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public Terrain AtCoordinates(Coordinates loc)
        {
            if (loc.X < 0 || loc.Y < 0 || loc.X >= Width || loc.Y >= Height)
                return Terrain.Wall;

            return _map[loc.X, loc.Y];
        }

        /// <summary>
        /// Removes food at specified location (if any)
        /// </summary>
        /// <param name="loc"></param>
        public void EatFood(Coordinates loc)
        {
            if (_map[loc.X, loc.Y] == Terrain.Food)
                _map[loc.X, loc.Y] = Terrain.Grass;
        }
    }
}
