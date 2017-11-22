using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class Graph {
        private readonly int vcount;
        private int ecount;
        private List<int>[] adj;

        public Graph(int vertices_count) {
            this.vcount = vertices_count;
            this.ecount = 0;
            this.adj = new List<int>[vertices_count];
            for (int i = 0; i < vertices_count; i++) {
                adj[i] = new List<int>();
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
            adj[w].Add(v);
            ecount++;
        }

        public IEnumerable<int> Adj(int v) {
            return adj[v];
        }

        public static int Degree(Graph g, int v) {
            int degree = 0;
            foreach (int i in g.Adj(v)) {
                degree++;
            }
            return degree;
        }

        public static int MaxDegree(Graph g) {
            int max = 0;
            for (int i = 0; i < g.Vcount; i++) {
                if (Degree(g, i) > max) {
                    max = Degree(g, i);
                }
            }
            return max;
        }

        public static int AvgDegree(Graph g) {
            return 2 * g.Ecount / g.Vcount;
        }

        public static int NumberOfSelfLoops(Graph g) {
            int count = 0;
            for (int i = 0; i < g.Vcount; i++) {
                foreach (int j in g.Adj(i)) {
                    if (i == j) {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
