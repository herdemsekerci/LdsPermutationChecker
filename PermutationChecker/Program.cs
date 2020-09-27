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

            // check permutations of 
            bool result = CheckPermutations(Expressions[0], Expressions[1]);
            prompt(result.ToString());
        }

        /// <summary>
        /// Inspects one of the permutations of given expressions contains one of the permutations of the other
        /// </summary>
        /// <param name="expr1">Given exppression 1</param>
        /// <param name="expr2">Given expression 2</param>
        /// <returns>True one of the permutations of any, contains one of the permutations of the other one.</returns>
        public static bool CheckPermutations(string expr1, string expr2)
        {
            // gets all permutations of expr1
            List<string> allPermutationsOfExpr1 = Permutation.GetPer(expr1.ToCharArray(), expr2);

            if (!Permutation.IsFound)
            {
                // one of the permutations of any, contains one of the permutations of the other one' 
                // one of the expr1' permutations contains expr2, no need to query expr2's permutations
                Permutation.GetPer(expr2.ToCharArray(), expr1);
            }
         
            return Permutation.IsFound;
        }

        private static bool WordIsValid(string expr)
        {
            return expr.Length >= 2;
        }

        private static void prompt(string txt)
        {
            Console.WriteLine(txt);
        }

        public class Permutation
        {
            // permutations
            public static bool IsFound = false;
            public static List<string> GetPer(char[] list, string evaluateKeyWord)
            {
                IsFound = false;
                int x = list.Length - 1;
                List<string> allPermutations = new List<string>();
                GetPer(list, 0, x, evaluateKeyWord, allPermutations);
                return allPermutations.Distinct().ToList();
            }
            private static void Swap(ref char a, ref char b)
            {
                if (a == b) return;

                var temp = a;
                a = b;
                b = temp;
            }

            private static void GetPer(char[] list, int k, int m, string evaluateKeyWord, List<string> permutations)
            {
                if (IsFound)
                    return;

                if (k == m)
                {
                    if (new string(list).Contains(evaluateKeyWord))
                    {
                        IsFound = true;
                    }
                    //permutations.Add(new string(list));
                }
                else
                    for (int i = k; i <= m; i++)
                    {
                        Swap(ref list[k], ref list[i]);
                        GetPer(list, k + 1, m, evaluateKeyWord, permutations);
                        Swap(ref list[k], ref list[i]);
                    }
            }

        }

    }
}
