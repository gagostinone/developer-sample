using System;
using System.Linq;
using System.Numerics;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// Calculates the factorial of a non-negative integer.
        /// </summary>
        /// <param name="n">A non-negative integer for which to calculate the factorial.</param>
        /// <returns>The factorial of the input integer <paramref name="n"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when the input <paramref name="n"/> is negative.</exception>
        public static BigInteger GetFactorial(int n)
        {
            /*  
            Thoughts on code:
            - Returns BigInteger as Factorials rapidly exceed the limit for Ints and Longs.
            - Throws exception for negative inputs as you cannot calculate factorial for negative numbers.
            - Used for loop over recursion as recursion requires use of more memory to maintain the call stack.
            */

            if (n < 0)
                throw new ArgumentException("Input must be a non-negative integer.");

            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }


        /// <summary>
        /// Formats an array of strings by joining them with commas and an "and" separator.
        /// </summary>
        /// <param name="items">An array of strings to be formatted.</param>
        /// <returns>A formatted string with items joined by commas and an "and" separator.</returns>
        /// <remarks>
        /// If the input array is null or empty, an empty string is returned.
        /// If the input array contains only one item, that item is returned as is.
        /// </remarks>
        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            //Loops through all but last item and joins with commas. Then joins last string with an "and"
            return string.Join(", ", items.Take(items.Length - 1)) + " and " + items.Last();
        }
    }
}