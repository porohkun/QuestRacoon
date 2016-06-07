using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class Assignment : BaseOperator
    {
        private string _variable = "";
        private string _value = "";

        public string Variable
        {
            get { return _variable; }
            set { _variable = value; Edited?.Invoke(); }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value;Edited?.Invoke(); }
        }

        public override OperatorType Type { get { return OperatorType.Assignment; } }

        public Assignment()
        {
        }

        public Assignment(JSONValue json):this()
        {
            _variable = json["variable"];
            _value = json["value"];
        }

        public override void DeleteLocale(string locale) { }

        public override void RenameLocale(string oldLocale, string locale) { }

        public override string GetText(string locale)
        {
            if (_variable == "" || _value == "")
                return "WRONG ASSIGNMENT";
            return string.Format("{0} = {1};", _variable, _value);
        }

        public override string ToString()
        {
            return string.Format("Assignment:[{0}]", GetText("Default"));
        }

        public override JSONValue ToJson()
        {
            var json = base.ToJson();
            json.Obj.Add("variable", Variable);
            json.Obj.Add("value", Value);
            return json;
        }

        internal IEnumerable<string> GetVariables()
        {
            yield return _variable;
        }
    }
}
