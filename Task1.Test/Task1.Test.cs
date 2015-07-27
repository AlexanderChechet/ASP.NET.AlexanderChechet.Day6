using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Test                                                                               
{
    [TestClass]
    public class Task1Test
    {
        #region MaxValue_TestMethods
        [TestMethod]
        public void MaxValueSort_PositiveNumbers()
        {
            int[] first = new[] {1, 2, 3, 10, 5};
            int[] second = new[] {5, 4, 13, 2, 1};
            int[] third = new[] {1, 12, 3, 4};
            int[][] array = new[] {first, second, third};

            MaxValueSort comparer = new MaxValueSort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] {second, third, first};

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void MaxValueSort_NegativeNumbers()
        {
            int[] first = new[] { -8, -2, -3, -10, -5 };
            int[] second = new[] { -5, -4, -13, -7, -9 };
            int[] third = new[] { -14, -12, -3, -24 };
            int[][] array = new[] { first, second, third };

            MaxValueSort comparer = new MaxValueSort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] { third, second, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void MaxValueSort_MixedNumbers()
        {
            int[] first = new[] { -1, 2, -3, 10, -5 };
            int[] second = new[] { 5, -4, -13, 2, 1 };
            int[] third = new[] { -1, 12, -3, 34 };
            int[][] array = new[] { third, second, first };

            MaxValueSort comparer = new MaxValueSort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] { third, second, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        #endregion

        #region SumArray_TestMethods
        [TestMethod]
        public void SumArraySort_PositiveNumbers()
        {
            int[] first = new[] { 1, 2, 3, 10, 5 }; //21
            int[] second = new[] { 5, 4, 13, 2, 1 }; //25
            int[] third = new[] { 1, 12, 3, 4 }; // 20
            int[][] array = new[] { first, second, third };

            SumArraySort comparer = new SumArraySort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] { second, first, third };
            
            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void SumArraySort_NegativeNumbers()
        {
            int[] first = new[] { -1, -2, -3, -10, -5 }; //-21
            int[] second = new[] { -5, -4, -13, -2, -1 }; //-25
            int[] third = new[] { -1, -12, -3, -4 }; //-20
            int[][] array = new[] { first, second, third };

            SumArraySort comparer = new SumArraySort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] { third, first, second };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void SumArraySort_MixedNumbers()
        {
            int[] first = new[] { -1, 2, 3, -10, 5 }; //-1
            int[] second = new[] { -5, 4, 13, 2, -1 }; //13
            int[] third = new[] { -1, 12, 3, -4 }; //10
            int[][] array = new[] { first, second, third };

            SumArraySort comparer = new SumArraySort();

            Sorter.Sort(array, comparer);

            int[][] result = new[] { second, third, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoComparer()
        {
            int[] first = new[] { -1, 2, 3, -10, 5 }; //5
            int[] second = new[] { -5, 4, 13, 2, -1 }; //13
            int[] third = new[] { -1, 12, 3, -4 }; //12
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, (IComparer)null);
        }

        #endregion

        #region Comparison_TestMethods
        [TestMethod]
        public void SumArrayComparison_PositiveNumbers()
        {
            int[] first = new[] { 1, 2, 3, 10, 5 }; //21
            int[] second = new[] { 5, 4, 13, 2, 1 }; //25
            int[] third = new[] { 1, 12, 3, 4 }; // 20
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, ComparisonSort.SumArrayComparisonDescending);

            int[][] result = new[] { second, first, third };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void SumArrayComparison_NegativeNumbers()
        {
            int[] first = new[] { -1, -2, -3, -10, -5 }; //-21
            int[] second = new[] { -5, -4, -13, -2, -1 }; //-25
            int[] third = new[] { -1, -12, -3, -4 }; //-20
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, ComparisonSort.SumArrayComparisonDescending);

            int[][] result = new[] { third, first, second };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void SumArrayComparison_MixedNumbers()
        {
            int[] first = new[] { -1, 2, 3, -10, 5 }; //-1
            int[] second = new[] { -5, 4, 13, 2, -1 }; //13
            int[] third = new[] { -1, 12, 3, -4 }; //10
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, ComparisonSort.SumArrayComparisonDescending);

            int[][] result = new[] { second, third, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void ArrayLengthComparison()
        {
            int[] first = new[] { 1, 2, 3, 10, 5 }; //5
            int[] second = new[] { 5, 4, 13 }; //3
            int[] third = new[] { 1, 12, 3, 4 }; // 4
            int[] forth = null;
            int[][] array = new[] { first, second, third, forth };

            Sorter.Sort(array, ComparisonSort.ArrayLengthComparisonDescending);

            int[][] result = new[] { first, third, second, forth};

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void MaxValueComparison_PositiveNumbers()
        {
            int[] first = new[] { 1, 2, 3, 10, 5 };
            int[] second = new[] { 5, 4, 13, 2, 1 };
            int[] third = new[] { 1, 12, 3, 4 };
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, ComparisonSort.MaxValueComparisonDescending);

            int[][] result = new[] { second, third, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void MaxValueComparison_NegativeNumbers()
        {
            int[] first = new[] { -8, -2, -3, -10, -5 };
            int[] second = new[] { -5, -4, -13, -7, -9 };
            int[] third = new[] { -14, -12, -3, -24 };
            int[][] array = new[] { first, second, third };

            Sorter.Sort(array, ComparisonSort.MaxValueComparisonDescending);

            int[][] result = new[] { third, second, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        [TestMethod]
        public void MaxValueComparison_MixedNumbers()
        {
            int[] first = new[] { -1, 2, -3, 10, -5 };
            int[] second = new[] { 5, -4, -13, 2, 1 };
            int[] third = new[] { -1, 12, -3, 34 };
            int[][] array = new[] { third, second, first };

            Sorter.Sort(array, ComparisonSort.MaxValueComparisonDescending);

            int[][] result = new[] { third, second, first };

            Assert.IsTrue(CompareArrays(result, array));
        }

        #endregion

        #region Private methods
        private bool CompareArrays(int[][] first, int[][] second)
        {
            if (first == null)
                if (second == null)
                    return true;
                else
                    return false;
            if (second == null)
                return false;

            int length = first.Length;
            if (length == second.Length)
            {
                int i = 0;
                for (; i < length && CompareArray(first[i], second[i]); i++)
                    ;
                if (i == length)
                    return true;
            }
            return false;
        }

        private bool CompareArray(int[] first, int[] second)
        {
            if (first == null)
                if (second == null)
                    return true;
                else
                    return false;
            if (second == null)
                return false;

            int length = first.Length;
            if (length == second.Length)
            {
                int i = 0;
                for (; i < length && first[i] == second[i]; i++)
                    ;
                if (i == length)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
