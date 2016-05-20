
namespace HomeDiagramming.Core
{
  /// <summary>
  /// Provides the drag and drop support for diagram objects
  /// </summary>
  public interface IDraggable
  {
    bool CanDrag { get; }
  }
}
