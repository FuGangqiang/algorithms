using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class AccumulatorTest {
        [Fact]
        public void MeanTest() {
            var a = new Accumulator();
            double total = 0;
            a.AddDataValue(1.2);
            total += 1.2;
            a.AddDataValue(1.5);
            total += 1.5;
            Assert.Equal(total / 2, a.Mean);
        }
    }
}
