using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool isMoving = false;                  //False - ignore mouse movements and don't scroll
        private Point? startPosition = null;



        private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.isMoving == true) //Moving with a released wheel and pressing a button
                this.CancelScrolling();
            else if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Pressed)
            {
                if (this.isMoving == false) //Pressing a wheel the first time
                {
                    this.isMoving = true;
                    this.startPosition = e.GetPosition(sender as IInputElement);
                }
            }
        }

        private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle && e.ButtonState == MouseButtonState.Released)
                this.CancelScrolling();
        }

        private void CancelScrolling()
        {
            this.isMoving = false;
            this.startPosition = null;
        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMoving && Mouse.MiddleButton == MouseButtonState.Pressed)
            {
                var currentPosition = e.GetPosition(scrollViewer);
                var offset = currentPosition - startPosition.Value;
                
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset.Y);
                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - offset.X);
                this.startPosition = e.GetPosition(sender as IInputElement);
            }
            else
                CancelScrolling();
        }
        
        private void menuItemNewBlock_Click(object sender, RoutedEventArgs e)
        {
            var currentPosition = Mouse.GetPosition(scrollViewer);
            
        }
        
        private void ContextMenu_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }
    }
}
