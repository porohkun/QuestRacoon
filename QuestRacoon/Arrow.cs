using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestRacoon
{
    public class Arrow : Control
    {
        public int ArrowWidth { get; set; }
        public int EndWidth { get; set; }
        public int EndLength { get; set; }

        public Block StartBlock { get; private set; }
        public Block EndBlock { get; private set; }

        public Arrow()
        {
            BackColor = Color.Black;
            ArrowWidth = 10;
            EndWidth = 20;
            EndLength = 24;
        }

        public Arrow(WorkspaceControl workspace, Block start, Block end) : this()
        {
            workspace.Controls.Add(this);
            DrawArrow(start, end);
        }

        public void DrawArrow(Block start, Block end)
        {
            StartBlock = start;
            EndBlock = end;
            DrawArrow(
                start.Bounds.IntersectsFromCenter(end.Bounds.GetCenter()),
                end.Bounds.IntersectsFromCenter(start.Bounds.GetCenter()));
        }

        public void DrawArrow(Point start, Point end)
        {
            Location = new Point(Math.Min(start.X, end.X) - EndWidth / 2, Math.Min(start.Y, end.Y) - EndWidth / 2);
            Size = new Size(Math.Max(start.X, end.X) + EndWidth / 2 - Location.X, Math.Max(start.Y, end.Y) + EndWidth / 2 - Location.Y);

            Vector2 guide = new Vector2(start, end);
            Vector2 forward = guide.Normalized();
            Vector2 back = forward.Rotate(180f);
            Vector2 left = forward.Rotate(-90f);
            Vector2 right = forward.Rotate(90f);

            Vector2[] vectorPath = new Vector2[7];

            vectorPath[0] = left * (ArrowWidth / 2);
            vectorPath[1] = vectorPath[0] + forward * (guide.Length - EndLength);
            vectorPath[2] = vectorPath[1] + left * ((EndWidth - ArrowWidth) / 2);
            vectorPath[3] = guide;
            vectorPath[6] = right * (ArrowWidth / 2);
            vectorPath[5] = vectorPath[6] + forward * (guide.Length - EndLength);
            vectorPath[4] = vectorPath[5] + right * ((EndWidth - ArrowWidth) / 2);

            Vector2 offset = new Vector2(guide.X < 0f ? -guide.X : 0f, guide.Y < 0f ? -guide.Y : 0f);

            Point[] points = (from v in vectorPath select (Point)(v + offset)).ToArray<Point>();

            GraphicsPath path = new GraphicsPath();
            
            path.AddLines(points);
            
            Region = new Region(path);
            Invalidate();
        }
    }
}
