namespace Books.Algorithms.Chap4 {
    public class ConnectedComponent {
        private bool[] marked;
        private int[] id;
        private int count;

        public ConnectedComponent(Graph g) {
            marked = new bool[g.Vcount];
            id = new int[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                if (!marked[i]) {
                    Dfs(g, i);
                    count++;
                }
            }
        }

        private void Dfs(Graph g, int v) {
            marked[v] = true;
            id[v] = count;
            foreach (int i in g.Adj(v)) {
                if (!marked[i]) {
                    Dfs(g, i);
                }
            }
        }

        public bool Connected(int v, int w) {
            return id[v] == id[w];
        }

        public int Id(int v) {
            return id[v];
        }

        public int Count {
            get => count;
        }
    }
}
