using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoonWpf.Quest;

namespace QuestRacoonWpf.Play
{
    public abstract class AST
    {
        public abstract void Interpret(IQuestContext context);
    }
}
