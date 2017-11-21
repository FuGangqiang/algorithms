using System;

namespace Books.Algorithms.Chap3 {
    public class LinearProbingHashSymbolTable<K, V> where K : IComparable<K> {
        private int count;
        private int cap;
        private K[] keys;
        private V[] values;

        public LinearProbingHashSymbolTable(int cap) {
            this.cap = cap;
            this.keys = new K[cap];
            this.values = new V[cap];
        }

        private int Hash(K key) {
            return key.GetHashCode() % cap;
        }

        private void Resize(int new_cap) {
            var temp = new LinearProbingHashSymbolTable<K, V>(new_cap);
            for (int i = 0; i < cap; i++) {
                if (!keys[i].Equals(default(K))) {
                    temp.Put(keys[i], values[i]);
                }
            }
            keys = temp.keys;
            values = temp.values;
            cap = new_cap;
        }

        public void Put(K key, V value) {
            if (count >= cap / 2) {
                Resize(2 * cap);
            }
            int i;
            for (i = Hash(key); !keys[i].Equals(default(K)); i = (i + 1) % cap) {
                if (keys[i].Equals(key)) {
                    values[i] = value;
                    return;
                }
            }
            keys[i] = key;
            values[i] = value;
            count++;
        }

        public bool TryGet(K key, out V value) {
            for (int i = Hash(key); !keys[i].Equals(default(K)); i = (i + 1) % cap) {
                if (keys[i].Equals(key)) {
                    value = values[i];
                    return true;
                }
            }
            value = default(V);
            return false;
        }
    }
}
