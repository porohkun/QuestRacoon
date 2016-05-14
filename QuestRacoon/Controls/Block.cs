using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuestRacoon
{
    public partial class Block : UserControl
    {
        private Point _startClickLocation;
        private string _selectedLocale;
        private Quest.Block _block;
        private List<Arrow> _links = new List<Arrow>();
        private List<string> _brokenLinks = new List<string>();

        public event EventHandler MoveEnd;

        public string Header
        {
            get { return _block.Name; }
        }

        public string SelectedLocale
        {
            get { return _selectedLocale; }
            set
            {
                if (_block.Locales.Contains(value))
                {
                    _selectedLocale = value;
                    bodyLabel.Text = _block.GetRawText(_selectedLocale);
                    CheckLinks();
                }
            }
        }

        private WorkspaceControl _workspace;

        public Block() : base()
        {
            InitializeComponent();
        }

        public Block(Quest.Block block, string locale) : this()
        {
            _block = block;
            Location = block.Location;
            _block.NameChanged += blockNameChanged;
            _block.TextChanged += blockTextChanged;
            headerLabel.Text = _block.Name;
            SelectedLocale = locale;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            _workspace = Parent as WorkspaceControl;
            Location = new Point(_block.Location.X - _workspace.HorizontalScroll.Value, _block.Location.Y - _workspace.HorizontalScroll.Value);
        }

        private void blockNameChanged()
        {
            headerLabel.Text = _block.Name;
            foreach (var block in (Parent as WorkspaceControl).GetBlocks())
            {
                block.CheckLinks();
            }
        }

        private void blockTextChanged(string locale)
        {
            if (locale == SelectedLocale)
            {
                bodyLabel.Text = _block.GetRawText(SelectedLocale);
                CheckLinks();
            }
        }

        public void CheckLinks()
        {
            var links = new List<string>(_block.GetLinks(SelectedLocale));
            var forDel = new List<Arrow>();
            var workspace = Parent as WorkspaceControl;
            if (workspace == null) return;

            foreach (var link in _links)
                if (!links.Contains( link.EndBlock._block.Name))
                    forDel.Add(link);
            
            foreach (var link in links)
            {
                if (!(from l in _links select l.EndBlock._block.Name).Contains(link))
                {
                    var endlink = workspace.GetBlock(link);
                    if (endlink == null)
                    {
                        _brokenLinks.Add(link);
                    }
                    else
                    {
                        var arrow = new Arrow(workspace, this, endlink);
                        _links.Add(arrow);
                        if (_brokenLinks.Contains(link))
                            _brokenLinks.Remove(link);
                    }
                }
            }

            foreach (var link in forDel)
            {
                _links.Remove(link);
                workspace.Controls.Remove(link);
                link.Dispose();
            }
        }

        #region moving

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
            _block.SetLocation(new Point(Location.X + _workspace.HorizontalScroll.Value, Location.Y + _workspace.VerticalScroll.Value));
            MoveEnd?.Invoke(this, e);
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

        #endregion

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            var editForm = new BlockEditForm(_block, _selectedLocale);
            editForm.ShowDialog(this.ParentForm);
        }

        private void headerLabel_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
    }
}
