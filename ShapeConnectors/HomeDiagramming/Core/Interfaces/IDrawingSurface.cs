using System;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace HomeDiagramming.Core
{
  public interface IDrawingSurface: IInputElement
  {
    UIElementCollection Children { get; }
  }
}
