using System;

namespace Books.Algorithms.Chap2 {
    public class Insertion<T> where T : IComparable<T> {
        public static void Sort(T[] xs) {
            Sort(xs, 0, xs.Length - 1);
        }

        public static void Sort(T[] xs, int lo, int hi) {
            // the items before i has been sorted
            for (int i = lo + 1; i <= hi; i++) {
                // insert the ith item to the sorted array
                for (int j = i; j > 0; j--) {
                    if (Sorting<T>.Less(xs[j], xs[j - 1])) {
                        Sorting<T>.Exchange(xs, j - 1, j);
                    }
                }
            }
        }
    }
}
