using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class BagTest {
        [Fact]
        public void IsEmptyTest() {
            var bag = new Bag<int>(1);
            Assert.True(bag.IsEmpty());
        }

        [Fact]
        public void SizeTest() {
            var bag = new Bag<int>(1);
            Assert.Equal(0, bag.Size);
            for (var i = 1; i < 10; i++) {
                bag.Add(1);
                Assert.Equal(i, bag.Size);
            }
        }

        [Fact]
        public void EnumeratorTest() {
            var bag = new Bag<int>(10);
            for (var i = 0; i < 10; i++) {
                bag.Add(i);
            }

            var j = 0;
            foreach (var item in bag) {
                Assert.Equal(j, item);
                j++;
            }
        }

    }
}
