/*
 * At current implementation the methods Execute and Redo have the same functionality.
 * Typically Execute method can be extended to provide some additional acions on execution
 * like showing dialogs, wizards etc. while Redo just rolls back the command
*/
using System;
using HomeDiagramming.Core;
using System.Windows.Controls;
using System.Windows;

namespace HomeDiagramming.Commands
{
  public class AddShapeCommand : IDiagramCommand
  {
    #region Properties

    public IDrawingSurface Surface { get; set; }
    public UIElement Shape { get; set; }

    #endregion

    #region ctor

    public AddShapeCommand(IDrawingSurface surface, UIElement shape)
    {
      if (surface == null) throw new ArgumentNullException("canvas");
      if (shape == null) throw new ArgumentNullException("shape");

      Surface = surface;
      Shape = shape;
    }

    #endregion

    #region IDiagramCommand Members

    public void Execute()
    {
      if (Shape != null && !Surface.Children.Contains(Shape))
      {        
        Surface.Children.Add(Shape);
        // TODO: Feature must be implemented
        // Extend ISelectionService and the classes exposing it
        // SelectionService.Select(Shape)
      }
    }

    public void Undo()
    {
      if (Shape != null && Surface.Children.Contains(Shape))
      {
        Surface.Children.Remove(Shape);
      
      // TODO: Feature must be implemented
      // Maybe SelectionService should itself do some analysis for children addition/removal?
      // SelectionService.UnselectAll
      }
    }

    public void Redo()
    {
      if (Shape != null && !Surface.Children.Contains(Shape))
      {
        Surface.Children.Add(Shape);
        // TODO: Feature must be implemented
        // Extend ISelectionService and the classes exposing it
        // SelectionService.Select(Shape)
      }
    }

    public string Title
    {
      get
      {
        //return "Shape added [" + Enum.GetName(typeof(ShapeTypes), this.ShapeType) + "]";
        return "Shape added [" + Shape.GetType().Name + "]";
      }
      set
      {
        //throw new NotImplementedException();
        // TODO: think over turning into getter only
      }
    }

    #endregion
  }
}
