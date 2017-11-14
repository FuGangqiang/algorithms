using System;

namespace Books.Algorithms.Chap2 {
    public class Shell<T> where T : IComparable<T> {
        public static void Sort(T[] xs) {
            int h = 1;
            while (h < xs.Length) {
                h = 3 * h + 1;
            }
            while (h >= 1) {
                for (int i = h; i < xs.Length; i++) {
                    for (int j = i; j >= h; j -= h) {
                        if (Sorting<T>.Less(xs[j], xs[j - h])) {
                            Sorting<T>.Exchange(xs, j, j - h);
                        }
                    }
                }
                h /= 3;
            }
        }
    }
}
