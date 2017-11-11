using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class BinarySearchTest {
        [Fact]
        public void RankTest() {
            var a = new int[] { 1, 3, 5, 7, 9 };
            Assert.Equal(3, BinarySearch.Rank(7, a));
            Assert.Equal(-1, BinarySearch.Rank(4, a));
        }
    }
}
