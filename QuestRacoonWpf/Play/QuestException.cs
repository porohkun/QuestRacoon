using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace QuestRacoonWpf.Play
{
    public class QuestException : SystemException
    {
        public QuestException() : base() { }
        public QuestException(string message) : base(message) { }
        public QuestException(string message, Exception innerException) : base(message, innerException) { }
    }
}