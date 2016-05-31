using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
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
        public abstract string GetText(string locale);
    }
}
