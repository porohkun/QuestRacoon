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
        private Quest.Quest _quest;
        private string _selectedLocale;

        private List<Arrow> _links = new List<Arrow>();
        private List<string> _brokenLinks = new List<string>();

        public double Top { get { return _block.Location.Y; } }
        public double Left { get { return _block.Location.X; } }

        public string SelectedLocale
        {
            get { return _selectedLocale; }
            set
            {
                _selectedLocale = value;
                _block_OperatorsChanged();
            }
        }

        public string Header { get { return _block.Name; } }

        public event Action<FlowBlock> Moving;
        public event Action WantBeDeleted;

        internal void Move()
        {
            if (Moving != null)
                Moving(this);
        }

        public FlowBlock()
        {
            InitializeComponent();
        }

        public FlowBlock(Block block, Quest.Quest quest):this()
        {
            _block = block;
            _quest = quest;
            _block.NameChanged += _block_NameChanged;
            _block.OperatorsChanged += _block_OperatorsChanged;
            _block.Deleted += _block_Deleted;
            headerText.Content = _block.Name;
        }

        public void SetPosition(double left,double top)
        {
            _block.SetLocation(new Quest.Point(left, top));
        }

        private void _block_Deleted()
        {
            var workspace = Parent as DragCanvas;
            WantBeDeleted?.Invoke();
            workspace.Children.Remove(this);
        }

        private void _block_OperatorsChanged()
        {
            captionText.Content = _block.GetRawText(SelectedLocale);
            CheckLinks();
        }

        private void _block_NameChanged()
        {
            headerText.Content = _block.Name;
            foreach (var block in (Parent as DragCanvas).GetBlocks())
            {
                block.CheckLinks();
            }
        }

        private void menuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            EditBlock();
        }

        private void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            _block.DeleteBlock();
        }

        private void flowBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                EditBlock();
        }

        public void EditBlock()
        {
            var editWindow = new BlockEditWindow(_block, _quest, _selectedLocale);
            editWindow.ShowDialog();
        }
        
        public void CheckLinks()
        {
            var links = new List<string>(from op in _block where op is Link select (op as Link).To);
            var forDel = new List<Arrow>();
            _brokenLinks.Clear();
            var workspace = Parent as DragCanvas;
            if (workspace == null) return;

            foreach (var link in _links)
                if (!links.Contains(link.EndName))
                    forDel.Add(link);

            foreach (var link in links)
            {
                if (!(from l in _links select l.EndName).Contains(link))
                {
                    var endlink = workspace.GetBlock(link);
                    if (endlink == null)
                    {
                        _brokenLinks.Add(link);
                    }
                    else
                    {
                        var arrow = new Arrow();
                        workspace.Children.Add(arrow);
                        Canvas.SetZIndex(arrow, -1);
                        arrow.SetEnds(this, endlink);
                        _links.Add(arrow);
                        if (_brokenLinks.Contains(link))
                            _brokenLinks.Remove(link);
                    }
                }
            }

            foreach (var link in forDel)
            {
                _links.Remove(link);
                link.Delete();
            }
        }

    }
}
