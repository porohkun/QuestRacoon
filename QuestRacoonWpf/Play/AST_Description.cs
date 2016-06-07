using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class AST_Description : AST
    {
        private Description _description;

        private AST_Description(Description description)
        {
            _description = description;
        }

        public override void Interpret(IQuestContext context)
        {
            context.InvokeCallback(_description);
        }

        internal static AST Parse(IEnumerator<IOperator> enumerator)
        {
            return new AST_Description(enumerator.Current as Description);
        }
    }
}
