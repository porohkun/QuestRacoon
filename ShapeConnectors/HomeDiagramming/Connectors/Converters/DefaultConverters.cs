using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using HomeDiagramming.Core;

namespace HomeDiagramming.Connectors.Converters
{
  public class DefaultCenterBinding : IMultiValueConverter
  {
    #region IMultiValueConverter Members

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      double left = System.Convert.ToDouble(values[0]);
      double top = System.Convert.ToDouble(values[1]);
      Point centerOffset = (Point)parameter;
      return new Point(left + centerOffset.X, top + centerOffset.Y);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }

  public class DefaultAngleCenterBinding : IMultiValueConverter
  {
    #region IMultiValueConverter Members

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      Point centerOffset = (Point)parameter;

      Point p1 = new Point(
          System.Convert.ToDouble(values[0]) + centerOffset.X,
          System.Convert.ToDouble(values[1]) + centerOffset.Y);

      Point p2 = new Point(
          System.Convert.ToDouble(values[2]),
          System.Convert.ToDouble(values[3]));


      Vector a = new Vector(0, Math.Abs((p1.Y != p2.Y) ? p1.Y - p2.Y : p2.Y));
      Vector b = new Vector(p2.X - p1.X, p1.Y - p2.Y);
      double angle = Vector.AngleBetween(b, a);

      // TODO: provide correct radius for the shape
      //double radius = centerOffset.X;
      double radius = Math.Max(centerOffset.X, centerOffset.Y);

      double x = radius * Math.Sin(angle * Math.PI / 180);
      double y = radius * Math.Cos(angle * Math.PI / 180);

      Point touchPoint = new Point(p1.X + x, p1.Y - y);

      return touchPoint;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    #endregion
  }

  public class ConnectionSplineConverter : IMultiValueConverter
  {
    // Methods
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (values.Length != 4)
      {
        return null;
      }
      for (int i = 0; i < 4; i++)
      {
        if (!(values[i] is double))
        {
          return null;
        }
      }

      double[] offsets = (double[])parameter;

      double x1 = (double)values[0] + offsets[0];
      double y1 = (double)values[1] + offsets[1];
      double x2 = (double)values[2] + offsets[2];
      double y2 = (double)values[3] + offsets[3];

      return GetSpline(x1, y1, x2, y2);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      return null;
    }

    internal static Geometry GetSpline(double x1, double y1, double x2, double y2)
    {
      PathGeometry geometry = new PathGeometry();
      PathFigure figure = new PathFigure();
      double num = Math.Max((double)(Math.Abs((double)(x2 - x1)) / 2.0), (double)20.0);
      figure.StartPoint = new Point(x1, y1);
      BezierSegment segment = new BezierSegment
      {
        Point1 = new Point(x1 + num, y1),
        Point2 = new Point(x2 - num, y2),
        Point3 = new Point(x2, y2)
      };
      figure.Segments.Add(segment);
      geometry.Figures.Add(figure);
      return geometry;
    }
  }
}
