using System.Windows;
using System.Windows.Controls;
using HomeDiagramming.Core;

namespace HomeDiagramming.ShapeCreators
{
  public class SystemStageCreator : IShapeCreator
  {
    #region IShapeCreator Members

    public System.Windows.UIElement Create(Point position)
    {
      BasicShape shape = new BasicShape();
      shape.Template = Application.Current.Resources["BasicShape2"] as ControlTemplate;
      shape.UpdateLayout();
      Canvas.SetLeft(shape, position.X);
      Canvas.SetTop(shape, position.Y);

      return shape;
    }
    #endregion
  }

  public class UserStageCreator : IShapeCreator
  {
    #region IShapeCreator Members

    public UIElement Create(Point position)
    {
      BasicShape shape = new BasicShape();
      shape.Template = Application.Current.Resources["BasicShape1"] as ControlTemplate;
      shape.UpdateLayout();
      Canvas.SetLeft(shape, position.X);
      Canvas.SetTop(shape, position.Y);

      return shape;
    }

    #endregion
  }

  public class DataStageCreator : IShapeCreator
  {
    #region IShapeCreator Members

    public UIElement Create(Point position)
    {
      BasicShape shape = new BasicShape();
      shape.Template = Application.Current.Resources["BasicShape3"] as ControlTemplate;
      shape.UpdateLayout();
      Canvas.SetLeft(shape, position.X);
      Canvas.SetTop(shape, position.Y);

      return shape;
    }

    #endregion
  }

}
