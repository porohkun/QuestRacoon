using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class ConditionEnd : BaseOperator
    {
        private static string _value = "END";

        public override OperatorType Type { get { return OperatorType.ConditionEnd; } }

        public ConditionEnd()
        {
        }

        public ConditionEnd(JSONValue json):this()
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
