using System.Collections.Generic;
using tibber_robot_api.Data;

namespace tibber_robot_api.Models
{
    /// <summary>
    /// Request for cleaning commands
    /// </summary>
    public class CleaningCommandRequest
    {
        public Point Start { get; set; }
        public List<Command> Commmands { get; set; }

        public CleaningCommandRequest()
        {
            Commmands = new List<Command>();
        }

    }
}
