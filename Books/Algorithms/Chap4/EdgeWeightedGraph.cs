using System;
using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class Edge : IComparable<Edge> {
        private readonly int v;
        private readonly int w;
        private readonly double weight;

        public Edge(int v, int w, double weight) {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight {
            get => weight;
        }

        public int Either {
            get => v;
        }

        public int Other(int vertex) {
            if (vertex == v) {
                return w;
            } else if (vertex == w) {
                return v;
            } else {
                throw new InvalidOperationException("Inconsistent edge");
            }
        }

        public int CompareTo(Edge that) {
            if (that == null) {
                return 1;
            }
            return this.Weight.CompareTo(that.Weight);
        }

        public static bool operator >(Edge e1, Edge e2) {
            return e1.CompareTo(e2) == 1;
        }

        public static bool operator <(Edge e1, Edge e2) {
            return e1.CompareTo(e2) == -1;
        }

        public static bool operator >=(Edge e1, Edge e2) {
            return e1.CompareTo(e2) >= 0;
        }

        public static bool operator <=(Edge e1, Edge e2) {
            return e1.CompareTo(e2) <= 0;
        }

        public override string ToString() {
            return $"{v}-{w} {weight}";
        }
    }

    public class EdgeWeightedGraph {
        private readonly int vcount;
        private int ecount;
        private List<Edge>[] adj;

        public EdgeWeightedGraph(int vcount) {
            this.vcount = vcount;
            this.adj = new List<Edge>[vcount];
            for (int i = 0; i < vcount; i++) {
                this.adj[i] = new List<Edge>();
            }
        }

        public int Vcount {
            get => vcount;
        }

        public int Ecount {
            get => ecount;
        }

        public void AddEdge(Edge e) {
            int v = e.Either;
            int w = e.Other(v);
            adj[v].Add(e);
            adj[w].Add(e);
            ecount++;
        }

        public IEnumerable<Edge> Adj(int v) {
            return adj[v];
        }

        public IEnumerable<Edge> Edges() {
            var es = new List<Edge>();
            for (int i = 0; i < vcount; i++) {
                foreach (var e in adj[i]) {
                    if (e.Other(i) > i) {
                        es.Add(e);
                    }
                }
            }
            return es;
        }
    }
}
