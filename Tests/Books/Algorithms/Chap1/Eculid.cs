using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class EculidTest {
        [Fact]
        public void GcdTest() {
            Assert.Equal(4, Eculid.Gcd(8, 12));
        }
    }
}
