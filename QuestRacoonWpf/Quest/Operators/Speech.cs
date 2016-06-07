using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
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
        
        public Speech(JSONValue json):this()
        {
            _character = json["character"];
            Text.Parse(json["text"]);
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

        public override JSONValue ToJson()
        {
            var json = base.ToJson();
            json.Obj.Add("character", _character);
            json.Obj.Add("text", Text.ToJson());
            return json;
        }
    }
}
