using System;

namespace Books.Algorithms.Chap6 {
    public class BinaryTreeSymbolTable<K, V> where K : IComparable<K> {
        // max children per B-tree node = M-1
        // (must be even and greater than 2)
        private static readonly int M = 4;
        // root of the B-tree
        private Node root;
        // height of the B-tree
        private int height;
        // number of key-value pairs in the B-tree
        private int n;

        private class Node {
            // number of children
            public int m;
            // the array of children
            public Entry[] children = new Entry[M];

            public Node(int k) {
                m = k;
            }
        }

        private class Entry {
            public K key;
            public object val;
            public Node next;

            public Entry(K key, object val, Node next) {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }

        public BinaryTreeSymbolTable() {
            root = new Node(0);
        }

        public int Count {
            get => n;
        }

        public int Height {
            get => height;
        }

        public bool isEmpty() {
            return Count == 0;
        }

        public object Get(K key) {
            if (key == null) {
                throw new ArgumentException("argument to get() is null");
            }
            return Search(root, key, height);
        }

        private object Search(Node x, K key, int height) {
            Entry[] children = x.children;

            if (height == 0) {   // external node
                for (int j = 0; j < x.m; j++) {
                    if (Eq(key, children[j].key)) {
                        return children[j].val;
                    }
                }
            } else {   // internal node
                for (int j = 0; j < x.m; j++) {
                    if (j + 1 == x.m || Less(key, children[j + 1].key)) {
                        return Search(children[j].next, key, height - 1);
                    }
                }
            }
            return null;
        }

        public void Put(K key, V val) {
            if (key == null) {
                throw new ArgumentNullException("key must not be null");
            }
            Node u = Insert(root, key, val, height);
            n++;
            if (u == null) {
                return;
            }

            // need to split root
            Node t = new Node(2);
            t.children[0] = new Entry(root.children[0].key, null, root);
            t.children[1] = new Entry(u.children[0].key, null, u);
            root = t;
            height++;
        }

        private Node Insert(Node h, K key, V val, int height) {
            int j;
            Entry t = new Entry(key, val, null);

            if (height == 0) {   // external node
                for (j = 0; j < h.m; j++) {
                    if (Less(key, h.children[j].key)) break;
                }
            } else {   // internal node
                for (j = 0; j < h.m; j++) {
                    if ((j + 1 == h.m) || Less(key, h.children[j + 1].key)) {
                        Node u = Insert(h.children[j++].next, key, val, height - 1);
                        if (u == null) {
                            return null;
                        }
                        t.key = u.children[0].key;
                        t.next = u;
                        break;
                    }
                }
            }

            for (int i = h.m; i > j; i--) {
                h.children[i] = h.children[i - 1];
            }
            h.children[j] = t;
            h.m++;
            if (h.m < M) {
                return null;
            } else {
                return split(h);
            }
        }

        // split node in half
        private Node split(Node h) {
            Node t = new Node(M / 2);
            h.m = M / 2;
            for (int j = 0; j < M / 2; j++)
                t.children[j] = h.children[M / 2 + j];
            return t;
        }

        private bool Less(K k1, K k2) {
            return k1.CompareTo(k2) < 0;
        }

        private bool Eq(K k1, K k2) {
            return k1.CompareTo(k2) == 0;
        }
    }
}
