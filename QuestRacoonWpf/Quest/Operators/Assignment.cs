using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf.Quest
{
    public class Assignment : IOperator
    {
        private string _variable = "";
        private string _value = "";

        public string Variable
        {
            get { return _variable; }
            set { _variable = value; Edited?.Invoke(); }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value;Edited?.Invoke(); }
        }

        public Action Edited { get; set; }
        
        public Assignment(string variable, string value)
        {
            _variable = variable;
            _value = value;
        }

        public void DeleteLocale(string locale) { }

        public string GetText(string locale)
        {
            if (_variable == "" || _value == "")
                return "WRONG ASSIGNMENT";
            return string.Format("{0} = {1};", _variable, _value);
        }
    }
}
