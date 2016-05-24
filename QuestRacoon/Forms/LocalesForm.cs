using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestRacoonWpf
{
    public partial class LocalesForm : Form
    {
        private Quest.Quest _quest;
        
        public LocalesForm()
        {
            InitializeComponent();
        }

        public LocalesForm(Quest.Quest quest) : this()
        {
            _quest = quest;
            foreach (var loc in quest.Locales)
                localesBox.AppendText(loc + "\r\n");
        }

        private void LocalesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string mainLocale = localesBox.Lines[0].Trim();
            List<string> forAdd = new List<string>();
            List<string> forDel = new List<string>();
            var locales = (from loc in localesBox.Lines where loc.Trim() != "" select loc.Trim()).Distinct();
            foreach (var loc in locales)
                if (!_quest.Locales.Contains(loc))
                    forAdd.Add(loc);
            foreach (var loc in _quest.Locales)
                if (!locales.Contains(loc))
                    forDel.Add(loc);
            foreach (var loc in forAdd)
                _quest.AddLocale(loc);
            foreach (var loc in forDel)
                _quest.DeleteLocale(loc);
            _quest.SetMainLocale(mainLocale);
        }
    }
}
