using System;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace HomeDiagramming.Adorners
{
  public class SimpleSircleAdorner : Adorner
  {
    public SimpleSircleAdorner(UIElement adornedElement)
      : base(adornedElement)
    {
    }

    protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
    {
      Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

      SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
      renderBrush.Opacity = 0.2;
      Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
      double renderRadius = 2.0;

      drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
      drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
      drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
      drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
    }
  }
}
