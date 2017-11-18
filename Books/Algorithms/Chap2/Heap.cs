using System;

namespace Books.Algorithms.Chap2 {
    public class Heap<T> where T : IComparable<T> {
        public static void Sort(T[] xs) {
            int n = xs.Length;
            // construct heap
            for (int i = n / 2; i >= 1; i--) {
                Sink(xs, i, n);
            }
            // get sorted element from heap
            while (n > 1) {
                Exchange(xs, 1, n--);
                Sink(xs, 1, n);
            }
        }

        private static void Sink(T[] xs, int k, int max) {
            while (2 * k <= max) {
                int j = 2 * k;
                if (j < max && Less(xs, j, j + 1)) {
                    j++;
                }
                if (!Less(xs, k, j)) {
                    break;
                }
                Exchange(xs, k, j);
                k = j;
            }
        }

        private static void Exchange(T[] xs, int i, int j) {
            i--;
            j--;
            T temp = xs[i];
            xs[i] = xs[j];
            xs[j] = temp;
        }

        private static bool Less(T[] xs, int i, int j) {
            i--;
            j--;
            return xs[i].CompareTo(xs[j]) < 0;
        }
    }
}
