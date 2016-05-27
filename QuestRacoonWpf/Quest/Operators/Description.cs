using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Description : IOperator
    {
        public LocalizedText Text { get; private set; }

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.Description; } }

        public Description()
        {
            Text = new LocalizedText();
            Text.Edited += TextEdited;
        }

        public void TextEdited()
        {
            Edited?.Invoke();
        }

        public void DeleteLocale(string locale)
        {
            Text.DeleteLocale(locale);
        }

        public string GetText(string locale)
        {
            return Text.GetText(locale);
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
