using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeDiagramming.Core
{
  public interface ISelectable
  {
    void Select();
    void Unselect();
  }
}
