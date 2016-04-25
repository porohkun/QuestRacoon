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
    public partial class BlockEditForm : Form
    {
        private static bool _first = true;
        private static Point _startLocation;
        private static Size _startSize;

        private Quest.Block _block;
        private Dictionary<string, string> _texts = new Dictionary<string, string>();
        private string _locale;
        private List<ToolStripButton> _localeButtons = new List<ToolStripButton>();

        public BlockEditForm()
        {
            InitializeComponent();
        }

        public BlockEditForm(Quest.Block block, string locale) : this()
        {
            this._block = block;
            Text = _block.Name;
            headerBox.Text = _block.Name;

            foreach (var loc in _block.Locales)
            {
                _texts.Add(loc, _block.GetRawText(loc));

                var locloc = loc;
                var tsButton = (toolStrip.Items.Add(loc, null, (sender, e) => { SwitchLocale(locloc); }) as ToolStripButton);
                _localeButtons.Add(tsButton);
                tsButton.CheckOnClick = true;
                if (loc == locale)
                    tsButton.Checked = true;
            }
            SwitchLocale(locale);

        }

        private void SwitchLocale(string locale)
        {
            if (_locale!=null && _texts.ContainsKey(_locale))
                _texts[_locale] = textBox.Text;
            _locale = locale;
            textBox.Text = _texts[_locale];

            foreach (var btn in _localeButtons)
                btn.Checked = btn.Text == locale;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!_first)
            {
                Location = _startLocation;
                Size = _startSize;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _texts[_locale] = textBox.Text;
            foreach (var loc in _texts.Keys)
                _block.SetRawText(loc, _texts[loc]);

            _block.SetName(headerBox.Text);
            //switch (_block.SetText(textBox.Text))
            //{
            //    case BlockSetTextResult.HeaderAbsent:
            //        MessageBox.Show(this, "Please set header tag", "", MessageBoxButtons.OK);
            //        e.Cancel = true;
            //        break;
            //    case BlockSetTextResult.NewLinks:
            //        var result =MessageBox.Show(this, "Do you want to create new blocks to match broken links?", "", MessageBoxButtons.YesNoCancel);
            //        switch (result)
            //        {
            //            case DialogResult.Yes: _block.FixBrokenLinks(); break;
            //            case DialogResult.Cancel: e.Cancel = true; break;
            //        }
            //        break;
            //}

            base.OnFormClosing(e);
            _first = false;
            _startLocation = Location;
            _startSize = Size;
        }
    }
}
