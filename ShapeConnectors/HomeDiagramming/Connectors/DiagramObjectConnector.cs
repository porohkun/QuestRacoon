using System.Windows;
using System.Windows.Shapes;
using HomeDiagramming.Core;

namespace HomeDiagramming.Connectors
{
  public abstract class DiagramObjectConnector : Shape, IConnector
  {
    public static readonly DependencyProperty StartPointProperty = DependencyProperty.Register("StartPoint", typeof(Point), typeof(DiagramObjectConnector), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsMeasure));
    public static readonly DependencyProperty EndPointProperty = DependencyProperty.Register("EndPoint", typeof(Point), typeof(DiagramObjectConnector), new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsMeasure));

    #region IConnector members
    public Point StartPoint
    {
      get { return (Point)GetValue(StartPointProperty); }
      set { SetValue(StartPointProperty, value); }
    }

    public Point EndPoint
    {
      get { return (Point)GetValue(EndPointProperty); }
      set { SetValue(EndPointProperty, value); }
    } 
    #endregion
  }
}