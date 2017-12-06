using System.Collections.Generic;
using Books.Algorithms.Chap2;

namespace Books.Algorithms.Chap4 {
    public class PrimMinimumSpanTree {
        private Edge[] edgeTo;
        private double[] distTo;
        private bool[] marked;
        private IndexMinPriorityQueue<double> pq;

        public PrimMinimumSpanTree(EdgeWeightedGraph g) {
            edgeTo = new Edge[g.Vcount];
            distTo = new double[g.Vcount];
            marked = new bool[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                distTo[i] = double.PositiveInfinity;
            }
            pq = new IndexMinPriorityQueue<double>(g.Vcount);
            distTo[0] = 0.0;
            pq.Insert(0, 0.0);
            while (!pq.IsEmpty()) {
                Visit(g, pq.DelMin());
            }
        }

        private void Visit(EdgeWeightedGraph g, int v) {
            marked[v] = true;
            foreach (var e in g.Adj(v)) {
                int w = e.Other(v);
                if (marked[w]) {
                    continue;
                }
                if (e.Weight < distTo[w]) {
                    edgeTo[w] = e;
                    distTo[w] = e.Weight;
                    if (pq.Contains(w)) {
                        pq.ChangeKey(w, distTo[w]);
                    } else {
                        pq.Insert(w, distTo[w]);
                    }
                }
            }
        }

        public IEnumerable<Edge> Edges() {
	    var edges = new List<Edge>();
	    for(int i=0; i<edgeTo.Length; i++) {
		var e = edgeTo[i];
		if(e != null) {
		    edges.Add(e);
		}
	    }
	    return edges;
        }

        public double Weight() {
            double weight = 0;
            foreach (var e in Edges()) {
                weight += e.Weight;
            }
            return weight;
        }
    }
}
