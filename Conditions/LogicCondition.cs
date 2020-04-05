using System.Collections.Generic;

namespace TextualConditions.Conditions
{
    /// <summary>
    /// Represents a logic condition.
    /// </summary>
    public abstract class LogicCondition
    {
        /// <summary>
        /// Matches the given items and returns the result.
        /// </summary>
        /// <param name="items">The items list.</param>
        /// <returns>The result of the match operation.</returns>
        public abstract bool Match(IEnumerable<string> items);
    }
}
