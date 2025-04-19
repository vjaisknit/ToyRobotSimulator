using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.src.Interfaces;
using ToyRobotSimulator.src.Models;
using ToyRobotSimulator.src.Services;

namespace ToyRobotSimulator.Tests
{ 
    public class RobotServiceTests
        {
            private readonly IRobotService _robotService;

            public RobotServiceTests()
            {
                _robotService = new RobotService();
            }

            [Fact]
            public void Place_ShouldSetInitialPosition()
            {
                _robotService.Place(0, 0, Direction.NORTH);
                Assert.Equal("0,0,NORTH", _robotService.Report());
            }

            [Fact]
            public void Move_ShouldAdvanceNorth()
            {
                _robotService.Place(0, 0, Direction.NORTH);
                _robotService.Move();
                Assert.Equal("0,1,NORTH", _robotService.Report());
            }

            [Fact]
            public void Left_ShouldChangeDirection()
            {
                _robotService.Place(0, 0, Direction.NORTH);
                _robotService.Left();
                Assert.Equal("0,0,WEST", _robotService.Report());
            }

            [Fact]
            public void Right_ShouldChangeDirection()
            {
                _robotService.Place(0, 0, Direction.NORTH);
                _robotService.Right();
                Assert.Equal("0,0,EAST", _robotService.Report());
            }

            [Fact]
            public void ComplexSequence_ShouldResultInCorrectFinalPosition()
            {
                _robotService.Place(1, 2, Direction.EAST);
                _robotService.Move();
                _robotService.Move();
                _robotService.Left();
                _robotService.Move();
                Assert.Equal("3,3,NORTH", _robotService.Report());
            }

            [Fact]
            public void Move_OutsideBoundary_ShouldBeIgnored()
            {
                _robotService.Place(0, 4, Direction.NORTH);
                _robotService.Move(); // Should be ignored
                Assert.Equal("0,4,NORTH", _robotService.Report());
            }

            [Fact]
            public void Report_WithoutPlace_ShouldReturnEmpty()
            {
                Assert.Equal(string.Empty, _robotService.Report());
            }
        }
}


