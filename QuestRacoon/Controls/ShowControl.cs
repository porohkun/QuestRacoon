using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cyotek.Windows.Forms;

namespace QuestRacoonWpf
{
    [ToolboxItem(true)]
    public class ShowControl : VirtualScrollableControl
    {
        #region Instance Fields

        private bool _autoPan;
        private bool _invertMouse;
        private bool _isPanning;
        private Point _startMousePosition;
        private Point _startScrollPosition;
        private Size _viewSize;

        #endregion

        #region Public Constructors


        public ShowControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.StandardDoubleClick, false);

            this.WheelScrollsControl = false;
            this.AutoPan = true;
        }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when the AutoPan property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler AutoPanChanged;

        /// <summary>
        ///   Occurs when the InvertMouse property is changed.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler InvertMouseChanged;

        /// <summary>
        ///   Occurs when panning the control completes.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanEnd;

        /// <summary>
        ///   Occurs when panning the control starts.
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler PanStart;

        /// <summary>
        ///   Occurs when the VirtualSize property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ViewSizeChanged;

        #endregion

        #region Overridden Properties

        /// <summary>
        ///   Specifies if the control should auto size to fit the image contents.
        /// </summary>
        /// <value></value>
        /// <returns>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>
        /// </returns>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                if (base.AutoSize != value)
                {
                    base.AutoSize = value;
                    this.AdjustLayout();
                }
            }
        }

        #endregion

        #region Overridden Methods

        /// <summary>
        ///   Determines whether the specified key is a regular input key or a special key that requires preprocessing.
        /// </summary>
        /// <param name="keyData">
        ///   One of the <see cref="T:System.Windows.Forms.Keys" /> values.
        /// </param>
        /// <returns>
        ///   true if the specified key is a regular input key; otherwise, false.
        /// </returns>
        protected override bool IsInputKey(Keys keyData)
        {
            bool result;

            if ((keyData & Keys.Right) == Keys.Right | (keyData & Keys.Left) == Keys.Left | (keyData & Keys.Up) == Keys.Up | (keyData & Keys.Down) == Keys.Down)
            {
                result = true;
            }
            else
            {
                result = base.IsInputKey(keyData);
            }

            return result;
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            this.Invalidate();
        }

        /// <summary>
        ///   Raises the <see cref="ScrollControl.BorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected override void OnBorderStyleChanged(EventArgs e)
        {
            base.OnBorderStyleChanged(e);

            this.AdjustLayout();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            this.AdjustVirtualSize();
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            this.AdjustVirtualSize();
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.DockChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            if (this.Dock != DockStyle.None)
            {
                this.AutoSize = false;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.FontChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ForeColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            this.Invalidate();
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            this.ProcessScrollingShortcuts(e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Right)
            {
                this.ProcessPanning(e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool doNotProcessClick;

            base.OnMouseUp(e);

            doNotProcessClick = this.IsPanning;

            if (this.IsPanning)
            {
                this.IsPanning = false;
            }

            this.WasDragCancelled = false;
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.MouseWheel" /> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            //TODO: scropp up/down
            //if (this.AllowZoom && this.SizeMode == ImageBoxSizeMode.Normal)
            //{
            //    int spins;

            //    // The MouseWheel event can contain multiple "spins" of the wheel so we need to adjust accordingly
            //    spins = Math.Abs(e.Delta / SystemInformation.MouseWheelScrollDelta);

            //    // TODO: Really should update the source method to handle multiple increments rather than calling it multiple times
            //    for (int i = 0; i < spins; i++)
            //    {
            //        this.ProcessMouseZoom(e.Delta > 0, e.Location);
            //    }
            //}
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.PaddingChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            this.AdjustLayout();
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">
        ///   An <see cref="T:System.EventArgs" /> that contains the event data.
        /// </param>
        protected override void OnResize(EventArgs e)
        {
            this.AdjustLayout();

            base.OnResize(e);
        }

        /// <summary>
        ///   Raises the <see cref="System.Windows.Forms.ScrollableControl.Scroll" /> event.
        /// </summary>
        /// <param name="se">
        ///   A <see cref="T:System.Windows.Forms.ScrollEventArgs" /> that contains the event data.
        /// </param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            this.Invalidate();

            base.OnScroll(se);
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets if the mouse can be used to pan the control.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control can be auto panned; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>If this property is set, the SizeToFit property cannot be used.</remarks>
        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool AutoPan
        {
            get { return _autoPan; }
            set
            {
                if (_autoPan != value)
                {
                    _autoPan = value;
                    this.OnAutoPanChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the mouse should be inverted when panning the control.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the mouse should be inverted when panning the control; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [Category("Behavior")]
        public virtual bool InvertMouse
        {
            get { return _invertMouse; }
            set
            {
                if (_invertMouse != value)
                {
                    _invertMouse = value;
                    this.OnInvertMouseChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        ///   Gets a value indicating whether this control is panning.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this control is panning; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public virtual bool IsPanning
        {
            get { return _isPanning; }
            protected set
            {
                if (_isPanning != value)
                {
                    CancelEventArgs args;

                    args = new CancelEventArgs();

                    if (value)
                    {
                        this.OnPanStart(args);
                    }
                    else
                    {
                        this.OnPanEnd(EventArgs.Empty);
                    }

                    if (!args.Cancel)
                    {
                        _isPanning = value;

                        if (value)
                        {
                            _startScrollPosition = this.AutoScrollPosition;
                            this.Cursor = Cursors.SizeAll;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Gets or sets the size of the virtual image.
        /// </summary>
        /// <value>The size of the virtual image.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Size), "0, 0")]
        public virtual Size ViewSize
        {
            get { return _viewSize; }
            set
            {
                if (this.ViewSize != value)
                {
                    _viewSize = value;

                    this.OnViewSizeChanged(EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Protected Properties

        ///// <summary>
        ///// Gets the size of the view.
        ///// </summary>
        ///// <value>The size of the view.</value>
        //protected virtual Size ViewSize
        //{//TODO:replace viewsize to virtualsize
        //    get { return this.ViewSize; }
        //}

        /// <summary>
        /// Gets or sets a value indicating whether a drag operation was cancelled.
        /// </summary>
        /// <value><c>true</c> if the drag operation was cancelled; otherwise, <c>false</c>.</value>
        protected bool WasDragCancelled { get; set; }

        #endregion

        #region Public Members
        
        #endregion

        #region Protected Members

        /// <summary>
        ///   Adjusts the layout.
        /// </summary>
        protected virtual void AdjustLayout()
        {
            if (this.AutoSize)
            {
                this.AdjustSize();
            }
            else if (this.AutoScroll)
            {
                this.AdjustViewPort();
            }

            this.Invalidate();
        }

        /// <summary>
        ///   Adjusts the scroll.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected virtual void AdjustScroll(int x, int y)
        {
            Point scrollPosition;

            scrollPosition = new Point(this.HorizontalScroll.Value + x, this.VerticalScroll.Value + y);

            this.UpdateScrollPosition(scrollPosition);
        }

        /// <summary>
        ///   Adjusts the size.
        /// </summary>
        protected virtual void AdjustSize()
        {
            if (this.AutoSize && this.Dock == DockStyle.None)
            {
                base.Size = base.PreferredSize;
            }
        }

        /// <summary>
        ///   Adjusts the view port.
        /// </summary>
        protected virtual void AdjustViewPort()
        {
            if (!this.ViewSize.IsEmpty)
            {
                if (this.AutoScroll)
                {
                    this.AutoScrollMinSize = new Size(this.ViewSize.Width + this.Padding.Horizontal, this.ViewSize.Height + this.Padding.Vertical);
                }
            }
        }

        public virtual void AdjustVirtualSize()
        {
            int width = 0;
            int height = 0;
            if (Controls.Count == 0)
            {
                width = Width;
                height = Height;
            }
            foreach (Control c in Controls)
            {
                width = Math.Max(width, c.Location.X + c.Width);
                height = Math.Max(height, c.Location.Y + c.Height);
            }
            width -= AutoScrollPosition.X - 10;
            height -= AutoScrollPosition.Y - 10;
            var oldAutoScroll = AutoScrollPosition;
            ViewSize = new Size(width, height);
            int scrollToX = width > Size.Width ? -oldAutoScroll.X : 0;
            int scrollToY = height > Size.Height ? -oldAutoScroll.Y : 0;
            ScrollTo(scrollToX, scrollToY);
        }

        /// <summary>
        ///   Raises the <see cref="AutoPanChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnAutoPanChanged(EventArgs e)
        {
            EventHandler handler;

            handler = this.AutoPanChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="InvertMouseChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnInvertMouseChanged(EventArgs e)
        {
            EventHandler handler;

            handler = this.InvertMouseChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="PanEnd" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanEnd(EventArgs e)
        {
            EventHandler handler;

            handler = this.PanEnd;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="PanStart" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnPanStart(CancelEventArgs e)
        {
            EventHandler handler;

            handler = this.PanStart;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        ///   Raises the <see cref="ViewSizeChanged" /> event.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void OnViewSizeChanged(EventArgs e)
        {
            EventHandler handler;

            this.AdjustLayout();

            handler = this.ViewSizeChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        ///   Performs mouse based panning
        /// </summary>
        /// <param name="e">
        ///   The <see cref="MouseEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessPanning(MouseEventArgs e)
        {
            if (this.AutoPan && !this.ViewSize.IsEmpty)
            {
                if (!this.IsPanning && (this.HScroll | this.VScroll))
                {
                    _startMousePosition = e.Location;
                    this.IsPanning = true;
                }

                if (this.IsPanning)
                {
                    int x;
                    int y;
                    Point position;

                    if (!this.InvertMouse)
                    {
                        x = -_startScrollPosition.X + (_startMousePosition.X - e.Location.X);
                        y = -_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y);
                    }
                    else
                    {
                        x = -(_startScrollPosition.X + (_startMousePosition.X - e.Location.X));
                        y = -(_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y));
                    }

                    position = new Point(x, y);

                    this.UpdateScrollPosition(position);
                }
            }
        }

        /// <summary>
        ///   Processes shortcut keys for scrolling
        /// </summary>
        /// <param name="e">
        ///   The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        protected virtual void ProcessScrollingShortcuts(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.AdjustScroll(-(e.Modifiers == Keys.None ? this.HorizontalScroll.SmallChange : this.HorizontalScroll.LargeChange), 0);
                    break;

                case Keys.Right:
                    this.AdjustScroll(e.Modifiers == Keys.None ? this.HorizontalScroll.SmallChange : this.HorizontalScroll.LargeChange, 0);
                    break;

                case Keys.Up:
                    this.AdjustScroll(0, -(e.Modifiers == Keys.None ? this.VerticalScroll.SmallChange : this.VerticalScroll.LargeChange));
                    break;

                case Keys.Down:
                    this.AdjustScroll(0, e.Modifiers == Keys.None ? this.VerticalScroll.SmallChange : this.VerticalScroll.LargeChange);
                    break;
            }
        }

        /// <summary>
        ///   Updates the scroll position.
        /// </summary>
        /// <param name="position">The position.</param>
        protected virtual void UpdateScrollPosition(Point position)
        {
            this.AutoScrollPosition = position;
            this.Invalidate();
            this.OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, 0));
        }

        #endregion

        #region Private Members

        #endregion
    }
}
