using System.Collections.Generic;
using System.Linq;

namespace TextualConditions.Conditions
{
    internal class MatchCondition : LogicCondition
    {
        public string Item { get; }

        public MatchCondition(string item)
        {
            this.Item = item;
        }

        /// <summary>
        /// Matches the given items and returns the result.
        /// </summary>
        /// <param name="items">The items list.</param>
        /// <returns>The result of the match operation.</returns>
        public override bool Match(IEnumerable<string> items)
        {
            return items.Contains(this.Item);
        }
    }
}
