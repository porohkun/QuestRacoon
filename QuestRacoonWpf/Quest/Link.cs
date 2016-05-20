using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRacoonWpf.Quest
{
    public struct Link
    {
        public string From;
        public string To;
        private string name1;
        private string name2;

        public Link(string name1, string name2) : this()
        {
            this.name1 = name1;
            this.name2 = name2;
        }
    }
}
