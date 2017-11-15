using System;

namespace Books.Algorithms.Chap2 {
    public class Quick<T> where T : IComparable<T> {
        private static readonly int M = 5; // 5 ~ 15

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

        public static void Improved1Sort(T[] xs) {
            Improved1Sort(xs, 0, xs.Length - 1);
        }

        private static void Improved1Sort(T[] xs, int lo, int hi) {
            if (hi <= lo + M) {
                Insertion<T>.Sort(xs, lo, hi);
                return;
            }
            int j = Partition(xs, lo, hi);
            Improved1Sort(xs, lo, j - 1);
            Improved1Sort(xs, j + 1, hi);
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


        public static void Improved2Sort(T[] xs) {
            Improved1Sort(xs, 0, xs.Length - 1);
        }

        private static void Improved2Sort(T[] xs, int lo, int hi) {
            if (hi <= lo + M) {
                Insertion<T>.Sort(xs, lo, hi);
                return;
            }

            int lt = lo;
            int gt = hi;
            int i = lo + 1;
            T v = xs[lo];
            while (i <= gt) {
                int cmp = xs[i].CompareTo(v);
                if (cmp < 0) {
                    Sorting<T>.Exchange(xs, lt++, i++);
                } else if (cmp > 0) {
                    Sorting<T>.Exchange(xs, i, gt--);
                } else {
                    i++;
                }
            } // Now xs[lo..lt-1] < v = xs[lt..gt] < xs[gt+1..hi]

            Improved2Sort(xs, lo, lt - 1);
            Improved2Sort(xs, gt + 1, hi);
        }

    }
}
