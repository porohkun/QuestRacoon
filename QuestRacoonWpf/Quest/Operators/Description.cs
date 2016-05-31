using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Description : BaseOperator
    {
        public LocalizedText Text { get; private set; }

        public override OperatorType Type { get { return OperatorType.Description; } }

        public Description()
        {
            Text = new LocalizedText();
            Text.Edited += TextEdited;
        }

        public void TextEdited()
        {
            Edited?.Invoke();
        }

        public override void DeleteLocale(string locale)
        {
            Text.DeleteLocale(locale);
        }

        public override string GetText(string locale)
        {
            return Text.GetText(locale);
        }
        
        public override string ToString()
        {
            return string.Format("Description:[{0}]", GetText("Default"));
        }
    }
}
