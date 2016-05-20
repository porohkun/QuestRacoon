using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using HomeDiagramming.Core;
using System.Windows.Documents;
using HomeDiagramming.Adorners;

namespace HomeDiagramming
{
  public class BasicShape : Thumb, IDraggable, IConnectable, IDiagramObject, ISelectable
  {
    AdornerLayer adornerLayer;
    SimpleSircleAdorner adorner;

    #region Constructors
    public BasicShape()
      : base()
    {
      this.CanDrag = true;
      this.CanConnect = true;
      this.DragDelta += new DragDeltaEventHandler(BasicShape_DragDelta);

      adorner = new SimpleSircleAdorner(this);
    }

    void BasicShape_DragDelta(object sender, DragDeltaEventArgs e)
    {
      if (!CanDrag)
        return;

      Canvas.SetLeft(this, Canvas.GetLeft(this) + e.HorizontalChange);
      Canvas.SetTop(this, Canvas.GetTop(this) + e.VerticalChange);
    }
    #endregion

    #region IDraggable Members

    public bool CanDrag { get; set; }

    #endregion

    #region IConnectable Members

    public bool CanConnect { get; set; }

    #endregion

    #region ISelectable Members

    public void Select()
    {
      if (adornerLayer == null)
        adornerLayer = AdornerLayer.GetAdornerLayer(this);

      adornerLayer.Add(adorner);
    }

    public void Unselect()
    {
      adornerLayer.Remove(adorner);
    }

    #endregion    
  }
}
