using System;
using System.Collections.Generic;
using System.Text;

namespace TextualConditions.Conditions
{
    internal abstract class BinaryCondition : LogicCondition
    {
        public LogicCondition LeftCondition { get; }

        public LogicCondition RightCondition { get; }

        protected BinaryCondition(LogicCondition left, LogicCondition right)
        {
            this.LeftCondition = left;
            this.RightCondition = right;
        }
    }
}
