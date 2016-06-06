using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace QuestRacoonWpf
{
    public class BaseOperatorControl: UserControl
    {
        private string _locale = "Default";
        public string Locale { get { return _locale; } set { _locale = value; UpdateText(); } }
        public event Action<BaseOperatorControl> WantBeDeleted;

        public virtual bool OpenIndent { get { return false; } }
        public virtual bool CloseIndent { get { return false; } }

        protected virtual void UpdateText()
        {

        }

        protected virtual void OnVantBeDeleted(BaseOperatorControl sender)
        {
            WantBeDeleted?.Invoke(sender);
        }
    }
}
