using System;

namespace Books.Algorithms.Chap1 {
    public class Queue<T> {
        private Node first;
        private Node last;
        private int size;

        private class Node {
            public T Item;
            public Node Next;
        }

        public int Size {
            get => size;
        }

        public bool IsEmpty() {
            return size == 0;
        }

        public void Enqueue(T item) {
            var node = new Node();
            node.Item = item;
            if (IsEmpty()) {
                first = node;
                last = node;
            } else {
                last.Next = node;
                last = node;
            }
            size++;
        }

        public T Dequeue() {
            if (IsEmpty()) {
                throw new Exception("Empty Queue");
            }
            size--;
            var node = first;
            if (IsEmpty()) {
                first = null;
                last = null;
            } else {
                first = first.Next;
            }
            return node.Item;
        }
    }
}
