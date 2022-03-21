using System.Collections.Generic;
using tibber_robot_api.Data;

namespace tibber_robot_api.Repository
{
    /// <summary>
    /// Interface for robot, should it need more/extending functionality.
    /// Not necessary right now, but it's here.
    /// </summary>
    public interface IRobot
    {
        /// <summary>
        /// Sending the robot on its cleaning mission
        /// </summary>
        public void CommandRobot(Command command, ref List<Point> uniqueVisitedPoints);
    }
}
