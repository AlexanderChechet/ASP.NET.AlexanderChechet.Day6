using System.Linq;

namespace Task1.Test
{
    public sealed class SumArraySort : IComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            return second.Sum() - first.Sum();
        }
    }
}
