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
using System.ComponentModel;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for Condition.xaml
    /// </summary>
    public partial class AssignmentControl : BaseOperatorControl, INotifyPropertyChanged
    {
        private Assignment _assignment;
        private Quest.Quest _quest;

        #region INotifyPropertyChanged

        private IEnumerable<string> _variables;
        private string _selectedVariable;

        public string SelectedVariable
        {
            get { return _selectedVariable; }
            set { SetField(ref _selectedVariable, value, "SelectedVariable"); }
        }

        public IEnumerable<string> Variables
        {
            get { return _variables; }
            set { SetField(ref _variables, value, "Variables"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
        
        public AssignmentControl()
        {
            InitializeComponent();
        }

        public AssignmentControl(Assignment assignment, Quest.Quest quest) : this()
        {
            _assignment = assignment;
            this._quest = quest;
            Variables = _quest.Variables.Select(b => b);
            BindingOperations.SetBinding(variableBox, AutoCompleteBox.ItemsSourceProperty, new Binding("Variables") { Source = this });
            BindingOperations.SetBinding(variableBox, AutoCompleteBox.SelectedItemProperty, new Binding("SelectedVariable") { Source = this, Mode = BindingMode.TwoWay });
        }

        protected override void UpdateText()
        {
            valueBox.Text = _assignment.Value;
            SelectedVariable = _assignment.Variable;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _assignment.Delete();
            OnVantBeDeleted(this);
        }

        private void assignment_LostFocus(object sender, RoutedEventArgs e)
        {
            _assignment.Variable = SelectedVariable != null ? SelectedVariable : variableBox.SearchText;
            _assignment.Value = valueBox.Text;
            _quest.RecalculateVariables();
            Variables = _quest.Variables.Select(b => b);
        }
    }
}
