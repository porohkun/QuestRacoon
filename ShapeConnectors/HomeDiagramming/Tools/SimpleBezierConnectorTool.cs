using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Input;
using System.Windows.Input;
using System.Windows;
using HomeDiagramming.Connectors;
using System.Windows.Shapes;
using System.Windows.Media;
using HomeDiagramming.Connectors.Converters;

namespace HomeDiagramming.Tools
{ 
  public class SimpleBezierConnectorTool : DiagramTool, IMouseListener
  {
    #region ctor

    public SimpleBezierConnectorTool(string name, Type contentCreator)
      : base(name, contentCreator)
    {
      this.ToolId = Guid.NewGuid();
    }

    #endregion

    #region Diagram tool implementation
    public override Guid ToolId { get; protected set; }

    public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
    {
      Activate();
    }

    public override void OnQueryEnabled(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = !IsSuspended;
    }
    #endregion

    BasicShape sourceObject;
    IConnector link;
    bool isLinkStarted;

    #region IMouseListener Members

    public void MouseDown(MouseEventArgs e)
    {
      if (IsSuspended) return;

      if (IsActive)
      {
        if (e.Source is IConnectable && ((IConnectable)e.Source).CanConnect)
        {
          if (link == null || link.EndPoint != link.StartPoint)
          {
            Point position = e.GetPosition(this.ToolService.DrawingSurface);
            //link = new ArrowLine();
            //link = System.Activator.CreateInstance<ArrowLine>();
            link = new PlainLineConnector();
            link.StartPoint = link.EndPoint = position;

            this.ToolService.DrawingSurface.Children.Insert(0, (DiagramObjectConnector)link);
            isLinkStarted = true;
            sourceObject = e.Source as BasicShape;
            e.Handled = true;
          }
        }
        else
          Deactivate();
      }
    }

    public void MouseMove(MouseEventArgs e)
    {
      if (IsActive && isLinkStarted)
      {
        // Set the new link end point to current mouse position
        link.EndPoint = e.GetPosition(this.ToolService.DrawingSurface);
        e.Handled = true;
      }
    }

    public void MouseUp(MouseEventArgs e)
    {
      if (IsActive)
      {
        // We released the button on MyThumb object
        if (e.Source is IConnectable && ((IConnectable)e.Source).CanConnect)
        {
          BasicShape targetThumb = e.Source as BasicShape;
          // if any line was drawn (avoid just clicking on the thumb) establish connection
          if (e.GetPosition(this.ToolService.DrawingSurface) != link.StartPoint && sourceObject != targetThumb)
          {
            //AddConnection(ConnectorType.Plain, sourceObject, targetThumb);
            Path path = new Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 2;
            path.SetBinding(Path.DataProperty, BindingHelper.CreateBezierBinding(sourceObject, targetThumb));
            this.ToolService.DrawingSurface.Children.Insert(0, path);
          }
        }

        // exit link drawing mode
        //e.Handled = true;
        Deactivate();
      }

      isLinkStarted = false;

      if (link != null)
      {
        // remove line from the canvas
        this.ToolService.DrawingSurface.Children.Remove((DiagramObjectConnector)link);
        // clear the link variable
        link = null;
      }
    }

    

    #endregion
  }
}
