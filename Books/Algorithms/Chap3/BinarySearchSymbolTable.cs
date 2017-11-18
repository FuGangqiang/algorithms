using System;

namespace Books.Algorithms.Chap3 {
    public class BinarySearchSymbolTable<K, V> where K : IComparable<K> {
        private K[] keys;
        private V[] values;
        private int count;

        public BinarySearchSymbolTable(int cap) {
            keys = new K[cap];
            values = new V[cap];
        }

        public int Size {
            get => count;
        }

        public bool IsEmpty() {
            return count == 0;
        }

        public bool TryGet(K key, out V v) {
            if (IsEmpty()) {
                v = default(V);
                return false;
            }
            int i = Rank(key);
            if (i < count && keys[i].CompareTo(key) == 0) {
                v = values[i];
                return true;
            }
            v = default(V);
            return false;
        }

        public int Rank(K key) {
            int lo = 0;
            int hi = count - 1;
            while (lo <= hi) {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp < 0) {
                    hi = mid - 1;
                } else if (cmp > 0) {
                    lo = mid + 1;
                } else {
                    return mid;
                }
            }
            return lo;
        }

        public void Put(K key, V value) {
            int i = Rank(key);
            if (i < count && keys[i].CompareTo(key) == 0) {
                values[i] = value;
            }
            for (int j = count; j > i; j--) {
                keys[j] = keys[j - 1];
                values[j] = values[j - 1];
            }
            keys[i] = key;
            values[i] = value;
            count++;
        }
    }
}
