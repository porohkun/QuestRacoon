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
using System.Windows.Shapes;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for LocalesWindow.xaml
    /// </summary>
    public partial class LocalesWindow : Window
    {
        private Quest.Quest _quest;

        public LocalesWindow()
        {
            InitializeComponent();
        }

        public LocalesWindow(Quest.Quest _quest) : this()
        {
            this._quest = _quest;
            foreach (var loc in _quest.Locales.OrderBy(l => l))
                localesList.Items.Add(loc);
        }

        private void AddLocaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelLocaleButton_Click(object sender, RoutedEventArgs e)
        {
            var locale = localesList.SelectedItem;
            localesList.Items.Remove(locale);
            _quest.DeleteLocale((string)locale);
        }

        private void RenameLocaleButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
