using System;
using System.Collections.Generic;
using System.Windows.Input;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Input;
using HomeDiagramming.Core.Services;

namespace HomeDiagramming.Services
{
  public class ToolService : IDiagramToolService
  {
    #region Fields

    private IServiceProvider hostProvider;
    private Dictionary<Guid, IDiagramTool> tools;

    #endregion

    #region ctor

    public ToolService(IServiceProvider host, IDrawingSurface drawingSurface)
    {
      if (host == null)
        throw new ArgumentNullException("host");
      if (drawingSurface == null)
        throw new ArgumentNullException("drawingSurface");

      hostProvider = host;
      DrawingSurface = drawingSurface;
      InitializeService();
    }

    #endregion

    #region Initialization
    private void InitializeService()
    {
      tools = new Dictionary<Guid, IDiagramTool>();
            
      DrawingSurface.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DrawingSurface_MouseDown);
      DrawingSurface.MouseMove += new MouseEventHandler(DrawingSurface_MouseMove);
      DrawingSurface.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(DrawingSurface_MouseUp);
    } 
    #endregion

    #region Input events binding

    void DrawingSurface_MouseDown(object sender, MouseButtonEventArgs e)
    {
      foreach (IDiagramTool tool in tools.Values)
      {
        if (tool is IMouseListener)
        {
          ((IMouseListener)tool).MouseDown(e);
          if (e.Handled) return;
        }
      }
    }

    void DrawingSurface_MouseMove(object sender, MouseEventArgs e)
    {
      foreach (IDiagramTool tool in tools.Values)
      {
        if (tool is IMouseListener)
        {
          ((IMouseListener)tool).MouseMove(e);
          if (e.Handled) return;
        }
      }
    }

    void DrawingSurface_MouseUp(object sender, MouseButtonEventArgs e)
    {
      foreach (IDiagramTool tool in tools.Values)
      {
        if (tool is IMouseListener)
        {
          ((IMouseListener)tool).MouseUp(e);
          if (e.Handled) return;
        }
      }
    } 

    #endregion

    #region IDiagramToolService Members

    public IDrawingSurface DrawingSurface { get; private set; }

    public void RegisterTool(IDiagramTool tool)
    {
      if (tool == null) return;

      if (!tools.ContainsKey(tool.ToolId))
      {
        tools.Add(tool.ToolId, tool);
        tool.ToolService = this;
      }
    }

    public void UnregisterTool(IDiagramTool tool)
    {
      if (tool == null) return;

      if (tools.ContainsKey(tool.ToolId))
        tools.Remove(tool.ToolId);
    }

    public void UnsuspendAll()
    {
      foreach (IDiagramTool tool in tools.Values)
        tool.IsSuspended = false;
    }

    public void SuspendAll()
    {
      foreach (IDiagramTool tool in tools.Values)
        tool.IsSuspended = true;
    }

    public void SuspendAll(IDiagramTool exclude)
    {
      foreach (IDiagramTool tool in tools.Values)
      {
        if (tool.ToolId != exclude.ToolId)
          tool.IsSuspended = true;
      }
    }

    public IDiagramTool GetTool(string name)
    {
      foreach (IDiagramTool tool in tools.Values)
      {
        if (tool.Name == name)
          return tool;
      }
      return null;
    }

    public IDiagramTool GetTool(Guid toolId)
    {
      if (tools.ContainsKey(toolId))
        return tools[toolId];
      else
        return null;
    }

    public bool ActivateTool(Guid toolId)
    {
      IDiagramTool tool = GetTool(toolId);
      return ActivateTool(tool);
    }

    public bool ActivateTool(IDiagramTool tool)
    {
      if (tool != null && tool.CanActivate)
        return tool.Activate();
      else
        return false;
    }

    public bool DeactivateTool(IDiagramTool tool)
    {
      if (tool != null && tool.Enabled && tool.IsActive)
        return tool.Deactivate();
      else
        return false;
    }

    public void DeactivateAll()
    {
      foreach (IDiagramTool tool in tools.Values)
        tool.Deactivate();
    }

    #endregion

    #region IServiceProvider Members

    public object GetService(Type serviceType)
    {
      return hostProvider.GetService(serviceType);
    }

    #endregion
  }
}
