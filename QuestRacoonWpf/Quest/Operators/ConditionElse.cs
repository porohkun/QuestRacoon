using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoonWpf.Quest
{
    public class ConditionElse : BaseOperator
    {
        private static string _value = "ELSE";

        public override OperatorType Type { get { return OperatorType.ConditionElse; } }

        public ConditionElse()
        {
        }

        public ConditionElse(JSONValue json):this()
        {
        }

        public override void DeleteLocale(string locale) { }

        public override void RenameLocale(string oldLocale, string locale) { }

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
