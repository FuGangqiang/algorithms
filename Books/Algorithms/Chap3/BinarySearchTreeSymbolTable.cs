using System;

namespace Books.Algorithms.Chap3 {
    public class BinarySearchTreeSymbolTable<K, V> where K : IComparable<K> {
        private Node root;

        private class Node {
            public K Key;
            public V Value;
            public Node Left;
            public Node Right;
            public int Count;

            public Node(K key, V value, int count) {
                Key = key;
                Value = value;
                Count = count;
            }
        }

        public int Size() {
            return Size(root);
        }

        private int Size(Node x) {
            if (x == null) {
                return 0;
            } else {
                return x.Count;
            }
        }

        public bool TryGet(K key, out V value) {
            return TryGet(root, key, out value);
        }

        private bool TryGet(Node x, K key, out V value) {
            if (x == null) {
                value = default(V);
                return false;
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                return TryGet(x.Left, key, out value);
            } else if (cmp > 0) {
                return TryGet(x.Right, key, out value);
            } else {
                value = x.Value;
                return true;
            }
        }

        public void Put(K key, V value) {
            root = Put(root, key, value);
        }

        private Node Put(Node x, K key, V value) {
            if (x == null) {
                return new Node(key, value, 1);
            }
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) {
                x.Left = Put(x.Left, key, value);
            } else if (cmp > 0) {
                x.Right = Put(x.Right, key, value);
            } else {
                x.Value = value;
            }
            x.Count = Size(x.Left) + Size(x.Right) + 1;
            return x;
        }
    }
}
