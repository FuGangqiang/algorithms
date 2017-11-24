namespace Books.Algorithms.Chap4 {
    public class Cycle {
        private bool[] marked;
        private bool hasCycle;

        public Cycle(Graph g) {
            marked = new bool[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                if (!(marked[i])) {
                    Dfs(g, i, i);
                }
            }
        }

        private void Dfs(Graph g, int v, int u) {
            marked[v] = true;
            foreach (int i in g.Adj(v)) {
                if (!marked[i]) {
                    Dfs(g, i, v);
                } else if (i != u) {
                    hasCycle = true;
                }
            }
        }

        public bool HasCycle() {
            return hasCycle;
        }
    }
}
