using System;

namespace Books.Algorithms.Chap2 {
    public class Sorting<T> where T : IComparable<T> {
        public static bool Less(T a, T b) {
            if (a.CompareTo(b) < 0) {
                return true;
            } else {
                return false;
            }
        }

        public static void Exchange(T[] xs, int i, int j) {
            T temp = xs[i];
            xs[i] = xs[j];
            xs[j] = temp;
        }

        public static bool IsSorted(T[] xs) {
            for (int i = 1; i < xs.Length; i++) {
                if (Less(xs[i], xs[i - 1])) {
                    return false;
                }
            }
            return true;
        }
    }
}
