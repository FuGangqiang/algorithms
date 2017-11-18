using System;
using Xunit;
using Books.Algorithms.Chap2;

namespace Tests.Books.Algorithms.Chap2 {
    public class SortingTest {
        [Fact]
        public void SelectionTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Selection<int>.Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void InsertionTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Insertion<int>.Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void ShellTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Shell<int>.Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void RecursiveMergingTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            var ms = new Merging<int>();
            ms.RecurisiveSort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void IterativeMergingTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            var ms = new Merging<int>();
            ms.IterativeSort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void SimpleQuickTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Quick<int>.SimpleSort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void Improved1QuickTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Quick<int>.Improved1Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void Improved2QuickTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Quick<int>.Improved2Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void BubbleSortTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Bubble<int>.Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }

        [Fact]
        public void MaxPriorityQueueTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            var queue = new MaxPriorityQueue<int>(xs.Length);
            for (int i = 0; i < xs.Length; i++) {
                queue.Insert(xs[i]);
            }
            Quick<int>.SimpleSort(xs);
            for (int i = xs.Length - 1; i > 0; i--) {
                int v = queue.DelMax();
                Assert.Equal(v, xs[i]);
            }
        }

        [Fact]
        public void MinPriorityQueueTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            var queue = new MinPriorityQueue<int>(xs.Length);
            for (int i = 0; i < xs.Length; i++) {
                queue.Insert(xs[i]);
            }
            Quick<int>.SimpleSort(xs);
            for (int i = 0; i < xs.Length; i++) {
                int v = queue.DelMin();
                Assert.Equal(v, xs[i]);
            }
        }

        [Fact]
        public void IndexMinPrivorityQueueTest() {
            string[] strings1 = { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };
            string[] strings2 = new string[strings1.Length];
            Array.Copy(strings1, strings2, strings1.Length);
            var queue = new IndexMinPriorityQueue<string>(strings1.Length);
            for (int i = 0; i < strings1.Length; i++) {
                queue.Insert(i, strings1[i]);
            }
            Quick<string>.SimpleSort(strings2);
            for (int i = 0; i < strings1.Length; i++) {
                int index = queue.DelMin();
                Assert.Equal(strings1[index], strings2[i]);
            }
        }

        [Fact]
        public void HeapTest() {
            int[] xs = { 3, 2, 1, 6, 5, 9, 4 };
            Heap<int>.Sort(xs);
            Assert.True(Sorting<int>.IsSorted(xs));
        }
    }
}
