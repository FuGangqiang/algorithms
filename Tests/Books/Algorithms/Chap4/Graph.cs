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

        [Fact]
        void DigraphDfsTest() {
            var g = DigraphSample();
            var dfs = new DirectedDfs(g, 0);
            Assert.True(dfs.Marked(1));
            Assert.True(dfs.Marked(2));
            Assert.False(dfs.Marked(6));
        }

        [Fact]
        public void DirectedCycleTest() {
            var g = DigraphSample();
            var dfs = new DirectedCycle(g);
            Assert.True(dfs.HasCycle());
        }

        public Digraph DagSample() {
            var g = new Digraph(13);
            g.AddEdge(2, 3);
            g.AddEdge(0, 6);
            g.AddEdge(0, 1);
            g.AddEdge(2, 0);
            g.AddEdge(11, 12);
            g.AddEdge(9, 12);
            g.AddEdge(9, 10);
            g.AddEdge(9, 11);
            g.AddEdge(3, 5);
            g.AddEdge(8, 7);
            g.AddEdge(5, 4);
            g.AddEdge(0, 5);
            g.AddEdge(6, 4);
            g.AddEdge(6, 9);
            g.AddEdge(7, 6);
            return g;
        }

        [Fact]
        public void TopologicalTest() {
            var g = DagSample();
            var topo = new Topological(g);
            Assert.True(topo.IsDAG());
            var result = new int[] { 8, 7, 2, 3, 0, 5, 1, 6, 9, 11, 10, 12, 4 };
            int i = 0;
            foreach (var v in topo.Order()) {
                Assert.Equal(v, result[i]);
                i++;
            }
        }

        [Fact]
        public void KosarajuStrongConnectedComponentsTest() {
            var g = DigraphSample();
            var kcc = new KosarajuStrongConnectedComponents(g);
            Assert.True(kcc.StrongConnected(0, 4));
            Assert.False(kcc.StrongConnected(1, 4));
            Assert.True(kcc.StrongConnected(10, 11));
            Assert.False(kcc.StrongConnected(6, 8));
        }

        [Fact]
        public void TransitiveClosureTest() {
            var g = DigraphSample();
            var tc = new TransitiveClosure(g);
            Assert.True(tc.Reachable(0, 2));
            Assert.False(tc.Reachable(9, 6));
        }

        public EdgeWeightedGraph EdgeWeightGraphSample() {
            var ewg = new EdgeWeightedGraph(8);
            ewg.AddEdge(new Edge(4, 5, 0.35));
            ewg.AddEdge(new Edge(4, 7, 0.37));
            ewg.AddEdge(new Edge(5, 7, 0.28));
            ewg.AddEdge(new Edge(0, 7, 0.16));
            ewg.AddEdge(new Edge(1, 5, 0.32));
            ewg.AddEdge(new Edge(0, 4, 0.38));
            ewg.AddEdge(new Edge(2, 3, 0.17));
            ewg.AddEdge(new Edge(1, 7, 0.19));
            ewg.AddEdge(new Edge(0, 2, 0.26));
            ewg.AddEdge(new Edge(1, 2, 0.36));
            ewg.AddEdge(new Edge(1, 3, 0.29));
            ewg.AddEdge(new Edge(2, 7, 0.34));
            ewg.AddEdge(new Edge(6, 2, 0.40));
            ewg.AddEdge(new Edge(3, 6, 0.52));
            ewg.AddEdge(new Edge(6, 0, 0.58));
            ewg.AddEdge(new Edge(6, 4, 0.93));
            return ewg;
        }

        [Fact]
        public void EdgeWeightGraphTest() {
            var ewg = EdgeWeightGraphSample();
            Assert.Equal(8, ewg.Vcount);
            Assert.Equal(16, ewg.Ecount);
        }

        [Fact]
        public void LazyPrimMinimumSpanTreeTest() {
            var ewg = EdgeWeightGraphSample();
            var mst = new LazyPrimMinimumSpanTree(ewg);
            var result = new[] { new Edge(0, 7, 0.16), new Edge(1, 7, 0.19), new Edge(0, 2, 0.26), new Edge(2, 3, 0.17), new Edge(5, 7, 0.28), new Edge(4, 5, 0.35), new Edge(6, 2, 0.40) };
            int i = 0;
            foreach (var e in mst.Edges()) {
                Assert.Equal(result[i], e);
                i++;
            }
            Assert.Equal(1.81, mst.Weight(), 2);
        }

        [Fact]
        public void PrimMinimumSpanTreeTest() {
            var ewg = EdgeWeightGraphSample();
            var mst = new PrimMinimumSpanTree(ewg);
            var result = new[] { new Edge(1, 7, 0.19), new Edge(0, 2, 0.26), new Edge(2, 3, 0.17), new Edge(4, 5, 0.35), new Edge(5, 7, 0.28), new Edge(6, 2, 0.40), new Edge(0, 7, 0.16) };
            int i = 0;
            foreach (var e in mst.Edges()) {
                Assert.Equal(result[i], e);
                i++;
            }
            Assert.Equal(1.81, mst.Weight(), 2);
        }

        [Fact]
        public void KruskalMinimumSpanTreeTest() {
            var ewg = EdgeWeightGraphSample();
            var mst = new KruskalMinimumSpanTree(ewg);
            var result = new[] { new Edge(0, 7, 0.16), new Edge(2, 3, 0.17), new Edge(1, 7, 0.19), new Edge(0, 2, 0.26), new Edge(5, 7, 0.28), new Edge(4, 5, 0.35), new Edge(6, 2, 0.40) };
            int i = 0;
            foreach (var e in mst.Edges()) {
                Assert.Equal(result[i], e);
                i++;
            }
            Assert.Equal(1.81, mst.Weight(), 2);
        }

        public EdgeWeightedDigraph EdgeWeightedDigraphSample() {
            var ewdg = new EdgeWeightedDigraph(8);
            ewdg.AddEdge(new DirectedEdge(4, 5, 0.35));
            ewdg.AddEdge(new DirectedEdge(5, 4, 0.35));
            ewdg.AddEdge(new DirectedEdge(4, 7, 0.37));
            ewdg.AddEdge(new DirectedEdge(5, 7, 0.28));
            ewdg.AddEdge(new DirectedEdge(7, 5, 0.28));
            ewdg.AddEdge(new DirectedEdge(5, 1, 0.32));
            ewdg.AddEdge(new DirectedEdge(0, 4, 0.38));
            ewdg.AddEdge(new DirectedEdge(0, 2, 0.26));
            ewdg.AddEdge(new DirectedEdge(7, 3, 0.39));
            ewdg.AddEdge(new DirectedEdge(1, 3, 0.29));
            ewdg.AddEdge(new DirectedEdge(2, 7, 0.34));
            ewdg.AddEdge(new DirectedEdge(6, 2, 0.40));
            ewdg.AddEdge(new DirectedEdge(3, 6, 0.52));
            ewdg.AddEdge(new DirectedEdge(6, 0, 0.58));
            ewdg.AddEdge(new DirectedEdge(6, 4, 0.93));
            return ewdg;
        }

        [Fact]
        public void EdgeWeightedDigraphTest() {
            var ewdg = EdgeWeightedDigraphSample();
            Assert.Equal(8, ewdg.Vcount);
            Assert.Equal(15, ewdg.Ecount);
        }

        [Fact]
        public void DijkstraShortestPathTest() {
            var dg = EdgeWeightedDigraphSample();
            var sp = new DijkstraShortestPath(dg, 0);
            var es = new DirectedEdge[] {
                new DirectedEdge(0, 2, 0.26),
                new DirectedEdge(2, 7, 0.34),
                new DirectedEdge(7, 3, 0.39),
                new DirectedEdge(3, 6, 0.52),
            };
            int i = 0;
            foreach (var e in sp.PathTo(6)) {
                Assert.Equal(e, es[i]);
                i++;
            }
            Assert.Equal(1.51, sp.DistTo(6), 2);
        }

        public EdgeWeightedDigraph EdgeWeightedDagSample() {
            var dg = new EdgeWeightedDigraph(8);
            dg.AddEdge(new DirectedEdge(5, 4, 0.35));
            dg.AddEdge(new DirectedEdge(4, 7, 0.37));
            dg.AddEdge(new DirectedEdge(5, 7, 0.28));
            dg.AddEdge(new DirectedEdge(5, 1, 0.32));
            dg.AddEdge(new DirectedEdge(4, 0, 0.38));
            dg.AddEdge(new DirectedEdge(0, 2, 0.26));
            dg.AddEdge(new DirectedEdge(3, 7, 0.39));
            dg.AddEdge(new DirectedEdge(1, 3, 0.29));
            dg.AddEdge(new DirectedEdge(7, 2, 0.34));
            dg.AddEdge(new DirectedEdge(6, 2, 0.40));
            dg.AddEdge(new DirectedEdge(3, 6, 0.52));
            dg.AddEdge(new DirectedEdge(6, 0, 0.58));
            dg.AddEdge(new DirectedEdge(6, 4, 0.93));
            return dg;
        }

        [Fact]
        public void AcyclicShortestPathTest() {
            var dg = EdgeWeightedDagSample();
            var sp = new AcyclicShortestPath(dg, 5);
            var es = new DirectedEdge[] {
                new DirectedEdge(5, 1, 0.32),
                new DirectedEdge(1, 3, 0.29),
                new DirectedEdge(3, 6, 0.52),
            };
            int i = 0;
            foreach (var e in sp.PathTo(6)) {
                Assert.Equal(e, es[i]);
                i++;
            }
            Assert.Equal(1.13, sp.DistTo(6), 2);
        }
    }
}
