using System.Collections.Generic;
using Books.Algorithms.Chap2;

namespace Books.Algorithms.Chap4 {
    public class DijkstraShortestPath {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        private IndexMinPriorityQueue<double> pq;

        public DijkstraShortestPath(EdgeWeightedDigraph g, int s) {
            edgeTo = new DirectedEdge[g.Vcount];
            distTo = new double[g.Vcount];
            pq = new IndexMinPriorityQueue<double>(g.Vcount);

            for (int i = 0; i < g.Vcount; i++) {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[0] = 0.0;
            pq.Insert(s, 0.0);
            while (!pq.IsEmpty()) {
                Relax(g, pq.DelMin());
            }
        }

        private void Relax(EdgeWeightedDigraph g, int v) {
            foreach (var e in g.Adj(v)) {
                int w = e.To;
                if (distTo[w] > distTo[v] + e.Weight) {
                    distTo[w] = distTo[v] + e.Weight;
                    edgeTo[w] = e;
                    if (pq.Contains(w)) {
                        pq.ChangeKey(w, distTo[w]);
                    } else {
                        pq.Insert(w, distTo[w]);
                    }
                }
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

    public class DijkstraAllPairsShortestPath {
        private DijkstraShortestPath[] all;

        public DijkstraAllPairsShortestPath(EdgeWeightedDigraph g) {
            all = new DijkstraShortestPath[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                all[i] = new DijkstraShortestPath(g, i);
            }
        }

        public IEnumerable<DirectedEdge> Path(int s, int t) {
            return all[s].PathTo(t);
        }

        public double Dist(int s, int t) {
            return all[s].DistTo(t);
        }
    }
}
