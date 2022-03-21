using System;
using System.Collections.Generic;
using System.Linq;
using tibber_robot_api.Data;

namespace tibber_robot_api.Repository
{
    /// <summary>
    /// Implementation of a robot moving - Simulation with movement commands
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Current position of the robot
        /// </summary>
        public Point CurrentPosition { get; set; }

        /// <summary>
        /// Actual number of steps taken by the robot - not unique
        /// </summary>
        public int RobotSteps { get; set; } = 0;
  
        public void CommandRobot(Command command, ref List<Point> uniqueVisitedPoints)
        {
            // Command directions could be expanded with more directions, to expand functionality.
            // Same goes for the Move functions. Could be expanded with extra logic.

            switch (command.Direction)
            {
                case DirectionEnum.North:
                    MoveNorth(command.Steps, ref uniqueVisitedPoints);
                    break;
                case DirectionEnum.East:
                    MoveEast(command.Steps, ref uniqueVisitedPoints);
                    break;
                case DirectionEnum.South:
                    MoveSouth(command.Steps, ref uniqueVisitedPoints);
                    break;
                case DirectionEnum.West:
                    MoveWest(command.Steps, ref uniqueVisitedPoints);
                    break;
                default:
                    break;
            }


        }

        void AddPointToListUnique(ref List<Point> visitedPoints, Point currentPosition)
        {
            // This could be optimized by not using a list. Keeping it simple.
            if (!visitedPoints.Any(x => x.X == currentPosition.X && x.Y == currentPosition.Y))
            {
                visitedPoints.Add(currentPosition);
            }
        }

        /*
            Possible to add the outer limits of the office as configuration, skipped to keep it simple
         */ 
        #region ListOperations

        void MoveNorth(int steps, ref List<Point> visitedPoints)
        {
            for(int i = 0; i < steps; i++)
            {
                if (CurrentPosition.Y > -100000)
                {
                    CurrentPosition.Y--;
                    AddPointToListUnique(ref visitedPoints, new Point { X = CurrentPosition.X, Y = CurrentPosition.Y });
                    RobotSteps ++;
                }
                else
                {
                    break;
                }
            }
        }

        void MoveEast(int steps, ref List<Point> visitedPoints)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CurrentPosition.X < 100000)
                {
                    CurrentPosition.X++;
                    AddPointToListUnique(ref visitedPoints, new Point { X = CurrentPosition.X, Y = CurrentPosition.Y });
                    RobotSteps++;
                }
                else
                {
                    break;
                }
            }
        }

        void MoveSouth(int steps, ref List<Point> visitedPoints)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CurrentPosition.Y < 100000)
                {
                    CurrentPosition.Y++;
                    AddPointToListUnique(ref visitedPoints, new Point { X = CurrentPosition.X, Y = CurrentPosition.Y });
                    RobotSteps++;
                }
                else
                {
                    break;
                }            
            }
        }

        void MoveWest(int steps, ref List<Point> visitedPoints)
        {
            for (int i = 0; i < steps; i++)
            {
                if (CurrentPosition.X > -100000)
                {
                    CurrentPosition.X--;
                    AddPointToListUnique(ref visitedPoints, new Point { X = CurrentPosition.X, Y = CurrentPosition.Y });
                    RobotSteps++;
                }
                else
                {
                    break;
                }
             }
        }

        #endregion
     
    }
}
