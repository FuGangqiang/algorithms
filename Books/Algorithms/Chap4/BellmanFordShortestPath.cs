using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    // todo: unfinished
    public class BellmanFordShortestPath {
        private double[] distTo;
        private DirectedEdge[] edgeTo;
        private bool[] onQueue;
        private Queue<int> queue;
        private int cost;
        private IEnumerable<int> cycle;

        public BellmanFordShortestPath(EdgeWeightedDigraph g, int s) {
            distTo = new double[g.Vcount];
            edgeTo = new DirectedEdge[g.Vcount];
            onQueue = new bool[g.Vcount];
            queue = new Queue<int>();
            for (int i = 0; i < g.Vcount; i++) {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[s] = 0.0;
            queue.Enqueue(s);
            onQueue[s] = true;
            while (queue.Count != 0 && !hasNegativeCycle()) {
                int v = queue.Dequeue();
                onQueue[v] = false;
                Relax(g, v);
            }
        }

        private void Relax(EdgeWeightedDigraph g, int v) {
            foreach (var e in g.Adj(v)) {
                int w = e.To;
                if (distTo[w] > distTo[v] + e.Weight) {
                    distTo[w] = distTo[v] + e.Weight;
                    edgeTo[w] = e;
                    if (!onQueue[w]) {
                        queue.Enqueue(w);
                        onQueue[w] = true;
                    }
                }
                if (cost++ % g.Vcount == 0) {
                    findNegativeCycle();
                }
            }
        }

        private void findNegativeCycle() {
            int vcount = edgeTo.Length;
            var spt = new EdgeWeightedDigraph(vcount);
            for (int i = 0; i < vcount; i++) {
                if (edgeTo[i] != null) {
                    spt.AddEdge(edgeTo[i]);
                }
            }
            var cf = new EdgeWeightedDirectedCycle(spt);
            cycle = cf.GetCycle();
        }

        public bool hasNegativeCycle() {
            return cycle != null;
        }

        public IEnumerable<int> NegativeCycle() {
            return cycle;
        }
    }
}
