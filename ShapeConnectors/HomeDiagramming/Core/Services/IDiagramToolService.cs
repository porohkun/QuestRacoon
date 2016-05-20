using System;

namespace HomeDiagramming.Core.Services
{
  /// <summary>
  /// The starting point for the all toolbox services application deals with
  /// </summary>
  public interface IDiagramToolService: IServiceProvider
  {
    IDrawingSurface DrawingSurface { get; }

    void RegisterTool(IDiagramTool tool);
    void UnregisterTool(IDiagramTool tool);

    void UnsuspendAll();
    void SuspendAll();
    void SuspendAll(IDiagramTool exclude);

    IDiagramTool GetTool(Guid toolId);
    IDiagramTool GetTool(string name);
    
    bool ActivateTool(Guid toolId);
    bool ActivateTool(IDiagramTool tool);

    bool DeactivateTool(IDiagramTool tool);
    void DeactivateAll();
  }
}
