using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace PermutationChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            prompt("Please enter two expressions to check if any common permutations they have");
            prompt("--------------------------------------------------------------------");


            int i = 1;
            System.Collections.Generic.List<string> Expressions = new System.Collections.Generic.List<string>();

            while (i < 3)
            {
                prompt($"Please enter expression {i}:");
                string expr = Console.ReadLine().Trim();
                if (WordIsValid(expr))
                {
                    Expressions.Add(expr);
                    i++;
                }
                else
                {
                    // invalid expression input
                    Console.ForegroundColor = ConsoleColor.Red;
                    prompt("Please enter an expression which contains at least 2 chars.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            // check condition
            bool result = CheckForSharedPermutations(Expressions[0], Expressions[1]);
            prompt(result.ToString());
        }

        /// <summary>
        /// Inspects one of the permutations of given expressions contains one of the permutations of the other
        /// </summary>
        /// <param name="expr1">Given exppression 1</param>
        /// <param name="expr2">Given expression 2</param>
        /// <returns>'True' for one of the permutations of any, contains one of the permutations of the other one.</returns>
        public static bool CheckForSharedPermutations(string expr1, string expr2)
        {
            if (expr1.ToCharArray().All(a => expr2.Contains(a)) 
                || expr2.ToCharArray().All(a=> expr1.Contains(a)))
            {
                // if one of the expressions contains all the chars in another, one of it's permutations must contain the another one
                // so this is the condition that we search for
                return true;
            }

            return false;
        }

        private static bool WordIsValid(string expr)
        {
            return expr.Length >= 2;
        }

        private static void prompt(string txt)
        {
            Console.WriteLine(txt);
        }

   
    }
}
