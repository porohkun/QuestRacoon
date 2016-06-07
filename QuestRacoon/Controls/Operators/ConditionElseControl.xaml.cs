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
    /// Interaction logic for ConditionElse.xaml
    /// </summary>
    public partial class ConditionElseControl : BaseOperatorControl
    {
        public override bool OpenIndent { get { return true; } }

        public override bool CloseIndent { get { return true; } }

        private ConditionElse _conditionElse;

        public ConditionElseControl()
        {
            InitializeComponent();
        }

        public ConditionElseControl(ConditionElse conditionElse) : this()
        {
            _conditionElse = conditionElse;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _conditionElse.Delete();
            OnVantBeDeleted(this);
        }

    }
}
