using System.Collections.Generic;
using tibber_robot_api.Data;

namespace tibber_robot_api.Repository
{
    public class PointComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Point obj)
        {
            return obj.Y.GetHashCode() ^ obj.X.GetHashCode();
        }
    }
}
