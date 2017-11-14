using System;

namespace Books.Algorithms.Chap2 {
    public class Selection<T> where T : IComparable<T> {
        public static void Sort(T[] xs) {
            Sort(xs, 0, xs.Length - 1);
        }

        private static void Sort(T[] xs, int lo, int hi) {
            for (int i = lo; i <= hi; i++) {
                int min = i;
                // find the smallest item in the left array
                for (int j = i + 1; j <= hi; j++) {
                    if (Sorting<T>.Less(xs[j], xs[min])) {
                        min = j;
                    }
                }
                // exchange it with current entry
                Sorting<T>.Exchange(xs, i, min);
            }
        }
    }
}
