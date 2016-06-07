using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
{
    public abstract class BaseOperator : IOperator
    {
        public Action Edited { get; set; }
        public Action<IOperator> WantBeDeleted { get; set; }
        public abstract OperatorType Type { get; }
        
        public void Delete()
        {
            WantBeDeleted?.Invoke(this);
        }

        public abstract void DeleteLocale(string locale);
        public abstract void RenameLocale(string oldLocale, string locale);
        public abstract string GetText(string locale);

        public static IOperator Parse(JSONValue json)
        {
            IOperator result = null;
            switch ((OperatorType)Enum.Parse(typeof(OperatorType), json["type"]))
            {
                case OperatorType.Assignment: result = new Assignment(json); break;
                case OperatorType.Condition: result = new Condition(json); break;
                case OperatorType.ConditionElse: result = new ConditionElse(json); break;
                case OperatorType.ConditionEnd: result = new ConditionEnd(json); break;
                case OperatorType.Description: result = new Description(json); break;
                case OperatorType.Link: result = new Link(json); break;
                case OperatorType.Speech: result = new Speech(json); break;
            }
            return result;
        }

        public virtual JSONValue ToJson()
        {
            return new JSONObject(new JOPair("type", Type.ToString()));
        }
    }
}
