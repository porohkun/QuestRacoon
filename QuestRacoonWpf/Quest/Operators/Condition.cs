using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoonWpf.Quest
{
    public class Condition : BaseOperator
    {
        private string _value = "";

        public string Value
        {
            get { return _value; }
            set { _value = value; Edited?.Invoke(); }
        }

        public override OperatorType Type { get { return OperatorType.Condition; } }

        public Condition()
        {
        }

        public Condition(JSONValue json):this()
        {
            _value = json["value"];
        }

        public override void DeleteLocale(string locale) { }

        public override void RenameLocale(string oldLocale, string locale) { }

        public override string GetText(string locale)
        {
            if (_value == "")
                return "WRONG CONDITION";
            return string.Format("IF ({0})", _value);
        }

        public override string ToString()
        {
            return GetText("Default");
        }
        
        public override JSONValue ToJson()
        {
            var json = base.ToJson();
            json.Obj.Add("value", Value);
            return json;
        }
    }
}
