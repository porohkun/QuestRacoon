using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestRacoon.Quest;

namespace QuestRacoon.Play
{
    public interface IQuestContext
    {
        string GetValue(string variable);
        int GetIntValue(string variable);
        bool GetBoolValue(string variable);
        void SetValue(string variable, string value);
        void SetValue(string variable, int value);
        void SetValue(string variable, bool value);
        bool ConvertToBool(int value);
        bool ConvertToBool(string value);
        int ConvertToInt(bool value);
        int ConvertToInt(string value);
        Block GetBlock(string name);
        void RegisterClearCallback(Action callback);
        void RegisterCallback(OperatorType type, Action<IOperator> callback);
        void InvokeCallback(IOperator oper);
    }
}
