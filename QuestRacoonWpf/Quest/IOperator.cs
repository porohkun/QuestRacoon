﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestRacoonWpf
{
    public interface IOperator
    {
        Quest.OperatorType Type { get; }
        Action Edited { get; set; }

        string GetText(string locale);
        void DeleteLocale(string locale);
    }
}