using System.Windows.Controls;
using System.Windows.Input;
using HomeDiagramming.Core.Services;
using System;

namespace HomeDiagramming.Core
{
  public interface IDiagramTool
  {
    /// <summary>
    /// Get the tool service responsible for maintaining this tool.
    /// </summary>
    IDiagramToolService ToolService { get; set; }

    /// <summary>
    /// Get the type of the content creator
    /// </summary>
    Type ContentCreator { get; }

    /// <summary>
    /// Get user friendly name of the tool.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Unique id of the tool.
    /// </summary>
    Guid ToolId { get; }
    
    /// <summary>
    /// Gets/Sets a value indicating whether the tool is active. True value means the tool is actually performing an activity.
    /// If Enabled property is set to false the tool can never be activated.
    /// If IsSuspeneded property is set to true the tool's activity was suspended by another tool.
    /// </summary>
    bool IsActive { get; set; }

    /// <summary>
    /// Get a value indicating whether the tool can be activated.
    /// </summary>
    bool CanActivate { get; }

    /// <summary>
    /// Get/Set a value indicating whether the tool is enabled.
    /// </summary>
    bool Enabled { get; set; }

    /// <summary>
    /// Get/Set a value indicating the tool is suspended.
    /// A tool enters this mode when another tool being activated disallows it to continue normal activity.
    /// The suspended state is independent on the IsActive and Enabled states.
    /// </summary>
    bool IsSuspended { get; set; }

    /// <summary>
    /// Get the command assigned for this tool.
    /// </summary>
    RoutedUICommand Command { get; }

    /// <summary>
    /// Called when the UICommand is evaluated for the ability to be executed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event data.</param>
    void OnQueryEnabled(object sender, CanExecuteRoutedEventArgs e);

    /// <summary>
    /// Called to execute the command assigned for the tool.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void OnExecute(object sender, ExecutedRoutedEventArgs e);

    /// <summary>
    /// Activate the tool.
    /// </summary>
    /// <returns>Returns true if the operation finished successfully otherwise false.</returns>
    bool Activate();

    /// <summary>
    /// Deactivate the tool.
    /// </summary>
    /// <returns>Returns true if the operation finished successfully otherwise false.</returns>
    bool Deactivate();
  }
}