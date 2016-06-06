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
        private Quest.Quest _quest;
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

        public BlockEditWindow(Quest.Block block, Quest.Quest quest, string locale) : this()
        {
            _block = block;
            _quest = quest;
            Title = _block.Name;
            headerBox.Text = _block.Name;

            var firstOp = operators.Children[0];

            foreach (var op in _block)
                CreateOperatorControl(op);

            operators.Children.Remove(firstOp);

            foreach (var loc in _quest.Locales)
                localesBox.Items.Add(loc);

            SwitchLocale(locale);
        }

        private void CreateOperatorControl(IOperator op)
        {
            BaseOperatorControl opc = null;
            switch (op.Type)
            {
                case Quest.OperatorType.Assignment: opc = new AssignmentControl(op as Quest.Assignment, _quest); break;
                case Quest.OperatorType.Condition: opc = new ConditionControl(op as Quest.Condition); break;
                case Quest.OperatorType.ConditionElse: opc = new ConditionElseControl(op as Quest.ConditionElse); break;
                case Quest.OperatorType.ConditionEnd: opc = new ConditionEndControl(op as Quest.ConditionEnd); break;
                case Quest.OperatorType.Description: opc = new DescriptionControl(op as Quest.Description); break;
                case Quest.OperatorType.Link: opc = new LinkControl(op as Quest.Link, _quest); break;
                case Quest.OperatorType.Speech: opc = new SpeechControl(op as Quest.Speech); break;
            }
            if (opc != null)
            {
                operators.Children.Add(opc as UIElement);
                opc.WantBeDeleted += Opc_WantBeDeleted;
            }
        }

        private void Opc_WantBeDeleted(BaseOperatorControl obj)
        {
            operators.Children.Remove(obj as UIElement);
        }

        private void SwitchLocale(string locale)
        {
            _locale = locale;
            localesBox.SelectedItem = locale;
            foreach (BaseOperatorControl op in operators.Children)
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
            string type = ((Button)sender).Content as string;
            IOperator op = null;
            switch (type)
            {
                case "Assignment": op = new Quest.Assignment(); break;
                case "Condition": op = new Quest.Condition(); break;
                case "Else": op = new Quest.ConditionElse(); break;
                case "End": op = new Quest.ConditionEnd(); break;
                case "Description": op = new Quest.Description(); break;
                case "Link": op = new Quest.Link(); break;
                case "Speech": op = new Quest.Speech(); break;
            }
            if (op != null)
            {
                _block.Add(op);
                CreateOperatorControl(op);
            }
        }

        private void operators_ChildReordered(UIElement control, int oldIndex, int newIndex)
        {
            var opc = control as BaseOperatorControl;
            _block.MoveByIndex(oldIndex, newIndex);
        }

        private void localesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwitchLocale((string)localesBox.SelectedItem);
        }
    }
}
