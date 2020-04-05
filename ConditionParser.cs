using System;
using System.Linq;
using System.Text.RegularExpressions;
using TextualConditions.Conditions;

namespace TextualConditions
{
    /// <summary>
    /// The condition parser.
    /// </summary>
    public static class ConditionParser
    {
        /// <summary>
        /// Parses the given condition into logic condition.
        /// </summary>
        /// <param name="condition">A condition.</param>
        /// <returns>A logic condition.</returns>
        public static LogicCondition Parse(string condition)
        {
            var operands = Regex.Matches(condition, @"(\|)+|(&)+|(\()+|(\))+|\w+");
            var index = 0;
            return ParseCondition(operands.Cast<Match>().Select(match => match.Value).ToArray(), ref index);
        }

        private static LogicCondition ParseCondition(string[] operands, ref int index)
        {
            var leftExp = ParseInnerCondition(operands, ref index);
            if (index >= operands.Length || operands[index] == ")")
            {
                return leftExp;
            }

            var operand = operands[index];

            switch (operand)
            {
                case "&&":
                {
                    index++;
                    var rightExp = ParseCondition(operands, ref index);
                    return new AndCondition(leftExp, rightExp);
                }
                case "||":
                {
                    index++;
                    var rightExp = ParseCondition(operands, ref index);
                    return new OrCondition(leftExp, rightExp);
                }
                default:
                {
                    throw new Exception($"Unknown operand found {operand}");
                }
            }
        }

        private static LogicCondition ParseInnerCondition(string[] operands, ref int index)
        {
            var operand = operands[index];
            if (operand == "(")
            {
                index++;
                var expression = ParseCondition(operands, ref index);

                if (operands[index] != ")")
                {
                    throw new Exception("Missing ')' operand");
                }

                index++;
                return expression;
            }

            index++;
            return new MatchCondition(operand);
        }
    }
}
