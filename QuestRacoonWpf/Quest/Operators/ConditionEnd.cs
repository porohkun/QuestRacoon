using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class ConditionEnd : IOperator
    {
        private static string _value = "END";

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.ConditionEnd; } }

        public void DeleteLocale(string locale) { }

        public string GetText(string locale)
        {
            return _value;
        }
    }
}
