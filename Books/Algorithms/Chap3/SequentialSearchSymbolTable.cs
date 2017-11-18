namespace Books.Algorithms.Chap3 {
    public class SequentialSearchSymbolTable<K, V> {
        private Node first;

        private class Node {
            public K Key;
            public V Value;
            public Node Next;
            public Node(K key, V value, Node next) {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        public bool TryGet(K key, out V value) {
            for (Node x = first; x != null; x = x.Next) {
                if (key.Equals(x.Key)) {
                    value = x.Value;
                    return true;
                }
            }
            value = default(V);
            return false;
        }

        public void Put(K key, V value) {
            for (Node x = first; x != null; x = x.Next) {
                if (key.Equals(x.Key)) {
                    x.Value = value;
                    return;
                }
            }
            first = new Node(key, value, first);
        }
    }
}
