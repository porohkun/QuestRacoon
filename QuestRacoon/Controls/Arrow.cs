using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuestRacoonWpf
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
            BackColor = Color.Wheat;
            ArrowWidth = 2;
            EndWidth = 8;
            EndLength = 14;
        }

        public Arrow(WorkspaceControl workspace, Block start, Block end) : this()
        {
            workspace.Controls.Add(this);
            DrawArrow(start, end);
        }

        private void OnBlockMove(object sender, EventArgs e)
        {
            DrawArrow(StartBlock, EndBlock);
        }

        public void DrawArrow(Block start, Block end, bool force = false)
        {
            if (StartBlock != null && StartBlock != start)
            {
                StartBlock.LocationChanged -= OnBlockMove;
                StartBlock.MoveEnd -= OnBlockMove;
            }
            if (StartBlock != start)
            {
                StartBlock = start;
                StartBlock.LocationChanged += OnBlockMove;
                StartBlock.MoveEnd += OnBlockMove;
            }
            if (EndBlock != null && EndBlock != end)
            {
                EndBlock.LocationChanged -= OnBlockMove;
                EndBlock.MoveEnd -= OnBlockMove;
            }
            if (EndBlock != end)
            {
                EndBlock = end;
                EndBlock.LocationChanged += OnBlockMove;
                EndBlock.MoveEnd += OnBlockMove;
            }
            DrawArrow(
            start.Bounds.IntersectsFromCenter(end.Bounds.GetCenter()),
            end.Bounds.IntersectsFromCenter(start.Bounds.GetCenter()),
            force);
        }

        private void DrawArrow(Point start, Point end, bool force)
        {
            if (!(force || QR.UpdateArrows)) return;

            Vector2 guide = new Vector2(start, end);
            Vector2 forward = guide.Normalized();
            Vector2 back = forward.Rotate(180f);
            Vector2 left = forward.Rotate(-90f);
            Vector2 right = forward.Rotate(90f);

            Vector2[] vectorPath = new Vector2[7];

            vectorPath[0] = left * (ArrowWidth / 2f);
            vectorPath[1] = vectorPath[0] + forward * (guide.Length - EndLength);
            vectorPath[2] = vectorPath[1] + left * ((EndWidth - ArrowWidth) / 2f);
            vectorPath[3] = guide;
            vectorPath[6] = right * (ArrowWidth / 2f);
            vectorPath[5] = vectorPath[6] + forward * (guide.Length - EndLength);
            vectorPath[4] = vectorPath[5] + right * ((EndWidth - ArrowWidth) / 2f);

            Vector2 min = new Vector2(vectorPath.Min(v => v.X), vectorPath.Min(v => v.Y));
            Vector2 max = new Vector2(vectorPath.Max(v => v.X), vectorPath.Max(v => v.Y));
            Point topLeft = start + min;
            Point width = max - min;

            Location = topLeft;
            Size = new Size(width);
            
            GraphicsPath path = new GraphicsPath();            
            path.AddLines((from v in vectorPath select (PointF)(v - min)).ToArray<PointF>());            
            Region = new Region(path);

            Invalidate();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StartBlock.LocationChanged -= OnBlockMove;
                StartBlock.MoveEnd -= OnBlockMove;
                EndBlock.LocationChanged -= OnBlockMove;
                EndBlock.MoveEnd -= OnBlockMove;
            }
            base.Dispose(disposing);
        }
    }
}
