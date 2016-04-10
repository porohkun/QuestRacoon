using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestRacoon
{
    public partial class Block : UserControl
    {
        private Point _startClickLocation;

        public event EventHandler MoveEnd;

        public Block() : base() { InitializeComponent(); }

        public Block(WorkspaceControl workspace, Point location) : this()
        {
            //Width = 200;
            //Height = 200;
            Location = location;
            //BackColor = Color.Wheat;
            //this.bord
            workspace.Controls.Add(this);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                _startClickLocation = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                Location = Location.Append(new Point(e.X - _startClickLocation.X, e.Y - _startClickLocation.Y));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
                OnMoveEnd(new EventArgs());
        }

        protected virtual void OnMoveEnd(EventArgs e)
        {
            EventHandler handler;

            handler = this.MoveEnd;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
    }
}
