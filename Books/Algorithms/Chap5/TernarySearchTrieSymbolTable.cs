namespace Books.Algorithms.Chap5 {
    public class TernarySearchTrieSymbolTable<T> {
        private Node root;

        private class Node {
            public char c;
            public Node left;
            public Node mid;
            public Node right;
            public T val;
        }

        public bool TryGet(string key, out T val) {
            if (TryGet(root, key, 0, out var node)) {
                val = node.val;
                return true;
            } else {
                val = default(T);
                return false;
            }
        }

        private bool TryGet(Node x, string key, int d, out Node node) {
            if (x == null) {
                node = null;
                return false;
            }
            char c = key[d];
            if (c < x.c) {
                return TryGet(x.left, key, d, out node);
            } else if (c > x.c) {
                return TryGet(x.right, key, d, out node);
            } else if (d < key.Length - 1) {
                return TryGet(x.mid, key, d + 1, out node);
            } else {
                node = x;
                return true;
            }
        }

        public void Put(string key, T val) {
            root = Put(root, key, val, 0);
        }

        private Node Put(Node x, string key, T val, int d) {
            char c = key[d];
            if (x == null) {
                x = new Node();
                x.c = c;
            }
            if (c < x.c) {
                x.left = Put(x.left, key, val, d);
            } else if (c > x.c) {
                x.right = Put(x.right, key, val, d);
            } else if (d < key.Length - 1) {
                x.mid = Put(x.mid, key, val, d + 1);
            } else {
                x.val = val;
            }
            return x;
        }
    }
}