using System;

namespace Books.Algorithms.Chap2 {
    public class Bubble<T> where T : IComparable<T> {
        public static void Sort(T[] xs) {
            Sort(xs, 0, xs.Length - 1);
        }

        public static void Sort(T[] xs, int lo, int hi) {
            for (int i = lo; i <= hi; i++) {
                for (int j = lo; j <= hi - i - 1; j++) {
                    if (Sorting<T>.Less(xs[j + 1], xs[j])) {
                        Sorting<T>.Exchange(xs, j, j + 1);
                    }
                }
            }
        }
    }
}
