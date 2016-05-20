using System.Windows;
using System.Windows.Media;

namespace HomeDiagramming.Connectors
{
    public class PlainLineConnector : DiagramObjectConnector
    {
        LineGeometry linegeo;

        public PlainLineConnector()
        {
            linegeo = new LineGeometry();
                        
            this.Stroke = Brushes.Black;
            this.StrokeThickness = 2;
        }

        protected override Geometry DefiningGeometry
        {
            get
            {                
                linegeo.StartPoint = StartPoint;
                linegeo.EndPoint = EndPoint;
                return linegeo;
            }
        }
    }
}
