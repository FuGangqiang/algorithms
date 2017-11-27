using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class Digraph {
        private readonly int vcount;
        private int ecount;
        private List<int>[] adj;

        public Digraph(int vcount) {
            this.vcount = vcount;
            this.adj = new List<int>[vcount];
            for (int i = 0; i < vcount; i++) {
                this.adj[i] = new List<int>();
            }
        }

        public int Vcount {
            get => vcount;
        }

        public int Ecount {
            get => ecount;
        }

        public void AddEdge(int v, int w) {
            adj[v].Add(w);
            ecount++;
        }

        public IEnumerable<int> Adj(int v) {
            return adj[v];
        }

        public Digraph Reverse() {
            Digraph r = new Digraph(vcount);
            for (int i = 0; i < vcount; i++) {
                foreach (int j in Adj(i)) {
                    r.AddEdge(j, i);
                }
            }
            return r;
        }
    }
}
