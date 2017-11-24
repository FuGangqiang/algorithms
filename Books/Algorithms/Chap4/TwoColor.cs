namespace Books.Algorithms.Chap4 {
    public class TwoColor {
        private bool[] marked;
        private bool[] color;
        private bool isTwoColorable = true;

        public TwoColor(Graph g) {
            marked = new bool[g.Vcount];
            color = new bool[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                if (!marked[i]) {
                    Dfs(g, i);
                }
            }
        }

        private void Dfs(Graph g, int v) {
            marked[v] = true;
            foreach (int i in g.Adj(v)) {
                if (!marked[i]) {
                    color[i] = !color[v];
                    Dfs(g, i);
                } else if (color[i] == color[v]) {
                    isTwoColorable = false;
                }
            }
        }

        public bool IsBipartite() {
            return isTwoColorable;
        }
    }
}
