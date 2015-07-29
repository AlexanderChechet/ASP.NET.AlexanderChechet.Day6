using System;
using System.Diagnostics;

namespace Task2
{
    public static class Gcd
    {
        public delegate int GcdDelegate(out long time, int a, int b);

        #region Public Euclid methods
        public static int EuclidGcd(int a, int b)
        {
            return GetGcd(a, b, Euclid);
        }

        public static int EuclidGcd(int a, int b, int c)
        {
            return GetGcd(a, b, c, Euclid);
        }

        public static int EuclidGcd(params int[] args)
        {
            return GetGcd(args, Euclid);
        }

        public static int EuclidGcd(out long time, int a, int b)
        {
            return GetGcd(out time, a, b, Euclid);
        }

        public static int EuclidGcd(int a, int b, int c, out long time)
        {
            return GetGcd(out time, a, b, c, Euclid);
        }

        public static int EuclidGcd(out long time, params int[] args)
        {
            return GetGcd(out time, args, Euclid);
        }
        #endregion

        #region Public Stein methods
        public static int SteinGcd(int a, int b)
        {
            return GetGcd(a, b, Stein);
        }

        public static int SteinGcd(int a, int b, int c)
        {
            return GetGcd(a, b, c, Stein);
        }

        public static int SteinGcd(params int[] args)
        {
            return GetGcd(args, Stein);
        }

        public static int SteinGcd(out long time, int a, int b)
        {
            return GetGcd(out time, a, b, Stein);
        }

        public static int SteinGcd(out long time, int a, int b, int c)
        {
            return GetGcd(out time, a, b, c, Stein);
        }

        public static int SteinGcd(out long time, params int[] args)
        {
            return GetGcd(out time, args, Stein);
        }
        #endregion

        #region Private methods

        private static int GetGcd(int a, int b, Func<int, int, int> gcdFunc)
        {
            return gcdFunc(a, b);
        }

        private static int GetGcd(int a, int b, int c, Func<int, int, int> gcdFunc)
        {
            return gcdFunc(gcdFunc(a, b), c);
        }

        private static int GetGcd(int[] array, Func<int, int, int> gcdFunc)
        {
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
                result = gcdFunc(result, array[i]);
            return result;
        }

        private static int GetGcd(out long time, int a, int b, GcdDelegate gcdFunc)
        {
            return gcdFunc(out time, a, b);
        }

        private static int GetGcd(out long time, int a, int b, int c, GcdDelegate gcdFunc)
        {
            return gcdFunc(out time, gcdFunc(out time, a, b), c);
        }

        private static int GetGcd(out long time, int[] array, GcdDelegate gcdFunc)
        {
            var stopWatch = Stopwatch.StartNew();
            int result = array[0];
            for (int i = 1; i < array.Length; i++)
                result = gcdFunc(out time, result, array[i]);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }

        private static int Euclid(out long time, int a, int b)
        {
            var stopWatch = Stopwatch.StartNew();
            int result = Euclid(a, b);
            time = stopWatch.ElapsedTicks;
            return result;
        }

        private static int Euclid(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static int Stein(out long time, int a, int b)
        {
            var stopWatch = Stopwatch.StartNew();
            int result = Stein(a, b);
            stopWatch.Stop();
            time = stopWatch.ElapsedTicks;
            return result;
        }

        private static int Stein(int a, int b)
        {
            int shift;

            if (a == 0) return b;
            if (b == 0) return a;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    Swap(ref a, ref b);
                }
                b = b - a;
            } while (b != 0);
            return a << shift;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}
