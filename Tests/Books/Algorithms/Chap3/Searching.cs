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

        [Fact]
        public void BinarySearchTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new BinarySearchSymbolTable<int, int>(xs.Length);
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

        [Fact]
        public void BinarySearchTreeTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new BinarySearchTreeSymbolTable<int, int>();
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

        [Fact]
        public void RedBlackTreeTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new RedBlackTree<int, int>();
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

        [Fact]
        public void SeparateChainingHashSymbolTableTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new SeparateChainingHashSymbolTable<int, int>();
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

        [Fact]
        public void LinearProbingHashSymbolTableTest() {
            int[] xs = { 3, 4, 5, 2, 6 };
            var st = new LinearProbingHashSymbolTable<int, int>(xs.Length * 2);
            for (int i = 1; i <= xs.Length; i++) {
		// can not use index 0! default(int) == 0
                st.Put(i, xs[i-1]);
            }
            int v;
            for (int i = 1; i <= xs.Length; i++) {
                if (st.TryGet(i, out v)) {
                    Assert.Equal(xs[i-1], v);
                } else {
                    Assert.False(true);
                }
            }
        }

    }
}
