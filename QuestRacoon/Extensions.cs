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

        public static Point GetCenter(this Rectangle rect)
        {
            return new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
        }

        public static Point IntersectsFromCenter(this Rectangle rect, Point end)
        {
            Point start = rect.GetCenter();
            Vector2 delta = new Vector2(start, end);

            float side;

            if (Math.Abs(delta.X) > Math.Abs(delta.Y)) //Left/Right
            {
                if (delta.X > 0) //Right
                {
                    side = rect.Width / 2f;
                }
                else //Left
                {
                    side = -rect.Width / 2f;
                }
                return new Point((int)side, (int)(delta.Y * side / delta.X)).Append(start);
            }
            else //Top/Bottom
            {
                if (delta.Y > 0) //Bottom
                {
                    side = rect.Height / 2f;
                }
                else //Top
                {
                    side = -rect.Height / 2f;
                }
                return new Point((int)(delta.X * side / delta.Y), (int)side).Append(start);
            }

        }
    }
}
