using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoonWpf
{
    public interface IOperator
    {
        Quest.OperatorType Type { get; }
        Action<IOperator> WantBeDeleted { get; set; }
        Action Edited { get; set; }
        
        JSONValue ToJson();

        string GetText(string locale);
        void DeleteLocale(string locale);
        void Delete();
        void RenameLocale(string oldLocale, string locale);
    }
}
