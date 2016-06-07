using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class AST_List:AST
    {
        private List<AST> _list;
        
        private AST_List()
        {
            _list = new List<AST>();
        }

        private void Add(AST node)
        {
            _list.Add(node);
        }

        public override void Interpret(IQuestContext context)
        {
            foreach (var ast in _list)
                ast.Interpret(context);
        }

        public static AST_List Parse(IEnumerator<IOperator> enumerator)
        {
            var result = new AST_List();
            while (enumerator.MoveNext())
                switch (enumerator.Current.Type)
                {
                    case OperatorType.Description:
                        result.Add(AST_Description.Parse(enumerator));
                        break;

                    case OperatorType.Speech:
                        result.Add(AST_Speech.Parse(enumerator));
                        break;

                    case OperatorType.Link:
                        result.Add(AST_Link.Parse(enumerator));
                        break;

                    case OperatorType.Assignment:
                        result.Add(AST_Assign.Parse(enumerator));
                        break;

                    case OperatorType.Condition:
                        result.Add(AST_Branch.Parse(enumerator));
                        break;

                    case OperatorType.ConditionElse:
                    case OperatorType.ConditionEnd:
                    default:
                        return result;
                }
            return result;
        }
    }
}
