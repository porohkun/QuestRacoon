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

namespace QuestRacoon
{
    /// <summary>
    /// Interaction logic for AddLocaleWindow.xaml
    /// </summary>
    public partial class AddLocaleWindow : Window
    {
        public string Locale { get; internal set; }

        public AddLocaleWindow()
        {
            InitializeComponent();
        }

        public AddLocaleWindow(string locale):this()
        {
            Locale = locale;
            localeBox.Text = locale;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult == null)
                DialogResult = false;
        }

        private void localeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Locale = localeBox.Text;
        }
    }
}
