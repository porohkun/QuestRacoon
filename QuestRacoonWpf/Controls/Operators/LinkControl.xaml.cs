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
    /// Interaction logic for LinkControl.xaml
    /// </summary>
    public partial class LinkControl : BaseOperatorControl, INotifyPropertyChanged
    {
        private Link _link;
        private Quest.Quest _quest;

        private IEnumerable<string> _blocks;
        private string _selectedBlock;

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

        public string SelectedBlock
        {
            get { return _selectedBlock; }
            set { SetField(ref _selectedBlock, value, "SelectedBlock"); }
        }
        
        public IEnumerable<string> Blocks
        {
            get { return _blocks; }
            set { SetField(ref _blocks, value, "Blocks"); }
        }

        public LinkControl()
        {
            InitializeComponent();
        }

        public LinkControl(Link link, Quest.Quest quest) : this()
        {
            this._link = link;
            this._quest = quest;
            Blocks = _quest.Blocks.Select(b => b.Name);
            BindingOperations.SetBinding(blockBox, AutoCompleteBox.ItemsSourceProperty, new Binding("Blocks") { Source = this });
            BindingOperations.SetBinding(blockBox, AutoCompleteBox.SelectedItemProperty, new Binding("SelectedBlock") { Source = this, Mode = BindingMode.TwoWay });
        }

        protected override void UpdateText()
        {
            textBox.Text = _link.Text;
            SelectedBlock = _link.To;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox.MaxHeight = 25;
            _link.Text = textBox.Text;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.MaxHeight = 102;
            textBox.Height = 102;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _link.Delete();
            OnVantBeDeleted(this);
        }

        private void blockBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _link.To = SelectedBlock != null ? SelectedBlock : blockBox.SearchText;
        }
    }
}
