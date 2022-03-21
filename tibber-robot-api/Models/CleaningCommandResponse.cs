using System;

namespace tibber_robot_api.Models
{
    /// <summary>
    /// Response for cleaning commands
    /// </summary>
    public class CleaningCommandResponse
    {
        public int id { get; set; }

        public DateTime timestamp { get; set; }

        public int commmands { get; set; }

        public int result { get; set; }

        public double duration { get; set; }

    }
}
