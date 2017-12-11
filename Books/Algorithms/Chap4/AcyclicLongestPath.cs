using System;
using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class AcyclicLongestPath {
        private double[] distTo;
        private DirectedEdge[] edgeTo;

        public AcyclicLongestPath(EdgeWeightedDigraph g, int s) {
            distTo = new double[g.Vcount];
            edgeTo = new DirectedEdge[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                distTo[i] = double.NegativeInfinity;
            }
            distTo[s] = 0.0;
            var topo = new EdgeWeightedTopological(g);
            if (!topo.IsDAG()) {
                throw new ArgumentException("Digraph is not acyclic");
            }
            foreach (int i in topo.Order()) {
                foreach (var e in g.Adj(i)) {
                    Relax(e);
                }
            }
        }

        private void Relax(DirectedEdge e) {
            int v = e.From;
            int w = e.To;
            if (distTo[w] < distTo[v] + e.Weight) {
                distTo[w] = distTo[v] + e.Weight;
                edgeTo[w] = e;
            }
        }

        public double DistTo(int v) {
            return distTo[v];
        }

        public bool HasPathTo(int v) {
            return distTo[v] > double.NegativeInfinity;
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
