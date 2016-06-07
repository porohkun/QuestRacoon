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
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for Condition.xaml
    /// </summary>
    public partial class ConditionControl : BaseOperatorControl
    {
        public override bool OpenIndent { get { return true; } }

        private Quest.Condition _condition;

        public ConditionControl()
        {
            InitializeComponent();
        }

        public ConditionControl(Quest.Condition condition) : this()
        {
            _condition = condition;
        }

        protected override void UpdateText()
        {
            conditionBox.Text = _condition.Value;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _condition.Delete();
            OnVantBeDeleted(this);
        }

        private void conditionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _condition.Value = conditionBox.Text;
        }
    }
}
