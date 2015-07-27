using System;
using System.Linq;

namespace Task1.Test
{
    static class ComparisonSort
    {
        public static int ArrayLengthComparisonAscending(int[] first, int[] second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            return first.Length - second.Length;
        }

        public static int ArrayLengthComparisonDescending(int[] first, int[] second)
        {
            return -ArrayLengthComparisonAscending(first, second);
        }

        public static int MaxValueComparisonAscending(int[] first, int[] second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            return first.Max(x => Math.Abs(x)) - second.Max(x => Math.Abs(x));
        }

        public static int MaxValueComparisonDescending(int[] first, int[] second)
        {
            return -MaxValueComparisonAscending(first, second);
        }

        public static int SumArrayComparisonAscending(int[] first, int[] second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            return first.Sum() - second.Sum();
        }

        public static int SumArrayComparisonDescending(int[] first, int[] second)
        {
            return -SumArrayComparisonAscending(first, second);
        }
    }
}
