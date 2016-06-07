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
using QuestRacoon.Quest;

namespace QuestRacoon
{
    /// <summary>
    /// Interaction logic for ConditionEnd.xaml
    /// </summary>
    public partial class ConditionEndControl : BaseOperatorControl
    {
        public override bool CloseIndent { get { return true; } }

        private ConditionEnd _conditionEnd;

        public ConditionEndControl()
        {
            InitializeComponent();
        }

        public ConditionEndControl(ConditionEnd conditionEnd) : this()
        {
            _conditionEnd = conditionEnd;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _conditionEnd.Delete();
            OnVantBeDeleted(this);
        }

    }
}
