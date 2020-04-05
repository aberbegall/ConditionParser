using System;
using System.Collections.Generic;

namespace TextualConditions
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<string> { "ABA", "BaB", "33", "TRz", "1" };
            const string condition = "(12)||(ABA||BAB)&&(33&&TRz)";
            var logicCondition = ConditionParser.Parse(condition);

            Console.WriteLine($"List of items: {string.Join(",", items) }");
            Console.WriteLine($"Condition: {condition}");
            Console.WriteLine($"Result: {logicCondition.Match(items)}");
            Console.ReadKey();
        }
    }
}
