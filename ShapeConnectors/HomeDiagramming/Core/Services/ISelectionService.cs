using System;

namespace HomeDiagramming.Core.Services
{
  public interface ISelectionService
  {
    ISelectable SelectedObject { get; }

    void ClearSelection();
  }
}
