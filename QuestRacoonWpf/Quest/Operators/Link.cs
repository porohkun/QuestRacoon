using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRacoonWpf.Quest
{
    public class Link: IOperator
    {
        public string To { get; private set; }

        public Action Edited { get; set; }

        public OperatorType Type { get { return OperatorType.Link; } }

        public void DeleteLocale(string locale)
        {
            throw new NotImplementedException();
        }

        public string GetText(string locale)
        {
            throw new NotImplementedException();
        }
    }
}
