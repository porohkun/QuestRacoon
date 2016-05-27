using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Speech : IOperator
    {
        private string _character = "";

        public string Character { get { return _character; } set { _character = value; Edited?.Invoke(); } }
        public LocalizedText Text { get; private set; }

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.Speech; } }

        public Speech(string character)
        {
            _character = character;
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
            if (_character == "")
                return "WRONG CHARACTER";
            return string.Format("{0}: \"{1}\"", Character, Text.GetText(locale));
        }
    }
}
