using System;

namespace Books.Algorithms.Chap3 {
    public class RedBlackTree<K, V> where K : IComparable<K> {
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;
        private Node root;

        private class Node {
            public K Key;
            public V Value;
            public Node Left;
            public Node Right;
            public int Count;
            public bool Color;

            public Node(K key, V value, int count, bool color) {
                Key = key;
                Value = value;
                Count = count;
                Color = color;
            }
        }

        public int Size() {
            return Size(root);
        }

        private bool IsRed(Node x) {
            if (x == null) {
                return false;
            }
            return x.Color == RED;
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
            root.Color = BLACK;
        }

        private Node Put(Node h, K key, V value) {
            if (h == null) {
                return new Node(key, value, 1, RED);
            }
            int cmp = key.CompareTo(h.Key);
            if (cmp < 0) {
                h.Left = Put(h.Left, key, value);
            } else if (cmp > 0) {
                h.Right = Put(h.Right, key, value);
            } else {
                h.Value = value;
            }
            if (IsRed(h.Right) && !IsRed(h.Left)) {
                h = RotateLeft(h);
            }
            if (IsRed(h.Left) && IsRed(h.Left.Left)) {
                h = RotateRight(h);
            }
            if (IsRed(h.Left) && IsRed(h.Right)) {
                FlipColors(h);
            }
            h.Count = 1 + Size(h.Left) + Size(h.Right);
            return h;
        }

        private Node RotateLeft(Node h) {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.Count = h.Count;
            h.Count = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private Node RotateRight(Node h) {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            x.Count = h.Count;
            h.Count = 1 + Size(h.Left) + Size(h.Right);
            return x;
        }

        private void FlipColors(Node h) {
            h.Color = RED;
            h.Left.Color = BLACK;
            h.Right.Color = BLACK;
        }
    }
}
