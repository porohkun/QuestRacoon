using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf.Play
{
    public class AST_Link : AST
    {
        private Link _link;

        private AST_Link(Link link)
        {
            _link = link;
        }

        public override void Interpret(IQuestContext context)
        {
            context.InvokeCallback(_link);
        }

        internal static AST Parse(IEnumerator<IOperator> enumerator)
        {
            return new AST_Link(enumerator.Current as Link);
        }
    }
}
