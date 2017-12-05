using System.Collections.Generic;
using Books.Algorithms.Chap2;

namespace Books.Algorithms.Chap4 {
    public class LazyPrimMinimumSpanTree {
        private bool[] marked;
        private Queue<Edge> mst;
        private MinPriorityQueue<Edge> pq;

        public LazyPrimMinimumSpanTree(EdgeWeightedGraph g) {
            pq = new MinPriorityQueue<Edge>(g.Ecount);
            marked = new bool[g.Vcount];
            mst = new Queue<Edge>();
            Visit(g, 0);
            while (!pq.IsEmpty()) {
                var e = pq.DelMin();
                int v = e.Either;
                int w = e.Other(v);
                if (marked[v] && marked[w]) {
                    continue;
                }
                mst.Enqueue(e);
                if (!marked[v]) {
                    Visit(g, v);
                }
                if (!marked[w]) {
                    Visit(g, w);
                }
            }
        }

        private void Visit(EdgeWeightedGraph g, int v) {
            marked[v] = true;
            foreach (var e in g.Adj(v)) {
                if (!marked[e.Other(v)]) {
                    pq.Insert(e);
                }
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
