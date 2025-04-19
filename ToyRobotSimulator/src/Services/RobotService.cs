using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.src.Interfaces;
using ToyRobotSimulator.src.Models;

namespace ToyRobotSimulator.src.Services
{
    public class RobotService : IRobotService
    {
        private Position _position;
        private bool _isPlaced;

        public void Place(int x, int y, Direction direction)
        {
            if (TableTop.IsValidPosition(x, y))
            {
                _position = new Position(x, y, direction);
                _isPlaced = true;
            }
        }

        public void Move()
        {
            if (!_isPlaced) return;

            var (x, y) = (_position.X, _position.Y);

            switch (_position.Facing)
            {
                case Direction.NORTH: y++; break;
                case Direction.SOUTH: y--; break;
                case Direction.EAST: x++; break;
                case Direction.WEST: x--; break;
            }

            if (TableTop.IsValidPosition(x, y))
            {
                _position.X = x;
                _position.Y = y;
            }
        }

        public void Left()
        {
            if (!_isPlaced) return;

            _position.Facing = (Direction)(((int)_position.Facing + 3) % 4);
        }

        public void Right()
        {
            if (!_isPlaced) return;

            _position.Facing = (Direction)(((int)_position.Facing + 1) % 4);
        }

        public string Report()
        {
            return _isPlaced ? $"{_position.X},{_position.Y},{_position.Facing}" : string.Empty;
        }
    }

}
