using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.src.Models;

namespace ToyRobotSimulator.src.Interfaces
{
    public interface IRobotService
    {
        void Place(int x, int y, Direction direction);
        void Move();
        void Left();
        void Right();
        string Report();
    }

}
