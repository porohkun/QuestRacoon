using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class AST_Speech : AST
    {
        private Speech _speech;

        private AST_Speech(Speech speech)
        {
            _speech = speech;
        }

        public override void Interpret(IQuestContext context)
        {
            context.InvokeCallback(_speech);
        }

        internal static AST Parse(IEnumerator<IOperator> enumerator)
        {
            return new AST_Speech(enumerator.Current as Speech);
        }
    }
}
