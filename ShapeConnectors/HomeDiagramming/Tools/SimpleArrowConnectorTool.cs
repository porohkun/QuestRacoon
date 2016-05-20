using System;
using System.Windows;
using System.Windows.Input;
using HomeDiagramming.Connectors;
using HomeDiagramming.Connectors.Converters;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Input;

namespace HomeDiagramming.Tools
{
  public class SimpleArrowConnectorTool : DiagramTool, IMouseListener
  {
    #region ctor

    public SimpleArrowConnectorTool(string name, Type contentCreator)
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
            link = new ArrowLine();
            //link = System.Activator.CreateInstance<ArrowLine>();
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
            AddConnection(ConnectorType.Arrowhead, sourceObject, targetThumb);
        }
                
        Deactivate();
        // exit link drawing mode
        //e.Handled = true;        
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

    public void AddConnection(ConnectorType type, IConnectable source, IConnectable target)
    {
      switch (type)
      {
        case ConnectorType.Plain:
          {
            PlainLineConnector conn = new PlainLineConnector();
            conn.SetBinding(DiagramObjectConnector.StartPointProperty, BindingHelper.CreateCenteredBinding(source));
            conn.SetBinding(DiagramObjectConnector.EndPointProperty, BindingHelper.CreateCenteredBinding(target));
            this.ToolService.DrawingSurface.Children.Insert(0, conn);
            break;
          }
        case ConnectorType.Arrowhead:
          {
            ArrowLine conn = new ArrowLine();
            conn.SetBinding(DiagramObjectConnector.StartPointProperty, BindingHelper.CreateAngledBinding(source, target));
            conn.SetBinding(DiagramObjectConnector.EndPointProperty, BindingHelper.CreateAngledBinding(target, source));
            this.ToolService.DrawingSurface.Children.Insert(0, conn);
          }
          break;
      }
    }

    #endregion
  }
}
