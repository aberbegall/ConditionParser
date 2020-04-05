# ConditionParser
A parser of string conditions

Text Condtion can include And or Or logic condition combined with parentheses.
For example:

            var items = new List<string> { "ABA", "BaB", "33", "TRz", "1" };
            const string condition = "(12)||(ABA||BAB)&&(33&&TRz)";
            var logicCondition = ConditionParser.Parse(condition);
            var result = logicCondition.Match(items);          
            
