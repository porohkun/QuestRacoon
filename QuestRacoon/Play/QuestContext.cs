using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public class QuestContext : IQuestContext
    {
        private Quest.Quest _quest;
        private Dictionary<string, string> _variables = new Dictionary<string, string>();
        private Action _clearCallback;
        private Dictionary<OperatorType, Action<IOperator>> _callbacks = new Dictionary<OperatorType, Action<IOperator>>();

        public QuestContext(Quest.Quest quest)
        {
            _quest = quest;
        }
        
        public string GetValue(string variable)
        {
            if (!_variables.ContainsKey(variable))
                return "false";
            else
                return _variables[variable];
        }

        public int GetIntValue(string variable)
        {
            if (!_variables.ContainsKey(variable))
                return 0;
            else
                return ConvertToInt(_variables[variable]);
        }

        public bool GetBoolValue(string variable)
        {
            if (!_variables.ContainsKey(variable))
                return false;
            else
                return ConvertToBool(_variables[variable]);
        }

        public void SetValue(string variable, string value)
        {
            if (!_variables.ContainsKey(variable))
                _variables.Add(variable, value);
            else
                _variables[variable] = value;
        }

        public void SetValue(string variable, int value)
        {
            SetValue(variable, value.ToString());
        }

        public void SetValue(string variable, bool value)
        {
            SetValue(variable, value.ToString().ToLower());
        }

        public bool ConvertToBool(int value)
        {
            return value != 0;
        }

        public bool ConvertToBool(string value)
        {
            switch (value)
            {
                case "true": return true;
                case "false": return false;
                case "0": return false;
                default: return true;
            }
        }

        public int ConvertToInt(bool value)
        {
            return value ? 1 : 0;
        }

        public int ConvertToInt(string value)
        {
            switch (value)
            {
                case "true": return 1;
                case "false": return 0;
                default:
                    int result = 0;
                    int.TryParse(value, out result);
                    return result;
            }
        }

        public Block GetBlock(string name)
        {
            foreach (var block in _quest.Blocks)
            {
                if (block.Name == name)
                {
                    return block;
                }
            }
            return null;
        }

        public void RegisterClearCallback(Action callback)
        {
            _clearCallback = callback;
        }

        public void RegisterCallback(OperatorType type, Action<IOperator> callback)
        {
            if (!_callbacks.ContainsKey(type))
                _callbacks.Add(type, callback);
            else
                _callbacks[type] = callback;
        }

        public void InvokeCallback(IOperator oper)
        {
            var type = oper.Type;
            var callback = _callbacks.ContainsKey(type) ? _callbacks[type] : null;
            callback?.Invoke(oper);
        }
    }
}
