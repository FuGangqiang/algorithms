using System;

namespace Books.Algorithms.Chap1 {
    public class Stack<T> {
        private T[] stack;
        private int size;

        public Stack() {
            stack = new T[8];
        }

        public int Size {
            get => size;
        }

        public void Push(T item) {
            if (size == stack.Length) {
                Resize(size * 2);
            }
            stack[size] = item;
            size++;
        }

        public T Pop() {
            if (size == 0) {
                throw new InvalidOperationException("Empty Stack");
            } else {
                size--;
                if (size + 1 < stack.Length) {
                    stack[size + 1] = default(T);
                }
                if (size < stack.Length / 4) {
                    Resize(stack.Length / 2);
                }
                return stack[size];
            }
        }

        public bool IsEmpty() {
            return size == 0;
        }

        private void Resize(int max) {
            int size = max > stack.Length ? stack.Length : max;
            T[] temp = new T[max];
            System.Array.Copy(stack, temp, size);
            stack = temp;
        }
    }
}
