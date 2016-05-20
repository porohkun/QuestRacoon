using System;
using System.Windows.Controls;
using HomeDiagramming.Core;

namespace HomeDiagramming.Commands
{
  public class DeleteShapeCommand : IDiagramCommand
  {
    #region Properties

    public Canvas Canvas { get; set; }
    public BasicShape Shape { get; set; }

    #endregion

    #region ctor

    public DeleteShapeCommand(Canvas canvas, BasicShape shape)
    {
      if (canvas == null) throw new ArgumentNullException("canvas");
      if (shape == null) throw new ArgumentNullException("shape");

      Canvas = canvas;
      Shape = shape;
    }

    #endregion

    #region IDiagramCommand Members

    public void Execute()
    {
      if (Shape == null || Canvas == null) return;
      
      if (Canvas.Children.Contains(Shape))
      {
        Canvas.Children.Remove(Shape);
      }
    }

    public void Undo()
    {
      if (Shape == null || Canvas == null) return;

      if (!Canvas.Children.Contains(Shape))
        Canvas.Children.Add(Shape);
    }

    public void Redo()
    {
      if (Shape == null || Canvas == null) return;

      if (Canvas.Children.Contains(Shape))
        Canvas.Children.Remove(Shape);
    }

    public string Title
    {
      get
      {
        return "Shape deleted [" + Shape.GetType().Name + "]";
      }
      set
      {
        //
      }
    }

    #endregion
  }
}
