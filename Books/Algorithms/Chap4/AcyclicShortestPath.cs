using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class AcyclicShortestPath {
        private DirectedEdge[] edgeTo;
        private double[] distTo;

        public AcyclicShortestPath(EdgeWeightedDigraph g, int s) {
            edgeTo = new DirectedEdge[g.Vcount];
            distTo = new double[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[s] = 0.0;
            var topo = new EdgeWeightedTopological(g);
            foreach (int v in topo.Order()) {
                foreach (var e in g.Adj(v)) {
                    Relax(e);
                }
            }
        }

        private void Relax(DirectedEdge e) {
            int v = e.From;
            int w = e.To;
            if (distTo[w] > distTo[v] + e.Weight) {
                distTo[w] = distTo[v] + e.Weight;
                edgeTo[w] = e;
            }
        }

        public double DistTo(int v) {
            return distTo[v];
        }

        public bool HasPathTo(int v) {
            return distTo[v] < double.PositiveInfinity;
        }

        public IEnumerable<DirectedEdge> PathTo(int v) {
            if (!HasPathTo(v)) {
                return null;
            }
            var path = new Stack<DirectedEdge>();
            for (var e = edgeTo[v]; e != null; e = edgeTo[e.From]) {
                path.Push(e);
            }
            return path;
        }
    }
}
