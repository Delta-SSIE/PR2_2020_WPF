using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_SnakeGame
{
    class GameController
    {
        private Snake _snake;
        public Coordinates[] Snake
        {
            get { return _snake.Segments; }
        }

        private GameMap _map;
        public Terrain[,] Map
        {
            get { return _map.Map; }
        }


        public Direction Heading { get; set; }
        public GameState State {get; private set;}

        public GameController(int width, int height)
        {
            // new map
            _map = new GameMap(width, height);
            _map.CreateMap();

            // new snake
            Coordinates head = new Coordinates(width / 2, height / 2);
            _snake = new Snake(head);

            // place food
            _map.PlaceFood(_snake);

            // default direction
            Heading = Direction.North;

            State = GameState.Stopped;
        }

        public void StartGame()
        {
            State = GameState.Running;
        }

        public void Step()
        {
            if (State != GameState.Running)
                return;

            // find head
            Coordinates head = _snake.Head;

            // find next position
            Coordinates next = head.Neighbour(Heading);
            Terrain nextTerrain = _map.AtCoordinates(next);

            switch (nextTerrain)
            {
                case Terrain.Grass:
                    // move
                    // check if not bite self
                    bool sucess = _snake.MoveTo(next);  // result will be true, on successful move
                                                        //                false on self-bite
                    if (!sucess)
                    {
                        // lose
                        State = GameState.Lost;
                    }                    
                    break;

                case Terrain.Food:
                    // delete food
                    _map.EatFood(next);
                    // move and enlarge
                    _snake.MoveTo(next, true);
                    // place new food
                    _map.PlaceFood(_snake);
                    break;

                case Terrain.Wall:
                    // move
                    _snake.MoveTo(next);
                    // lose
                    State = GameState.Lost;
                    break;
            }
        }
    }
}
