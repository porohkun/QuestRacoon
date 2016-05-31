using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Condition : BaseOperator
    {
        public string _value = "";

        public string Value
        {
            get { return _value; }
            set { _value = value; Edited?.Invoke(); }
        }

        public override OperatorType Type { get { return OperatorType.Condition; } }

        public Condition()
        {
            
        }

        public override void DeleteLocale(string locale) { }

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
    }
}
