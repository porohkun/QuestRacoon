using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Speech : BaseOperator
    {
        private string _character = "";

        public string Character { get { return _character; } set { if (_character != value) { _character = value; Edited?.Invoke(); } } }
        public LocalizedText Text { get; private set; }
        
        public override OperatorType Type { get { return OperatorType.Speech; } }

        public Speech()
        {
            Text = new LocalizedText();
            Text.Edited += TextEdited;
        }

        public Speech(string character) : this()
        {
            _character = character;
        }

        public void TextEdited()
        {
            Edited?.Invoke();
        }

        public override void DeleteLocale(string locale)
        {
            Text.DeleteLocale(locale);
        }

        public override void RenameLocale(string oldLocale, string locale)
        {
            Text.RenameLocale(oldLocale, locale);
        }

        public override string GetText(string locale)
        {
            if (_character == "")
                return "WRONG CHARACTER";
            return string.Format("{0}: \"{1}\"", Character, Text.GetText(locale));
        }

        public override string ToString()
        {
            return string.Format("Speech:[{0}]", GetText("Default"));
        }
    }
}
