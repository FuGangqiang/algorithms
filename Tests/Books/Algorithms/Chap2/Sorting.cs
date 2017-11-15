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
    }
}
