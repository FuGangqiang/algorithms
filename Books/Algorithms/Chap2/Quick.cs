using System;

namespace Books.Algorithms.Chap2 {
    public class Quick<T> where T : IComparable<T> {
        public static void SimpleSort(T[] xs) {
            SimpleSort(xs, 0, xs.Length - 1);
        }

        private static void SimpleSort(T[] xs, int lo, int hi) {
            if (hi <= lo) {
                return;
            }
            int j = Partition(xs, lo, hi);
            SimpleSort(xs, lo, j - 1);
            SimpleSort(xs, j + 1, hi);
        }

        private static int Partition(T[] xs, int lo, int hi) {
            T v = xs[lo];
            int i = lo;
            int j = hi + 1;
            while (true) {
                while (Sorting<T>.Less(xs[++i], v)) {
                    if (i == hi) {
                        break;
                    }
                }
                while (Sorting<T>.Less(v, xs[--j])) {
                    if (j == lo) {
                        break;
                    }
                }
                if (i >= j) {
                    break;
                }
                Sorting<T>.Exchange(xs, i, j);
            }
            Sorting<T>.Exchange(xs, lo, j);
            return j;
        }
    }
}
