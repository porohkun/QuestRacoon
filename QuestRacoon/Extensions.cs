using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuestRacoon
{
    public static class Extensions
    {
        public static Point Append(this Point thisPoint, Point point)
        {
            return new Point(thisPoint.X + point.X, thisPoint.Y + point.Y);
        }

        public static Point Subtract(this Point thisPoint, Point point)
        {
            return new Point(thisPoint.X - point.X, thisPoint.Y - point.Y);
        }
    }
}
