using System;

namespace Books.Algorithms.Chap3 {
    public class SeparateChainingHashSymbolTable<K, V> where K : IComparable<K> {
        private int count;
        private int cap;
        private SequentialSearchSymbolTable<K, V>[] table;

        public SeparateChainingHashSymbolTable(int cap = 997) {
            this.cap = cap;
            table = new SequentialSearchSymbolTable<K, V>[cap];
            for (int i = 0; i < cap; i++) {
                table[i] = new SequentialSearchSymbolTable<K, V>();
            }
        }

        private int Hash(K key) {
            return key.GetHashCode() % cap;
        }

        public bool TryGet(K key, out V value) {
            return table[Hash(key)].TryGet(key, out value);
        }

        public void Put(K key, V value) {
            table[Hash(key)].Put(key, value);
            count++;
        }
    }
}
