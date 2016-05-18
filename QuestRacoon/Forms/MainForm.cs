using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestRacoon
{
    public partial class MainForm : Form
    {
        private Quest.Quest _quest;
        private string _questPath = "";

        public MainForm()
        {
            InitializeComponent();
            Text = string.Format("{0} v.{1}", Text, Application.ProductVersion);
            UpdateRecent();
            _quest = new Quest.Quest();
            LinkQuest(_quest, workspace);
        }

        #region moving blocks

        Point _clickPos;
        bool _rightDown = false;
        bool _scrolling = false;

        private void workspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _clickPos = e.Location;
                _rightDown = true;
                _scrolling = false;
            }
        }

        private void workspace_MouseMove(object sender, MouseEventArgs e)
        {
            if (_rightDown)
            {
                _scrolling = true;
            }
        }

        private void workspace_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_scrolling && e.Button == MouseButtons.Right)
            {
                _clickPos = e.Location;
                _rightDown = false;
                _scrolling = false;
                workspaceContextMenu.Show(workspace, e.Location);
            }
        }

        #endregion

        #region main menu

        private void newQuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSaved(_quest))
            {
                _quest = new Quest.Quest();
                LinkQuest(_quest, workspace);
                _questPath = "";
            }
        }

        private void openQuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSaved(_quest))
            {
                openQuestDialog.InitialDirectory = QR.Set.LastOpenedFile;
                openQuestDialog.FileName = "";
                if (openQuestDialog.ShowDialog(this) == DialogResult.OK)
                {
                    OpenQuest(openQuestDialog.FileName);
                }
            }
        }

        private bool CheckSaved(Quest.Quest quest)
        {
            if (!quest.Edited)
                return true;
            var action = MessageBox.Show(this, "Quest not saved. Do you want to save changes?", "Quest not saved", MessageBoxButtons.YesNoCancel);
            switch (action)
            {
                case DialogResult.Yes: return SaveQuest();
                case DialogResult.No: return true;
                default: return false;
            }
        }

        private void openRecentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckSaved(_quest))
                OpenQuest(((ToolStripMenuItem)sender).Text);
        }

        private void OpenQuest(string filename)
        {
            try
            {
                _quest = new Quest.Quest(PNetJson.JSONValue.Load(filename));
                LinkQuest(_quest, workspace);
                _questPath = filename;
                UpdateRecent(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void UpdateRecent(string filename = "")
        {
            if (filename != "")
                QR.Set.AddRecentFile(filename);
            openRecentToolStripMenuItem.DropDownItems.Clear();
            foreach (var file in QR.Set.RecentFiles)
                openRecentToolStripMenuItem.DropDownItems.Add(file, null, openRecentToolStripMenuItem_Click);
        }

        private void saveQuestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuest();
        }

        private void saveQuestAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuestAs();
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
            catch(Exception e)
            {
                MessageBox.Show(this, e.Message);
                return false;
            }
        }

        private bool SaveQuestAs()
        {
            saveQuestDialog.InitialDirectory = QR.Set.LastOpenedFile;
            saveQuestDialog.FileName = "";
            if (saveQuestDialog.ShowDialog(this) == DialogResult.OK)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void localesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lf = new LocalesForm(_quest);
            lf.Show(this);
        }

        #endregion

        private void newBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _quest.CreateBlock(_clickPos);
        }

        private void LinkQuest(Quest.Quest quest, WorkspaceControl workspace)
        {
            workspace.Controls.Clear();

            quest.BlockAdded += questBlockAdded;
            quest.MainLocaleChanged += questMainLocaleChanged;

            foreach (var qBlock in quest.Blocks)
                PlaceBlock(qBlock);
            CheckLinks();
        }

        private void questMainLocaleChanged()
        {
            foreach (var block in workspace.GetBlocks())
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
            if(checkLinks)
                CheckLinks();
        }

        private void CheckLinks()
        {
            foreach (var b in workspace.GetBlocks())
                b.CheckLinks();
        }

        private void PlaceBlock(Quest.Block qBlock)
        {
            Block block = new Block(qBlock, _quest.MainLocale);
            workspace.Controls.Add(block);
        }

        private void updArrowsToolStripButton_Click(object sender, EventArgs e)
        {
            QR.UpdateArrows = updArrowsToolStripButton.Checked;
        }

        private void playToolStripButton_Click(object sender, EventArgs e)
        {
            var run = new RunForm(_quest.ToJson());
            run.Show();
        }
    }
}
