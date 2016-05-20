using System.Windows.Input;

namespace HomeDiagramming.Core.Input
{
  /// <summary>
  /// Provides binding mouse events support for diagram tools
  /// </summary>
  public interface IMouseListener
  {
    /// <summary>
    /// Handles the mouse-down event.
    /// </summary>
    /// <param name="e">Event data</param>
    void MouseDown(MouseEventArgs e);

    /// <summary>
    /// Handles the mouse-move event.
    /// </summary>
    /// <param name="e">Event data</param>
    void MouseMove(MouseEventArgs e);

    /// <summary>
    /// Handles the mouse-up event.
    /// </summary>
    /// <param name="e"></param>
    void MouseUp(MouseEventArgs e);
  }
}
