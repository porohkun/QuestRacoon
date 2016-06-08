using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuestRacoon.Quest;

namespace QuestRacoon
{
    /// <summary>
    /// Interaction logic for PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        private Play.IQuestContext _context;
        public IDictionary<string, string> Variables { get; set; }
        public string SelectedLocale { get { return localesBox.SelectedValue.ToString(); } }

        public PlayWindow()
        {
            InitializeComponent();
        }

        public PlayWindow(Quest.Quest quest):this()
        {
            _context = new Play.QuestContext(quest);
            _context.RegisterCallback(OperatorType.Description, DescriptionCallback);
            _context.RegisterCallback(OperatorType.Speech, SpeechCallback);
            _context.RegisterCallback(OperatorType.Link, LinkCallback);
            
            variablesPanel.ItemsSource = (_context as Play.QuestContext).Variables;
            localesBox.ItemsSource = quest.Locales;
            localesBox.SelectedIndex = 0;
            
            
            GoToBlock("Start");
        }

        private void GoToBlock(string blockName)
        {
            var block = _context.GetBlock(blockName);
            if (block == null)
            {
                MessageBox.Show(string.Format("нет блока с именем \"{0}\"", blockName));
                return;
            }

            blockNameBox.Text = blockName;

            actionsPanel.Children.Clear();

            var tree = Play.AST_List.Parse(block.GetEnumerator());

            tree.Interpret(_context);
        }

        private void DescriptionCallback(IOperator oper)
        {
            var description = oper as Description;
            actionsPanel.Children.Add(new TextBlock()
            {
                Text = description.Text.GetText(SelectedLocale),
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Calibri"),
                FontSize = 18.667
            });
        }

        private void SpeechCallback(IOperator oper)
        {
            var speech = oper as Speech;
            actionsPanel.Children.Add(new TextBlock()
            {
                Text = string.Format("{0}: {1}", speech.Character, speech.Text.GetText(SelectedLocale)),
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Calibri"),
                FontSize = 18.667
            });
        }

        private void LinkCallback(IOperator oper)
        {
            var link = oper as Link;
            var btn = new Button()
            {
                Content = link.Text,
                FontFamily = new FontFamily("Calibri"),
                FontSize = 18.667
            };
            btn.Click += (object sender, RoutedEventArgs e) => { GoToBlock(link.To); };
            actionsPanel.Children.Add(btn);
        }

    }
}
