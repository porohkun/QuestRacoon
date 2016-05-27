using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class LocalizedText
    {
        public Action Edited { get; internal set; }

        internal bool DeleteLocale(string locale)
        {
            throw new NotImplementedException();
        }

        internal string GetText(string locale)
        {
            throw new NotImplementedException();
        }

        internal void SetText(string text, string locale)
        {
            throw new NotImplementedException();
        }
    }
}
