using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class ConditionElse : IOperator
    {
        private static string _value = "ELSE";

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.ConditionElse; } }

        public void DeleteLocale(string locale) { }

        public string GetText(string locale)
        {
            return _value;
        }
    }
}
