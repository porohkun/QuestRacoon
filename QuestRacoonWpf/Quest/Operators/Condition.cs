using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Condition : IOperator
    {
        public string _value = "";

        public string Value
        {
            get { return _value; }
            set { _value = value; Edited?.Invoke(); }
        }

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.Condition; } }

        public Condition(string value)
        {
            _value = value;
        }

        public void DeleteLocale(string locale) { }

        public string GetText(string locale)
        {
            if (_value == "")
                return "WRONG CONDITION";
            return string.Format("IF ({0})", _value);
        }
    }
}
