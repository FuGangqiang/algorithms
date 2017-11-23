namespace Books.Algorithms.Chap4 {
    public class DepthFirstSearch {
        private bool[] marked;
        private int count;

        public DepthFirstSearch(Graph g, int s) {
            marked = new bool[g.Vcount];
            Dfs(g, s);
        }

        public int Count {
            get => count;
        }

        public void Dfs(Graph g, int v) {
            marked[v] = true;
            count++;
            foreach (int i in g.Adj(v)) {
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
