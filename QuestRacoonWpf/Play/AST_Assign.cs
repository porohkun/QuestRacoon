using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class AST_Assign : AST
    {
        private string _variable;
        private AST_Condition _value;

        private AST_Assign(Assignment assign)
        {
            _variable = assign.Variable;
            _value = AST_Condition.Parse(assign.Value);
        }

        public override void Interpret(IQuestContext context)
        {
            var result = _value.Calculate(context);
            context.SetValue(_variable, result);
        }

        internal static AST Parse(IEnumerator<IOperator> enumerator)
        {
            return new AST_Assign(enumerator.Current as Assignment);
        }
    }
}
