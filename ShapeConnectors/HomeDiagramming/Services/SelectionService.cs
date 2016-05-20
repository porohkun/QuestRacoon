using System.Windows.Controls;
using System.Windows.Input;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Services;

namespace HomeDiagramming.Services
{
  public class SelectionService : ISelectionService
  {
    #region ctor
    public SelectionService(Canvas canvas)
    {
      canvas.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(canvas_PreviewMouseLeftButtonDown);
    } 
    #endregion

    void canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (e.Source is IDiagramObject)
      {
        if (SelectedObject != null)
          SelectedObject.Unselect();

        SelectedObject = e.Source as ISelectable;
        SelectedObject.Select();
      }
      else if (SelectedObject != null)
      {
        SelectedObject.Unselect();
        SelectedObject = null;
      }
    }

    #region ISelectionService Members
    
    public ISelectable SelectedObject { get; protected set; }

    public void ClearSelection()
    {
      if (SelectedObject != null)
      {
        SelectedObject.Unselect();
        SelectedObject = null;
      }
    }

    #endregion
  }
}