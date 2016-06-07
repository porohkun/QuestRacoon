using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public abstract class AST
    {
        public abstract void Interpret(IQuestContext context);
    }
}
