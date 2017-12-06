using System.Collections.Generic;
using Books.Algorithms.Chap2;

namespace Books.Algorithms.Chap4 {
    public class KruskalMinimumSpanTree {
        private List<Edge> mst;

        public KruskalMinimumSpanTree(EdgeWeightedGraph g) {
            mst = new List<Edge>();
            var pq = new MinPriorityQueue<Edge>(g.Ecount);
	    foreach(var e in g.Edges()) {
		pq.Insert(e);
	    }
            var uf = new UF(g.Vcount);
            while (!pq.IsEmpty() && mst.Count < g.Vcount - 1) {
                var e = pq.DelMin();
                int v = e.Either;
                int w = e.Other(v);
                if (uf.Connected(v, w)) {
                    continue;
                }
		uf.Union(v, w);
                mst.Add(e);
            }
        }

        public IEnumerable<Edge> Edges() {
            return mst;
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
