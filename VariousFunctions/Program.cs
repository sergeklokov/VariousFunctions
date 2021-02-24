using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace VariousFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Welcome!"; // even
            Console.Write(s1 + "        ");
            Console.WriteLine(ReverseString(s1));
            string s2 = "Welcome"; // odd
            Console.Write(s2 + "        ");
            Console.WriteLine(ReverseString(s2));
            Console.WriteLine();

            Console.WriteLine("Is madam palindrome? " + IsPalindrome("madam"));
            Console.WriteLine("Is Phoenix palindrome? " + IsPalindrome("Phoenix"));
            Console.WriteLine();

            Console.WriteLine("Welcome to Serge's coding exercises  ------  " + ReverseWordOrder("Welcome to Serge's coding exercises"));
            Console.WriteLine();

            Console.WriteLine("Vowels in 'I am trying to count the vowels' = " + CountVowels("I am trying to count the vowels"));
            Console.WriteLine("Vowels in 'I am trying to count the vowels' by LINQ = " + CountVowelsLINQ("I am trying to count the vowels"));

            Console.WriteLine();
            LambdaParametersDemo();
            Console.WriteLine();

            Console.WriteLine("========================================");
            Console.WriteLine("Press any key..");
            Console.ReadKey();
        }

        /// <summary>
        /// How to reverse a string?
        /// https://ankitsharmablogs.com/csharp-coding-questions-for-technical-interviews/
        /// </summary>
        private static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            for (int i = 0; i < (charArray.Length - 1) / 2 ; i++)
            {
                var temp = charArray[i];
                var j = charArray.Length - 1 - i;
                charArray[i] = charArray[j];
                charArray[j] = temp;
            }

            return new string(charArray);
        }

        /// <summary>
        /// How to find if the given string is a palindrome or not?
        /// </summary>
        private static bool IsPalindrome(string s)
        {
            for (int i = 0, j = s.Length - 1; i < s.Length / 2; i++, j--)
                if (s[i] != s[j])
                    return false;

            return true;
        }

        private static string ReverseWordOrder(string s)
        {
            int i = s.Length - 1;

            int wordStart;
            var wordEnd = i;
            var reversed = new StringBuilder(); 

            while (i >= 0)
            {
                if (s[i] ==  ' ')
                {
                    wordStart = i + 1;
                    reversed.Append(s.Substring(wordStart, wordEnd - wordStart + 1)).Append(" ");
                    wordEnd = i;
                }
                //else if (i == 0)
                //{
                //    wordStart = i;
                //    reversed.Append(s.Substring(wordStart, wordEnd - wordStart + 1)).Append(" ");
                //    wordEnd = i;
                //}

                i--;
            }

            reversed.Append(s.Substring(0, wordEnd + 1)).Append(" ");  // replaced commented out text

            return reversed.ToString();
        }

        /// <summary>
        /// I am trying to count (or print) the vowels in a string
        /// https://stackoverflow.com/questions/18109890/c-sharp-count-vowels
        /// </summary>
        private static int CountVowels(string s)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };  // Hash set represents a set of values.
            var total = 0;

            foreach (var c in s)
                if (vowels.Contains(c))
                {
                    Console.Write(c + " ");
                    total++;
                }

            Console.WriteLine();
            return total;
        }

        /// <summary>
        /// I am trying to count (or print) the vowels in a string by using LINQ
        /// https://stackoverflow.com/questions/18109890/c-sharp-count-vowels
        /// </summary>
        private static int CountVowelsLINQ(string s)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };  // Hash set represents a set of values.
            int total = s.Count(c => vowels.Contains(c));

            // print whole string by converting to char array and for looping 
            // s.ToCharArray().ToList().ForEach(c => Console.Write(c + " "));

            // print just vowels could be tricky
            s.Where(c => vowels.Contains(c))
                .ToList()
                .ForEach(c => Console.Write(c + " "));

            Console.WriteLine();

            return total;
        }

        /// <summary>
        /// Let's play with pure lambda expressions and parameters
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
        /// </summary>
        private static void LambdaParametersDemo()
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine("Lambda with one parameter: " + square(5));

            Func<int, int, int> multiply = (x,y) => x * y;
            Console.WriteLine("Lambda with two parameters: " + multiply(4,5));

            //discards
            //
            // Error CS8400  Feature 'lambda discard parameters' is not available in C# 8.0. Please use language version 9.0 or greater.	
            //

            //Func<int, int, int> constantTest = (_, _) => 42;
            //Console.WriteLine("discards parameters  : " + constantTest);
            //Console.WriteLine("discards parameters 2: " + constantTest(1,2));

            Console.WriteLine();
        }
    }
}
