using System.Collections.Generic;

namespace Books.Algorithms.Chap5 {
    public class TrieSymbolTable<T> {
        private static int R = 256;
        private Node root;

        private class Node {
            public T val;
            public Node[] next = new Node[R];
        }

        public int Size() {
            return Size(root);
        }

        private int Size(Node x) {
            if (x == null) {
                return 0;
            }
            int count = 0;
            if (!System.Object.Equals(x.val, default(T))) {
                count++;
            }
            for (int i = 0; i < R; i++) {
                count += Size(x.next[i]);
            }
            return count;
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
                node = default(Node);
                return false;
            }
            if (d == key.Length) {
                node = x;
                return true;
            }
            char c = key[d];
            return TryGet(x.next[c], key, d + 1, out node);
        }

        public T this[string key] {
            get {
                TryGet(key, out var val);
                return val;
            }

            set { Put(key, value); }
        }

        public void Put(string key, T val) {
            root = Put(root, key, val, 0);
        }

        private Node Put(Node x, string key, T val, int d) {
            if (x == null) {
                x = new Node();
            }
            if (d == key.Length) {
                x.val = val;
                return x;
            }
            char c = key[d];
            x.next[c] = Put(x.next[c], key, val, d + 1);
            return x;
        }

        public IEnumerable<string> Keys() {
            return KeysWithPrefix("");
        }

        public IEnumerable<string> KeysWithPrefix(string pre) {
            var q = new Queue<string>();
            TryGet(root, pre, 0, out var node);
            Collect(node, pre, q);
            return q;
        }

        public IEnumerable<string> KeysThatMatch(string pat) {
            var q = new Queue<string>();

            return q;
        }

        private void Collect(Node x, string pre, Queue<string> q) {
            if (x == null) {
                return;
            }
            if (!object.Equals(x.val, default(T))) {
                q.Enqueue(pre);
            }
            for (int i = 0; i < R; i++) {
                Collect(x.next[i], pre + (char)i, q);
            }
        }

        private void Collect(Node x, string pre, string pat, Queue<string> q) {
            int d = pre.Length;
            if (x == null) {
                return;
            }
            if (d == pat.Length && object.Equals(x.val, default(T))) {
                q.Enqueue(pre);
            }
            if (d == pat.Length) {
                return;
            }
            char next = pat[d];
            for (int i = 0; i < R; i++) {
                if (next == '.' || next == (char)i) {
                    Collect(x.next[i], pre + (char)i, pat, q);
                }
            }
        }

        public string LongestPrefixOf(string s) {
            int length = Search(root, s, 0, 0);
            return s.Substring(0, length);
        }

        private int Search(Node x, string s, int d, int length) {
            if (x == null) {
                return length;
            }
            if (!object.Equals(x.val, default(T))) {
                length = d;
            }
            if (d == s.Length) {
                return length;
            }
            char c = s[d];
            return Search(x.next[c], s, d + 1, length);
        }

        public void Delete(string key) {
            root = Delete(root, key, 0);
        }

        private Node Delete(Node x, string key, int d) {
            if (x == null) {
                return null;
            }
            if (d == key.Length) {
                x.val = default(T);
            } else {
                char c = key[d];
                x.next[c] = Delete(x.next[c], key, d + 1);
            }
            if (!object.Equals(x.val, default(T))) {
                return x;
            }
            for (int i = 0; i < R; i++) {
                if (!object.Equals(x.next[i], default(T))) {
                    return x;
                }
            }
            return null;
        }
    }
}