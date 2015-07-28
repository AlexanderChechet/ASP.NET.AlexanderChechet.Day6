using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SorterWithAdapter
    {
        #region Public static methods
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            BubbleSort(array, comparer);
        }

        public static void Sort(int[][] array, Comparison<int[]> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException();
            SortAdapter comparer = new SortAdapter(comparison);
            BubbleSort(array, comparer);
        }
        #endregion

        #region Private static methods

        private static void BubbleSort(int[][] array, IComparer comparer)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length - i - 1; j++)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                        Swap(ref array[j], ref array[j + 1]);
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        #endregion
    }

    internal class SortAdapter : IComparer
    {
        private readonly Comparison<int[]> comparison; 

        public SortAdapter(Comparison<int[]> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(int[] first, int[] second)
        {
            return comparison(first, second);
        }
    }
}
