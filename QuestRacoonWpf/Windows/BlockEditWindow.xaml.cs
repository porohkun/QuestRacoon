using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for BlockEditWindow.xaml
    /// </summary>
    public partial class BlockEditWindow : Window
    {
        private Quest.Block _block;
        private Dictionary<string, string> _texts = new Dictionary<string, string>();
        private string _locale;
        //private List<ToolStripButton> _localeButtons = new List<ToolStripButton>();

        public BlockEditWindow()
        {
            InitializeComponent();
            Rect location = QR.Set.BlockEditWindowStartupLocation;
            if (location != Rect.Empty)
            {
                Left = location.Left;
                Top = location.Top;
                Width = location.Width;
                Height = location.Height;
            }
        }

        public BlockEditWindow(Quest.Block block, string locale) : this()
        {
            _block = block;
            Title = _block.Name;
            headerBox.Text = _block.Name;

            var firstOp = operators.Children[0];

            foreach (var op in _block)
            {
                UIElement opc = null;
                switch (op.Type)
                {
                    case Quest.OperatorType.Assignment: break;
                    case Quest.OperatorType.Condition: break;
                    case Quest.OperatorType.ConditionElse: break;
                    case Quest.OperatorType.ConditionEnd: break;
                    case Quest.OperatorType.Description: opc = new DescriptionControl(op as Quest.Description); break;
                    case Quest.OperatorType.Link: break;
                    case Quest.OperatorType.Speech: break;
                }
                if (opc != null)
                {
                    operators.Children.Add(opc);
                }
            }

            operators.Children.Remove(firstOp);
            SwitchLocale(locale);
        }

        private void SwitchLocale(string locale)
        {
            _locale = locale;
            foreach (IOperatorControl op in operators.Children)
                op.Locale = locale;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _block.SetName(headerBox.Text);
            QR.Set.BlockEditWindowStartupLocation = new Rect(Left, Top, Width, Height);

            base.OnClosing(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            operators.Children.Add(new Label() { Content = "gggggggg" });
        }
    }
}
