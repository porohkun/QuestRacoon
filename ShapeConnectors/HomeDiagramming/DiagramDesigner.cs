using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HomeDiagramming.Commands;
using HomeDiagramming.Connectors;
using HomeDiagramming.Connectors.Converters;
using HomeDiagramming.Core;
using HomeDiagramming.Core.Services;
using HomeDiagramming.Services;
using HomeDiagramming.ShapeCreators;
using HomeDiagramming.Tools;

namespace HomeDiagramming
{
  public class DiagramDesigner : IDiagramDesigner
  {
    public DrawingCanvas DiagramView { get; private set; }

    #region ctor
    public DiagramDesigner(DrawingCanvas surface)
    {
      this.DiagramView = surface;
      surface.Background = Brushes.White;
      surface.ClipToBounds = true;
      InitializeComponent();
    }
    #endregion

    private SelectionService selectionService;
    private UndoService undoService;
    private ToolService toolService;

    private void InitializeComponent()
    {      
      _services = new Dictionary<Type, object>();

      undoService = new UndoService();
      this.AddService<IUndoService>(undoService);

      // TODO: this should be registered after tool service??
      selectionService = new SelectionService(DiagramView);
      this.AddService<ISelectionService>(selectionService);

      toolService = new ToolService(this, DiagramView);
      this.AddService<IDiagramToolService>(toolService);

      toolService.RegisterTool(new SimpleStageTool("TUserStage", typeof(UserStageCreator)));
      toolService.RegisterTool(new SimpleStageTool("TSystemStage", typeof(SystemStageCreator)));
      toolService.RegisterTool(new SimpleStageTool("TDataStage", typeof(DataStageCreator)));
      toolService.RegisterTool(new SimpleArrowConnectorTool("TConnector1", null));
      toolService.RegisterTool(new SimplePlainLineConnectorTool("TConnector2", null));
      toolService.RegisterTool(new SimpleBezierConnectorTool("TConnector3", null));
    }

    public void DeleteShape()
    {
      if (selectionService.SelectedObject != null)
      {
        DeleteShapeCommand command = new DeleteShapeCommand(DiagramView, selectionService.SelectedObject as BasicShape);
        undoService.Execute(command);
        selectionService.ClearSelection();
      }
    }

    #region Command binding support
    
    #region Delete shape command
    public void OnExecuteDeleteShape(object sender, ExecutedRoutedEventArgs e)
    {
      this.DeleteShape();
    }

    public void OnCanExecuteDeleteShape(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = (selectionService.SelectedObject != null);
    }  
    #endregion



    #endregion

    #region IServiceProvider Members
    private Dictionary<Type, object> _services;

    public void AddService(Type serviceType, object service)
    {
      if (serviceType == null)
        throw new ArgumentNullException("serviceType");
      
      if (service == null)
        throw new ArgumentNullException("service");
      
      if (!this._services.ContainsKey(serviceType))
        this._services.Add(serviceType, service);
      else if (this._services[serviceType] != service)
        throw new ArgumentException("Service already added!", "serviceType");
    }

    public object GetService(Type serviceType)
    {
      if (this._services.ContainsKey(serviceType))
        return this._services[serviceType];
      return null;
    }

    public void AddService<T>(T service)
    {
      AddService(typeof(T), service);      
    }

    public T GetService<T>()
    {
      Type t = typeof(T);
      
      if (this._services.ContainsKey(t))
        return (T)this._services[t];

      return default(T);
    }

    #endregion
  }
}