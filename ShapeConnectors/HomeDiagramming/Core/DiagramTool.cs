using System.Windows.Controls;
using System.Windows.Input;
using HomeDiagramming.Core.Services;
using System;

namespace HomeDiagramming.Core
{
  /// <summary>
  /// Base abstract class for the diagram tools
  /// </summary>
  public abstract class DiagramTool : IDiagramTool
  {
    #region Fields

    /// <summary>
    /// Keeps a reference to the previous cursor
    /// </summary>
    private Cursor oldCursor; 

    #endregion

    #region ctor

    public DiagramTool(string name, Type contentCreator)
    {
      this.Name = name;      
      this.Command = new RoutedUICommand();
      this.ContentCreator = contentCreator;
    }

    #endregion

    #region IDiagramTool Members

    public Type ContentCreator { get; private set; }
    public IDiagramToolService ToolService { get; set; }
    public string Name { get; set; }
    public abstract Guid ToolId { get; protected set; }
    public bool IsActive { get; set; }
    public bool IsSuspended { get; set; }
    public RoutedUICommand Command { get; protected set; }

    public virtual bool CanActivate
    {
      get { return (enabled) ? !this.IsActive : false; }
    }

    private bool enabled = true;
    public bool Enabled
    {
      get { return enabled; }
      set
      {
        // disable the tool first if it is active
        if (!value && IsActive)
          Deactivate();
        
        enabled = true;
      }
    }

    /// <summary>
    /// Determines if a command is enabled. Override to provide custom behavior. 
    /// Do not call the base version when overriding.
    /// </summary>
    public virtual void OnQueryEnabled(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
      e.Handled = true;
    }

    /// <summary>
    /// Function to execute the command.
    /// </summary>
    public abstract void OnExecute(object sender, System.Windows.Input.ExecutedRoutedEventArgs e);

    public bool Activate()
    {
      if (this.ToolService != null) this.ToolService.SuspendAll(this);

      if (Enabled && !IsActive)
      {
        oldCursor = Mouse.OverrideCursor;
        IsActive = true;
        //TODO: Implement events
        // OnActivateTool()
      }

      return IsActive;
    }

    public bool Deactivate()
    {
      if (IsActive)
      {
        //TODO: Implement events
        // OnDeactivateTool
        IsActive = false;
        RestoreCursor();
        if (ToolService != null) ToolService.UnsuspendAll();
        return true;
      }
      return false;
    }

    #endregion

    #region Methods
    protected void RestoreCursor()
    {
      if (oldCursor != null)
      {
        Mouse.OverrideCursor = oldCursor;
        oldCursor = null;
      }
    } 
    #endregion
  }
}
