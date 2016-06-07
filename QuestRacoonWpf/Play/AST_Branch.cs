using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class AST_Branch : AST
    {
        private AST_Condition _condition;
        private AST_List _ifAst;
        private AST_List _elseAst;

        private AST_Branch(Condition condition)
        {
            _condition = AST_Condition.Parse(condition.Value);
        }

        public override void Interpret(IQuestContext context)
        {
            if (_condition.Check(context))
                _ifAst?.Interpret(context);
            else
                _elseAst?.Interpret(context);
        }

        internal static AST Parse(IEnumerator<IOperator> enumerator)
        {
            var result = new AST_Branch(enumerator.Current as Condition);
            result._ifAst = AST_List.Parse(enumerator);
            if (enumerator.Current.Type == OperatorType.ConditionElse)
                result._elseAst = AST_List.Parse(enumerator);
            return result;
        }
    }
}
