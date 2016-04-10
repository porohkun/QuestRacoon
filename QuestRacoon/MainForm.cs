using System;
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
        public MainForm()
        {
            InitializeComponent();
        }

        private Block _block;

        private void newBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Block block = new Block(workspace, _clickPos);
            if (_block != null)
            {
                var arrow = new Arrow();
                workspace.Controls.Add(arrow);
                arrow.DrawArrow(_block, block);
            }
            _block = block;
        }

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //var arrow = new Arrow();
            //workspace.Controls.Add(arrow);
            //arrow.DrawArrow(new Point(200, 200), new Point(400, 400));

            Vector2 forward = new Vector2(1f, 0f);
            Vector2 left = forward.Rotate(-90f);

            Vector2 v = new Vector2(1f, 1f);
            var len = v.Length;
            v.Norm = 1f;
            var len2 = v.Length;
        }
    }
}
