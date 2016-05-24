using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuestRacoonWpf
{
    public partial class MainWindow : Window
    {
        private bool _isMoving = false;
        private bool _realMoving = false;
        private Point? _previevPosition = null;
        private Point? _startPosition = null;

        private bool _dblClicking;

        private double _movingDist = 3;

        private Quest.Quest _quest;
        private string _questPath = "";

        public MainWindow()
        {
            InitializeComponent();
            _quest = new Quest.Quest();
            UpdateRecent();
        }
        
        private void ScrollViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this._isMoving == true)
                this.CancelScrolling();
            else if (e.ChangedButton == MouseButton.Right && e.ButtonState == MouseButtonState.Pressed)
            {
                if (this._isMoving == false)
                {
                    this._isMoving = true;
                    this._previevPosition = e.GetPosition(sender as IInputElement);
                    this._startPosition = _previevPosition;
                }
            }
            _dblClicking = e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed && e.ClickCount == 2;
            Console.WriteLine("hhh");
        }

        private void ScrollViewer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right && e.ButtonState == MouseButtonState.Released)
            {
                if (!_realMoving)
                {
                    if (e.Source is DragCanvas)
                        scrollViewer.ContextMenu.IsOpen = true;
                    else
                    {
                        var block = e.Source as FlowBlock;
                        if (block != null)
                            block.ContextMenu.IsOpen = true;
                    }
                }
                this.CancelScrolling();
            }
            else if (_dblClicking)
            {
                var block = e.Source as FlowBlock;
                if (block != null)
                    block.EditBlock();
                _dblClicking = false;
            }
        }

        private void CancelScrolling()
        {
            this._isMoving = false;
            this._previevPosition = null;
            this._realMoving = false;
        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._isMoving && Mouse.RightButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(scrollViewer);
                var offset = position - _previevPosition.Value;
                var dist = Math.Sqrt(Math.Pow(_startPosition.Value.X - position.X, 2) + Math.Pow(_startPosition.Value.Y - position.Y, 2));

                if (dist >= _movingDist)
                    _realMoving = true;

                if (_realMoving)
                {
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset.Y);
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - offset.X);
                    this._previevPosition = e.GetPosition(sender as IInputElement);
                }
            }
            else
                CancelScrolling();
        }
        
        FlowBlock _b1;
        FlowBlock _b2;

        private void menuItemNewBlock_Click(object sender, RoutedEventArgs e)
        {
            var qblock = _quest.CreateBlock(_startPosition.Value + new Quest.Point(scrollViewer.HorizontalOffset, scrollViewer.VerticalOffset));
            var block = new FlowBlock(qblock);
            block.SelectedLocale = _quest.MainLocale;
            dragCanvas.AddBlock(block);

            if (_b1 == null)
                _b1 = block;
            else if (_b2 == null)
            {
                _b2 = block;
                arrow.ArrowEnds = ArrowEnds.Both;
                arrow.SetEnds(_b1, _b2);
            }
        }

        #region Menu

        private void menuItem_NewQuestClick(object sender, RoutedEventArgs e)
        {
            if (CheckSaved(_quest))
            {
                _quest = new Quest.Quest();
                LinkQuest(_quest);
                _questPath = "";
            }
        }

        private void menuItem_OpenQuestClick(object sender, RoutedEventArgs e)
        {
            if (CheckSaved(_quest))
            {
                Microsoft.Win32.OpenFileDialog openQuestDialog = new Microsoft.Win32.OpenFileDialog();
                openQuestDialog.Filter = "Racoon quest files|*.qrc|All files|*.*";
                openQuestDialog.InitialDirectory = QR.Set.LastOpenedFile;
                openQuestDialog.FileName = "";
                var saveResult = openQuestDialog.ShowDialog(this);
                if (saveResult != null && saveResult.Value)
                {
                    OpenQuest(openQuestDialog.FileName);
                }
            }
        }

        private void menuItem_OpenRecentClick(object sender, RoutedEventArgs e)
        {
            if (CheckSaved(_quest))
                OpenQuest((sender as MenuItem).Header as string);
        }

        private void menuItem_SaveQuestClick(object sender, RoutedEventArgs e)
        {
            if (SaveQuest())
                _quest.DropEdited();
        }

        private void menuItem_SaveAsClick(object sender, RoutedEventArgs e)
        {
            if (SaveQuestAs())
                _quest.DropEdited();
        }

        private void menuItem_ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menuItem_UndoClick(object sender, RoutedEventArgs e)
        {

        }

        private void menuItem_RedoClick(object sender, RoutedEventArgs e)
        {

        }

        private void menuItem_PlayClick(object sender, RoutedEventArgs e)
        {

        }

        private void menuItem_LocalesClick(object sender, RoutedEventArgs e)
        {

        }

        private void menuItem_AboutClick(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        private void UpdateRecent(string filename = "")
        {
            if (filename != "")
                QR.Set.AddRecentFile(filename);
            openRecentMenuItem.Items.Clear();
            foreach (var file in QR.Set.RecentFiles)
            {
                var item = new MenuItem();
                item.Header = file;
                item.Click += menuItem_OpenRecentClick;
                openRecentMenuItem.Items.Add(item);
            }
        }
        
        private void OpenQuest(string filename)
        {
            //try
            //{
                _quest = new Quest.Quest(PNetJson.JSONValue.Load(filename));
                LinkQuest(_quest);
                _questPath = filename;
                UpdateRecent(filename);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message);
            //}
        }

        private bool CheckSaved(Quest.Quest quest)
        {
            if (!quest.Edited)
                return true;
            var action = MessageBox.Show(this, "Quest not saved. Do you want to save changes?", "Quest not saved", MessageBoxButton.YesNoCancel);
            switch (action)
            {
                case MessageBoxResult.Yes: return SaveQuest();
                case MessageBoxResult.No: return true;
                default: return false;
            }
        }

        private bool SaveQuest()
        {
            try
            {
                if (_questPath != "")
                {
                    _quest.ToJson().Save(_questPath, false);
                    return true;
                }
                else
                    return SaveQuestAs();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message);
                return false;
            }
        }

        private bool SaveQuestAs()
        {
            Microsoft.Win32.SaveFileDialog saveQuestDialog = new Microsoft.Win32.SaveFileDialog();
            saveQuestDialog.Filter = "Racoon quest files|*.qrc|All files|*.*";
            saveQuestDialog.InitialDirectory = QR.Set.LastOpenedFile;
            saveQuestDialog.FileName = "";
            var saveResult = saveQuestDialog.ShowDialog(this);
            if (saveResult != null && saveResult.Value)
                try
                {
                    var filename = saveQuestDialog.FileName;
                    _questPath = System.IO.Path.ChangeExtension(filename, "qrc");
                    _quest.ToJson().Save(_questPath, false);
                    UpdateRecent(_questPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                    return false;
                }
            else return false;
        }

        private void LinkQuest(Quest.Quest quest)
        {
            dragCanvas.Children.Clear();

            quest.BlockAdded += questBlockAdded;
            quest.MainLocaleChanged += questMainLocaleChanged;

            foreach (var qBlock in quest.Blocks)
                PlaceBlock(qBlock);
            CheckLinks();
        }

        private void questMainLocaleChanged()
        {
            foreach (var block in dragCanvas.GetBlocks())
            {
                block.SelectedLocale = _quest.MainLocale;
            }
        }
        private void questBlockAdded(Quest.Block block)
        {
            questBlockAdded(block, true);
        }

        private void questBlockAdded(Quest.Block block, bool checkLinks)
        {
            PlaceBlock(block);
            if (checkLinks)
                CheckLinks();
        }

        private void CheckLinks()
        {
            foreach (var b in dragCanvas.GetBlocks())
                b.CheckLinks();
        }

        private void PlaceBlock(Quest.Block qBlock)
        {
            var block = new FlowBlock(qBlock);
            block.SelectedLocale = _quest.MainLocale;
            dragCanvas.AddBlock(block);
        }

    }
}
