using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class QueueTest {
        [Fact]
        public void IsEmptyTest() {
            var queue = new Queue<int>();
            Assert.True(queue.IsEmpty());
            queue.Enqueue(1);
            Assert.False(queue.IsEmpty());
        }

        [Fact]
        public void SizeTest() {
            var queue = new Queue<int>();
            Assert.Equal(0, queue.Size);
            for (var i = 1; i < 10; i++) {
                queue.Enqueue(i);
                Assert.Equal(i, queue.Size);
            }
        }

        [Fact]
        public void EnDequeueTest() {
            var queue = new Queue<int>();
            int size = 10;
            for (var i = 0; i < size; i++) {
                queue.Enqueue(i);
            }
            for (var j = 0; j < size; j++) {
                Assert.Equal(j, queue.Dequeue());
            }
            Assert.True(queue.IsEmpty());
        }
    }
}
