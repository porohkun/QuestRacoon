using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class ConditionEnd : BaseOperator
    {
        private static string _value = "END";

        public override OperatorType Type { get { return OperatorType.ConditionEnd; } }

        public override void DeleteLocale(string locale) { }

        public override string GetText(string locale)
        {
            return _value;
        }

        public override string ToString()
        {
            return GetText("Default");
        }
    }
}
