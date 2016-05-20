using System;

namespace HomeDiagramming.Core
{
  /// <summary>
  /// IDiagramCommand is an interface for undo/redo support.
  /// </summary>
  public interface IDiagramCommand
  {
    /// <summary>
    /// Executes the actual action
    /// </summary>
    void Execute();

    /// <summary>
    /// Executes an action corresponding to an undo
    /// </summary>
    void Undo();

    /// <summary>
    /// Executes an action corresponding to redo in case it has been undone.
    /// </summary>    
    void Redo();

    /// <summary>
    /// Title of the command.
    /// </summary>
    /// <remarks>Typically to be used in undo list or undo stack description.</remarks>
    string Title { get; set; }
  }
}
