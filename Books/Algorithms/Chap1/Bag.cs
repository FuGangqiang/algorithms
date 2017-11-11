using System.Collections;
using System.Collections.Generic;

namespace Books.Algorithms.Chap1 {
    public class Bag<T> : IEnumerable<T> {
        private T[] bag;
        private int size;

        public Bag(int cap) {
            bag = new T[cap];
        }

        public int Size {
            get => size;
        }

        public void Add(T item) {
            if (size == bag.Length) {
                Reszie(size * 2);
            }
            bag[size] = item;
            size++;
        }

        public bool IsEmpty() {
            return size == 0;
        }

        private void Reszie(int max) {
            T[] temp = new T[max];
            System.Array.Copy(bag, temp, bag.Length);
            bag = temp;
        }

        public IEnumerator<T> GetEnumerator() {
            return new BagEnumerator<T>(bag);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }

    class BagEnumerator<T> : IEnumerator<T> {
        private T[] _bag;
        private int _current;

        public BagEnumerator(T[] bag) {
            _bag = bag;
        }

        public T Current {
            get => _bag[_current];
        }

        object IEnumerator.Current {
            get => Current;
        }

        public bool MoveNext() {
            _current++;
            if (_current == _bag.Length) {
                return true;
            } else {
                return false;
            }
        }

        public void Reset() {
            _current = 0;
        }

        public void Dispose() { }

    }
}
