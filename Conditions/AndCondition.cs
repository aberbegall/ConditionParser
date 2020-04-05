using System.Collections.Generic;
using System.Linq;

namespace TextualConditions.Conditions
{
    internal class AndCondition : BinaryCondition
    {
        public AndCondition(LogicCondition left, LogicCondition right) 
            : base(left, right)
        {
        }

        /// <summary>
        /// Matches the given items and returns the result.
        /// </summary>
        /// <param name="items">The items list.</param>
        /// <returns>The result of the match operation.</returns>
        public override bool Match(IEnumerable<string> items)
        {
            var itemsList = items.ToArray();
            return LeftCondition.Match(itemsList) && RightCondition.Match(itemsList);
        }
    }
}
