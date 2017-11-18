using System;

namespace Books.Algorithms.Chap2 {
    public class IndexMinPriorityQueue<T> where T : IComparable<T> {
        private int count;
        private int[] queue;
        private int[] inverse_queue;
        private T[] keys;

        public IndexMinPriorityQueue(int max) {
            int length = max + 1;
            queue = new int[length];
            inverse_queue = new int[length];
            keys = new T[length];
            for (int i = 0; i < length; i++) {
                inverse_queue[i] = -1;
            }
        }

        public bool IsEmpty() {
            return count == 0;
        }

        public bool Contains(int i) {
            if (i < 0 && i > inverse_queue.Length - 1) {
                throw new InvalidOperationException("index out of range");
            }
            return inverse_queue[i] != -1;
        }

        public int Size {
            get => count;
        }

        public void Insert(int i, T v) {
            if (Contains(i)) {
                throw new InvalidOperationException("index is already in the priority queue");
            }
            count++;
            queue[count] = i;
            inverse_queue[i] = count;
            keys[i] = v;
            Swim(count);
        }

        public int MinIndex() {
            if (count == 0) {
                throw new InvalidOperationException("Priority queue underflow");
            }
            return queue[1];
        }

        public T MinKey() {
            return keys[MinIndex()];
        }

        public int DelMin() {
            if (count == 0) {
                throw new InvalidOperationException("Priority queue underflow");
            }
            int min = queue[1];
            Exchange(1, count--);
            Sink(1);
            inverse_queue[min] = -1;
            keys[min] = default(T);
            return min;
        }

        public T KeyOf(int i) {
            if (!Contains(i)) {
                throw new InvalidOperationException("index is not in the priority queue");
            }
            return keys[i];
        }

        public void ChangeKey(int i, T v) {
            if (!Contains(i)) {
                throw new InvalidOperationException("index is not in the priority queue");
            }
            keys[i] = v;
            Swim(inverse_queue[i]);
            Sink(inverse_queue[i]);
        }

        public void DecreaseKey(int i, T v) {
            if (!Contains(i)) {
                throw new InvalidOperationException("index is not in the priority queue");
            }
            if (!Greater(i, v)) {
                throw new InvalidOperationException("not strictly decrease the key");
            }
            keys[i] = v;
            Swim(inverse_queue[i]);
        }

        public void IncreaseKey(int i, T v) {
            if (!Contains(i)) {
                throw new InvalidOperationException("index is not in the priority queue");
            }
            if (Greater(i, v)) {
                throw new InvalidOperationException("not strictly decrease the key");
            }
            keys[i] = v;
            Sink(inverse_queue[i]);
        }

        public void Delete(int i) {
            if (!Contains(i)) {
                throw new InvalidOperationException("index is not in the priority queue");
            }
            int index = inverse_queue[i];
            Exchange(index, count--);
            Swim(index);
            Sink(index);
            keys[i] = default(T);
            inverse_queue[i] = -1;
        }

        private bool Greater(int i, T v) {
            return keys[i].CompareTo(v) > 0;
        }

        private bool Greater(int i, int j) {
            return keys[queue[i]].CompareTo(keys[queue[j]]) > 0;
        }

        private void Exchange(int i, int j) {
            int temp = queue[i];
            queue[i] = queue[j];
            queue[j] = temp;
            inverse_queue[queue[i]] = i;
            inverse_queue[queue[j]] = j;
        }

        private void Swim(int k) {
            while (k > 1 && Greater(k / 2, k)) {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k) {
            while (2 * k <= count) {
                int j = 2 * k;
                if (j < count && Greater(j, j + 1)) {
                    j++;
                }
                if (!Greater(k, j)) {
                    break;
                }
                Exchange(k, j);
                k = j;
            }
        }
    }
}
