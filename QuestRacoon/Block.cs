using System;
using System.Drawing;
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
            Location = location;
            workspace.Controls.Add(this);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                _startClickLocation = e.Location;
        }
        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
                Location = Location.Append(new Point(e.X - _startClickLocation.X, e.Y - _startClickLocation.Y));
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
            handler?.Invoke(this, e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            headerLabel.Text = string.Format("{0}:{1}", Location.X, Location.Y);
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
