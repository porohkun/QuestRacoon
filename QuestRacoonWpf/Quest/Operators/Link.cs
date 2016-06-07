using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class Link: BaseOperator
    {
        private string _text;
        private string _to;
        public string Text { get { return _text; } set { if (_text != value) { _text = value; Edited?.Invoke(); } } }
        public string To { get { return _to; } set { if (_to != value) { _to = value; Edited?.Invoke(); } } }

        public override OperatorType Type { get { return OperatorType.Link; } }

        public Link()
        {
        }

        public Link(JSONValue json):this()
        {
            _text = json["text"];
            _to = json["to"];
        }

        public override void DeleteLocale(string locale) { }

        public override void RenameLocale(string oldLocale, string locale) { }

        public override string GetText(string locale)
        {
            return Text;
        }

        public override string ToString()
        {
            return string.Format("Link:[{0}]", GetText("Default"));
        }

        public override JSONValue ToJson()
        {
            var json = base.ToJson();
            json.Obj.Add("text", _text);
            json.Obj.Add("to", _to);
            return json;
        }
    }
}
