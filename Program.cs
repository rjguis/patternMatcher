using System;

// Todo: Use a Unit Test framework
// Test push

namespace patternMatching  // Using vcDynamic Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.WriteLine("=======");
            Console.WriteLine();

            var matcher = new PatternMatcher();
            var text = "baaabab";
            Console.WriteLine($"Test Text:'{text}'");
            Console.WriteLine();

            // var testPattern = "*****ba*****ab";
            // var result = matcher.Test(text, testPattern);

            var testPattern = "*b";
            var result = matcher.Test("bbb", testPattern);


            Console.WriteLine($"Pattern: {testPattern}  Result: {result} ");
            Console.WriteLine();

/*
            testPattern = "a*ab";
            result = matcher.Test(text, testPattern);
            Console.WriteLine($"Pattern: {testPattern}  Result: {result} ");
            Console.WriteLine();
*/
            
            Console.WriteLine("Ended");
            Console.WriteLine("======");
        }
    }
}
