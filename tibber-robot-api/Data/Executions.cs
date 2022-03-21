using System;
using System.ComponentModel.DataAnnotations;

namespace tibber_robot_api.Data
{
    /// <summary>
    /// Class for DbContext, table in Postgres
    /// </summary>
    public class Executions
    {
        [Key]
        public int id { get; set; }

        public DateTime timestamp { get; set; }
        public int commmands { get; set; }
        public int result { get; set; }
        public double duration { get; set; }
    }
}
