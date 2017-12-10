using System;
using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class DirectedEdge : IEquatable<DirectedEdge> {
        private readonly int v;
        private readonly int w;
        private readonly double weight;

        public DirectedEdge(int v, int w, double weight) {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight {
            get => weight;
        }

        public int From {
            get => v;
        }

        public int To {
            get => w;
        }

        public override string ToString() {
            return $"{v}->{w} {weight}";
        }

        public bool Equals(DirectedEdge other) {
            if (other == null) {
                return false;
            }
            return v == other.v && w == other.w && weight == other.weight;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            return Equals(obj as DirectedEdge);
        }

        public override int GetHashCode() {
            return (v + w + weight).GetHashCode();
        }
    }

    public class EdgeWeightedDigraph {
        private readonly int vcount;
        private int ecount;
        private List<DirectedEdge>[] adj;

        public EdgeWeightedDigraph(int vcount) {
            this.vcount = vcount;
            this.adj = new List<DirectedEdge>[vcount];
            for (int i = 0; i < vcount; i++) {
                this.adj[i] = new List<DirectedEdge>();
            }
        }

        public int Vcount {
            get => vcount;
        }

        public int Ecount {
            get => ecount;
        }

        public void AddEdge(DirectedEdge e) {
            adj[e.From].Add(e);
            ecount++;
        }

        public IEnumerable<DirectedEdge> Adj(int v) {
            return adj[v];
        }

        public IEnumerable<DirectedEdge> Edges() {
            var es = new List<DirectedEdge>();
            for (int i = 0; i < vcount; i++) {
                foreach (var e in adj[i]) {
                    es.Add(e);
                }
            }
            return es;
        }
    }
}