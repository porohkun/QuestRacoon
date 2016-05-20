using System;
using System.Windows;
using System.Windows.Input;
using HomeDiagramming.Commands;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Input;
using HomeDiagramming.Core.Services;

namespace HomeDiagramming.Tools
{
  public class SimpleStageTool : DiagramTool, IMouseListener
  {
    #region ctor

    public SimpleStageTool(string name, Type contentCreator)
      : base(name, contentCreator)
    {
      this.ToolId = Guid.NewGuid();
    }

    #endregion

    #region Abstract class implementation

    //private Guid toolId = new Guid("12C760F3-B215-4e92-8E4F-2D7822833E08");
    //public override Guid ToolId
    //{
    //  get { return toolId; }
    //}
    //TODO: Temp implementation for testing multiple tools of same type based on different content creators
    public override Guid ToolId { get; protected set; }
    
        
    public override void OnExecute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
      Activate();
    }

    #endregion

    #region IMouseListener Members

    public void MouseDown(MouseEventArgs e)
    {
      if (IsSuspended) return;
            
      if (IsActive)
      {
        Point position = e.GetPosition(this.ToolService.DrawingSurface);
        IShapeCreator creator = Activator.CreateInstance(ContentCreator) as IShapeCreator;        
        UIElement shape = creator.Create(position);

        AddShapeCommand command = new AddShapeCommand(this.ToolService.DrawingSurface, shape);

        IUndoService undoService = this.ToolService.GetService(typeof(IUndoService)) as IUndoService;
        if (undoService != null)
        {
          undoService.Execute(command);
        }
        else
          command.Execute();

        e.Handled = true;
        Deactivate();      
      }      
    }

    public void MouseMove(MouseEventArgs e)
    {
      // Not required
    }

    public void MouseUp(MouseEventArgs e)
    {
      // Not required
    }

    public override void OnQueryEnabled(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = !IsSuspended;
    }

    #endregion
  }
}