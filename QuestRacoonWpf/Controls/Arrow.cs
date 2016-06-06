using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace QuestRacoonWpf
{
    public class Arrow : Shape
    {
        public static readonly DependencyProperty ArrowAngleProperty = DependencyProperty.Register("ArrowAngle", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(45.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ArrowLengthProperty = DependencyProperty.Register("ArrowLength", typeof(double), typeof(Arrow), new FrameworkPropertyMetadata(12.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ArrowEndsProperty = DependencyProperty.Register("ArrowEnds", typeof(ArrowEnds), typeof(Arrow), new FrameworkPropertyMetadata(ArrowEnds.End, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double ArrowAngle
        {
            set { SetValue(ArrowAngleProperty, value); }
            get { return (double)GetValue(ArrowAngleProperty); }
        }

        public double ArrowLength
        {
            set { SetValue(ArrowLengthProperty, value); }
            get { return (double)GetValue(ArrowLengthProperty); }
        }

        public ArrowEnds ArrowEnds
        {
            set { SetValue(ArrowEndsProperty, value); }
            get { return (ArrowEnds)GetValue(ArrowEndsProperty); }
        }
        
        public FlowBlock Start;
        public FlowBlock End;

        public Arrow()
        {
            Stroke = Brushes.Black;
            StrokeThickness = 2;
        }

        public void SetEnds(FlowBlock start, FlowBlock end)
        {
            Start = start;
            start.Moving += flowBlock_Moved;
            start.WantBeDeleted += block_WantBeDeleted;
            End = end;
            end.Moving += flowBlock_Moved;
            end.WantBeDeleted += block_WantBeDeleted;
            InvalidateMeasure();
        }

        private void block_WantBeDeleted()
        {
            Delete();
        }

        public void Delete()
        {
            Start.Moving -= flowBlock_Moved;
            Start.WantBeDeleted -= block_WantBeDeleted;
            End.Moving -= flowBlock_Moved;
            End.WantBeDeleted -= block_WantBeDeleted;
            var workspace = this.Parent as Workspace;
            workspace.Children.Remove(this);
        }

        private void flowBlock_Moved(FlowBlock sender)
        {
            InvalidateMeasure();
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                var geom = new StreamGeometry();
                if (Start != null && End != null)
                {
                    Rect startBounds = new Rect(Canvas.GetLeft(Start), Canvas.GetTop(Start), Start.Width, Start.Height);
                    Rect endBounds = new Rect(Canvas.GetLeft(End), Canvas.GetTop(End), End.Width, End.Height);

                    Point startPoint = startBounds.IntersectsFromCenter(endBounds.GetCenter());
                    Point endPoint = endBounds.IntersectsFromCenter(startBounds.GetCenter());

                    using (var ctx = geom.Open())
                    {
                        ctx.BeginFigure(startPoint, false, false);
                        ctx.LineTo(endPoint, true, false);

                        if ((ArrowEnds & ArrowEnds.Start) == ArrowEnds.Start)
                            CalculateArrow(ctx, endPoint, startPoint);

                        if ((ArrowEnds & ArrowEnds.End) == ArrowEnds.End)
                            CalculateArrow(ctx, startPoint, endPoint);
                    }
                }
                return geom;
            }
        }

        public object EndName { get; internal set; }

        void CalculateArrow(StreamGeometryContext ctx, Point pt1, Point pt2)
        {
            Matrix matx = new Matrix();
            Vector vect = pt1 - pt2;
            vect.Normalize();
            vect *= ArrowLength;

            matx.Rotate(ArrowAngle / 2);
            ctx.BeginFigure(pt2 + vect * matx, false, false);
            matx.Rotate(-ArrowAngle);
            ctx.PolyLineTo(new[] { pt2, pt2 + vect * matx }, true, false);
        }

    }
}
