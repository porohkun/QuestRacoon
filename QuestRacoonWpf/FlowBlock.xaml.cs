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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf
{
    /// <summary>
    /// Interaction logic for FlowBlock.xaml
    /// </summary>
    public partial class FlowBlock : UserControl
    {
        private Block _block;

        public FlowBlock()
        {
            InitializeComponent();
        }

        public FlowBlock(Block block):base()
        {
            _block = block;
            _block.NameChanged += _block_NameChanged;
            _block.TextChanged += _block_TextChanged;
        }

        private void _block_TextChanged(string text)
        {
            captionText.Content = text;
        }

        private void _block_NameChanged()
        {
            headerText.Content = _block.Name;
        }

        private void menuItemEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
