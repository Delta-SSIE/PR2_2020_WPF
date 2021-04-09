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

        public void CreateMap()
        {
            _map = new Terrain[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (x == 0 || y < 0 || x == Width - 1 || y == Height -1)
                        _map[Width, Height] = Terrain.Wall;
                    else
                        _map[Width, Height] = Terrain.Grass;
                }
            }
        }

        public void PlaceFood(Snake snake)
        {
            Coordinates location = new Coordinates();
            do
            {
                location.X = _random.Next(1, Width - 1); //avoid wall
                location.Y = _random.Next(1, Height - 1); //avoid wall
            }
            while (!snake.IsInSnake(location)); //avoid snake

            _map[location.X, location.Y] = Terrain.Food;
        }

        public Terrain AtCoordinates(Coordinates loc)
        {
            if (loc.X < 0 || loc.Y < 0 || loc.X >= Width || loc.Y >= Height)
                return Terrain.Wall;

            return _map[loc.X, loc.Y];
        }

        public void EatFood(Coordinates loc)
        {
            if (_map[loc.X, loc.Y] == Terrain.Food)
                _map[loc.X, loc.Y] = Terrain.Grass;
        }
    }
}
