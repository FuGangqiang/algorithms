using System;

namespace Books.Algorithms.Chap2 {
    public class MaxPriorityQueue<T> where T : IComparable<T> {
        private T[] queue;
        private int count;

        public MaxPriorityQueue(int max) {
            queue = new T[max + 1];
        }

        public void Insert(T v) {
            queue[++count] = v;
            Swim(count);
        }

        public T DelMax() {
            T max = queue[1];
            Exchange(1, count--);
            queue[count + 1] = default(T);
            Sink(1);
            return max;
        }

        public bool IsEmpty() {
            return count == 0;
        }

        public int Size {
            get => count;
        }

        private bool Less(int i, int j) {
            return queue[i].CompareTo(queue[j]) < 0;
        }

        private void Exchange(int i, int j) {
            T temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
        }

        private void Swim(int k) {
            while (k > 1 && Less(k / 2, k)) {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k) {
            while (2 * k <= count) {
                int j = 2 * k;
                if (j < count && Less(j, j + 1)) {
                    j++;
                }
                if (!Less(k, j)) {
                    break;
                }
                Exchange(k, j);
                k = j;
            }
        }
    }
}
