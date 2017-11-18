using Xunit;
using Books.Algorithms.Chap3;

namespace Tests.Books.Algorithms.Chap3 {
    public class SearchTest {
        [Fact]
        public void SequentialSearchTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new SequentialSearchSymbolTable<int, int>();
            for (int i = 0; i < xs.Length; i++) {
                st.Put(i, xs[i]);
            }
            int v;
            for (int i = 0; i < xs.Length; i++) {
                if (st.TryGet(i, out v)) {
                    Assert.Equal(xs[i], v);
                } else {
                    Assert.False(true);
                }
            }
        }
    }
}