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

        [Fact]
        public void DfsCountTest() {
            var g = GraphSample();
            var dfs = new DepthFirstSearch(g, 0);
            Assert.Equal(6, dfs.Count);
        }

        [Fact]
        public void DfsPathToTest() {
            var g = GraphSample();
            var dfs = new DepthFirstPaths(g, 0);
            Assert.True(dfs.HasPathTo(5));
            var path = dfs.PathTo(5);
            int[] result = { 5, 3, 2, 0 };
            int i = 0;
            foreach (int v in path) {
                Assert.Equal(result[i], v);
                i++;
            }
        }

        [Fact]
        public void BreadthFirstPathsTest() {
            var g = GraphSample();
            var bfs = new BreadthFirstPaths(g, 0);
            Assert.True(bfs.HasPathTo(5));
            var path = bfs.PathTo(5);
            int[] result = { 5, 0 };
            int i = 0;
            foreach (int v in path) {
                Assert.Equal(result[i], v);
                i++;
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ConnectedComponentTest(int v) {
            var g = GraphSample();
            var dfs = new ConnectedComponent(g);
            Assert.Equal(1, dfs.Count);
            Assert.True(dfs.Connected(0, v));

        }

        [Fact]
        public void CycleTest() {
            var g = GraphSample();
            var dfs = new Cycle(g);
            Assert.True(dfs.HasCycle());
        }

        [Fact]
        public void TwoColorTest() {
            var g = GraphSample();
            var dfs = new TwoColor(g);
            Assert.False(dfs.IsBipartite());
        }

        public Digraph DigraphSample() {
            var g = new Digraph(13);
            g.AddEdge(4, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 2);
            g.AddEdge(6, 0);
            g.AddEdge(0, 1);
            g.AddEdge(2, 0);
            g.AddEdge(11, 12);
            g.AddEdge(12, 9);
            g.AddEdge(9, 10);
            g.AddEdge(9, 11);
            g.AddEdge(8, 9);
            g.AddEdge(10, 12);
            g.AddEdge(11, 4);
            g.AddEdge(4, 3);
            g.AddEdge(3, 5);
            g.AddEdge(7, 8);
            g.AddEdge(8, 7);
            g.AddEdge(5, 4);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);
            g.AddEdge(6, 9);
            g.AddEdge(7, 6);
            return g;
        }

        [Fact]
        public void DiGraphCountTest() {
            var g = DigraphSample();
            Assert.Equal(13, g.Vcount);
            Assert.Equal(22, g.Ecount);
        }
    }
}
