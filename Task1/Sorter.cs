using System;

namespace Task1
{
    public class Sorter
    {
        #region Public static methods
        public static void Sort(int[][] array, IComparer comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            BubbleSort(array, comparer.Compare);
        }

        public static void Sort(int[][] array, Func<int[], int[], int> comparison)
        {
            if (comparison == null)
                throw new ArgumentNullException();
            BubbleSort(array, comparison);
        }
        #endregion

        #region Private static methods

        private static void BubbleSort(int[][] array, Func<int[], int[], int> comparison)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length - i - 1; j++)
                    if (comparison(array[j], array[j + 1]) > 0)
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
}
