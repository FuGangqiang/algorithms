using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class DirectedDfs {
        private bool[] marked;

        public DirectedDfs(Digraph g, int s) {
            marked = new bool[g.Vcount];
            Dfs(g, s);
        }

        public DirectedDfs(Digraph g, IEnumerable<int> xs) {
            marked = new bool[g.Vcount];
            foreach (int v in xs) {
                if (!marked[v]) {
                    Dfs(g, v);
                }
            }
        }

        private void Dfs(Digraph g, int s) {
            marked[s] = true;
            foreach (int i in g.Adj(s)) {
                if (!marked[i]) {
                    Dfs(g, i);
                }
            }
        }

        public bool Marked(int v) {
            return marked[v];
        }
    }
}
