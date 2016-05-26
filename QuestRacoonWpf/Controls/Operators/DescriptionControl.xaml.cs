using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for DescriptionControl.xaml
    /// </summary>
    public partial class DescriptionControl : UserControl, IOperatorControl
    {
        double _row0H = 0;
        double _row1H = 0;
        public DescriptionControl()
        {
            InitializeComponent();

            //textBox.CurrentHighlighter = AurelienRibon.Ui.SyntaxHighlightBox.HighlighterManager.Instance.Highlighters["MyNewSyntax"];
            _row0H = row0.Height.Value;
            _row1H = row1.Height.Value;
            row0.Height = new GridLength(0);
            row1.Height = new GridLength(0);
        }
        
        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            row0.Height = new GridLength(0);
            row1.Height = new GridLength(0);
            textBox.MaxHeight = 22;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            row0.Height = new GridLength(_row0H);
            row1.Height = new GridLength(_row1H);
            textBox.MaxHeight = 66;
            textBox.Height = 66;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var action = (string)((Button)sender).Content;

            switch (action)
            {
                case "{b}": break;
                case "{i}": break;
                case "{color}": break;
                case "{s}": break;
                case "{w}": InsertText("{w}"); break;
                case "{wi}": break;
                case "{wc}": break;
                case "{c}": break;
                case "{x}": break;
            }
        }

        private void InsertText(string text)
        {
            //textBox.selecti
            
        }
    }
}
