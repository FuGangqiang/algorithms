using System;

namespace Books.Algorithms.Chap2 {
    public class Merging<T> where T : IComparable<T> {
        private T[] temp;

        public void RecurisiveSort(T[] xs) {
            temp = new T[xs.Length];
            RecurisiveSort(xs, 0, xs.Length - 1);
        }

        private void RecurisiveSort(T[] xs, int lo, int hi) {
            if (hi <= lo) {
                return;
            }
            int mid = lo + (hi - lo) / 2;
            RecurisiveSort(xs, lo, mid);
            RecurisiveSort(xs, mid + 1, hi);
            Merge(xs, lo, mid, hi);
        }

        private void Merge(T[] xs, int lo, int mid, int hi) {
            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++) {
                temp[k] = xs[k];
            }

            for (int k = lo; k <= hi; k++) {
                if (i > mid) {
                    xs[k] = temp[j++];
                } else if (j > hi) {
                    xs[k] = temp[i++];
                } else if (Sorting<T>.Less(temp[j], temp[i])) {
                    xs[k] = temp[j++];
                } else {
                    xs[k] = temp[i++];
                }
            }
        }
    }
}
