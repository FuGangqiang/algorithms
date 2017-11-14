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
    }
}
