using Xunit;
using Books.Algorithms.Chap4;

namespace Tests.Books.Algorithms.Chap4 {
    public class GraphTest {
        public Graph GraphSample() {
            var g = new Graph(6);
            g.AddEdge(0, 5);
            g.AddEdge(2, 4);
            g.AddEdge(2, 3);
            g.AddEdge(1, 2);
            g.AddEdge(0, 1);
            g.AddEdge(3, 4);
            g.AddEdge(3, 5);
            g.AddEdge(0, 2);
            return g;
        }

        [Fact]
        public void GraphCountTest() {
            var g = GraphSample();
            Assert.Equal(6, g.Vcount);
            Assert.Equal(8, g.Ecount);
        }
    }
}
