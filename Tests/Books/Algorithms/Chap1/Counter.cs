using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class CounterTest {
        [Fact]
        public void IncrementTest() {
            var c1 = new Counter("c1");
            Assert.Equal(0, c1.Tally);

            for (var i = 1; i < 10; i++) {
                c1.Increment();
                Assert.Equal(i, c1.Tally);
            }
        }

        [Fact]
        public void MaxTest() {
            var x = new Counter("x");
            var y = new Counter("y");

            for (var i = 1; i < 10; i++) {
                x.Increment();
            }
            for (var i = 1; i < 5; i++) {
                y.Increment();
            }
            Assert.Equal(x, Counter.Max(x, y));
        }
    }
}
