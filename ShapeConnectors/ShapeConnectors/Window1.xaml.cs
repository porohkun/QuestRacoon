using System.Windows;
using System.Windows.Input;
using HomeDiagramming;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Services;
using HomeDiagramming.Services;

namespace ShapeConnectors
{
  public partial class Window1 : Window
  {
    DiagramDesigner designer;

    public Window1()
    {
      InitializeComponent();
      designer = new DiagramDesigner(drawingSurface);
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      #region Configure command bindings
      UndoService undoService = designer.GetService<IUndoService>() as UndoService;
      if (undoService != null)
      {
        this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, undoService.OnExecuteUndo, undoService.OnCanExecuteUndo));
        this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, undoService.OnExecuteRedo, undoService.OnCanExecuteRedo));
      }

      this.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, designer.OnExecuteDeleteShape, designer.OnCanExecuteDeleteShape));
      #endregion

      IDiagramToolService toolservice = designer.GetService<IDiagramToolService>();
      if (toolservice != null)
      {
        IDiagramTool tool = toolservice.GetTool("TUserStage");
        if (tool != null)
        {
          toolUserStage.Command = tool.Command;
          toolUserStage.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }

        tool = toolservice.GetTool("TSystemStage");
        if (tool != null)
        {
          toolSystemStage.Command = tool.Command;
          toolSystemStage.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }

        tool = toolservice.GetTool("TDataStage");
        if (tool != null)
        {
          toolDataStage.Command = tool.Command;
          toolDataStage.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }

        tool = toolservice.GetTool("TConnector1");
        if (tool != null)
        {
          toolLink1.Command = tool.Command;
          toolLink1.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }

        tool = toolservice.GetTool("TConnector2");
        if (tool != null)
        {
          toolLink2.Command = tool.Command;
          toolLink2.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }

        tool = toolservice.GetTool("TConnector3");
        if (tool != null)
        {
          toolLink3.Command = tool.Command;
          toolLink3.CommandBindings.Add(new CommandBinding(tool.Command, tool.OnExecute, tool.OnQueryEnabled));
        }
      }
      //System.Type t1 = System.Type.GetType("HomeDiagramming.BasicShape, HomeDiagramming");      
    }

    private void cmdSelectMove_Click(object sender, RoutedEventArgs e)
    {
      IDiagramToolService toolService = designer.GetService<IDiagramToolService>();
      if (toolService != null)
        toolService.DeactivateAll();
    }
  }
}