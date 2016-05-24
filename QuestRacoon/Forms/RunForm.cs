using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PNetJson;

namespace QuestRacoonWpf
{
    public partial class RunForm : Form
    {
        Graphics _g;
        Quest.Quest _quest;

        public RunForm()
        {
            InitializeComponent();
            _g = Graphics.FromHwnd(this.Handle);
        }

        public RunForm(JSONValue json) : this()
        {
            _quest = new Quest.Quest(json);
        }

        private void RunForm_Shown(object sender, EventArgs e)
        {
            GoToBlock("Start");
        }

        private void GoToBlock(string blockName)
        {
            var block = GetBlock(blockName);
            if (block == null)
            {
                MessageBox.Show(string.Format("нет блока с именем \"{0}\"", blockName));
                return;
            }

            show.Controls.Clear();

            var links = block.GetRawLinks(_quest.MainLocale);
            var text = block.GetRawText(_quest.MainLocale);
            int start = 0;
            foreach (var link in links)
            {
                CreateLabel(text, start, link.Index);
                start = link.Index + link.Length;
                var ll = link.Value.Substring(2, link.Length - 4).Split('|');
                CreateButton(ll[0], ll[1]);
            }
            RunForm_SizeChanged(null, null);
        }

        private void CreateButton(string block, string text)
        {
            var button = new Button() { Font = Font, Text = text, AutoSize = false, Tag = block };
            show.Controls.Add(button);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button.Left = 0;
            button.Click += (sender, e) => { GoToBlock(((Button)sender).Tag.ToString()); };
        }

        private void CreateLabel(string text, int start, int end)
        {
            var showText = text.Substring(start, end - start);
            if (showText.Length >= 2 && showText[showText.Length - 2] == '\r' && showText[showText.Length - 1] == '\n')
                showText = showText.Substring(0, showText.Length - 2);
            var label = new Label() { Font = Font, Text = showText, AutoSize = false };
            show.Controls.Add(label);
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label.Left = 0;
        }

        private int GetHeight(string text)
        {
            SizeF f = _g.MeasureString(text, Font, Width);
            return (int)(f.Height);
        }

        private Quest.Block GetBlock(string name)
        {
            foreach (var block in _quest.Blocks)
            {
                if (block.Name == name)
                {
                    return block;
                }
            }
            return null;
        }

        private void RunForm_SizeChanged(object sender, EventArgs e)
        {
            Control last = null;
            foreach (Control control in show.Controls)
            {
                control.Top = last == null ? show.AutoScrollPosition.Y : last.Bottom + 4;
                control.Width = show.Width - 16;
                control.Height = GetHeight(control.Text) + (control is Button ? 12 : 0);
                last = control;
            }
            show.AdjustVirtualSize();
        }
    }
}