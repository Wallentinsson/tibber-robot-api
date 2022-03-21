namespace tibber_robot_api.Data
{
    /// <summary>
    /// X,Y Point coordinate
    /// </summary>
    public class Point 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{this.X}:{this.Y}";
        }
    }
}
