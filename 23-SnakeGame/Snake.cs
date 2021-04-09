using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_SnakeGame
{
    class Snake
    {
        private Queue<Coordinates> _segments;

        public Coordinates[] Segments
        {
            get
            {
                return _segments.ToArray();
            }
        }

        public int Length
        {
            get
            {
                return _segments.Count();
            }
        }

        public Coordinates Head
        {
            get
            {
                return _segments.Last();
            }
        }

        public Snake(Coordinates head)
        {
            //create new Queue
            _segments = new Queue<Coordinates>();
            //place head as first element
            _segments.Enqueue(head);
        }

        public bool IsInSnake(Coordinates loc)
        {
            foreach (Coordinates segment in _segments)
            {
                if (segment.Equals(loc))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Moves snake
        /// </summary>
        /// <param name="loc">New location</param>
        /// <returns>True, if the move is OK, false, ifg snake bites itself</returns>
        public bool MoveTo(Coordinates loc, bool enlarge = false)
        {
            if (!enlarge) //if not eating food, remove tail
                _segments.Dequeue();

            bool bitesSelf = IsInSnake(loc); //check self-biting
            _segments.Enqueue(loc); //add new head position

            return !bitesSelf; //return if the move is OK
        }
    }
}
