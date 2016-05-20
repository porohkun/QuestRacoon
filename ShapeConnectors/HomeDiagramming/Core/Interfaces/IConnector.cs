using System;
using System.Windows;

namespace HomeDiagramming.Core
{
  public interface IConnector
  {
    Point StartPoint { get; set; }
    Point EndPoint { get; set; }
  }
}
