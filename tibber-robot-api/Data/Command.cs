using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace tibber_robot_api.Data
{
    /// <summary>
    /// Robot commands
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Direction for the command
        /// </summary>
        [JsonConverter(typeof (StringEnumConverter))]
        public DirectionEnum Direction { get; set; }

        /// <summary>
        /// Number of steps to be executed in te command
        /// </summary>
        public int Steps { get; set; }
    }
}
