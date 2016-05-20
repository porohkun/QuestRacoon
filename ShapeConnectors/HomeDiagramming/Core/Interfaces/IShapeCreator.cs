using System.Windows;

namespace HomeDiagramming.Core
{
  public interface IShapeCreator
  {
    UIElement Create(Point position);
  }
}
