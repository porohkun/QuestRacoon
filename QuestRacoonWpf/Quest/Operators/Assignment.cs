using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
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

        public Assignment(string variable, string value)
        {
            _variable = variable;
            _value = value;
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
    }
}
