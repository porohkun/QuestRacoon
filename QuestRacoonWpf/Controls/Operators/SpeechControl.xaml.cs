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
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for SpeechControl.xaml
    /// </summary>
    public partial class SpeechControl : BaseOperatorControl
    {       
        private Speech _speech;
        
        public SpeechControl()
        {
            InitializeComponent();
        }

        public SpeechControl(Speech speech) : this()
        {
            this._speech = speech;
        }

        protected override void UpdateText()
        {
            textBox.Text = _speech.Text.GetText(Locale);
            characterBox.Text = _speech.Character;
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            textBox.MaxHeight = 25;
            _speech.Text.SetText(textBox.Text, Locale);
        }

        private void characterBox_LostFocus(object sender, RoutedEventArgs e)
        {
            _speech.Character = characterBox.Text;
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox.MaxHeight = 102;
            textBox.Height = 102;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _speech.Delete();
            OnVantBeDeleted(this);
        }
    }
}
