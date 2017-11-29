namespace Books.Algorithms.Chap4 {
    public class KosarajuStrongConnectedComponents {
        private bool[] marked;
        private int[] id;
        private int count;

        public KosarajuStrongConnectedComponents(Digraph g) {
            marked = new bool[g.Vcount];
            id = new int[g.Vcount];
            var order = new DepthFirstOrder(g.Reverse());
            foreach (var i in order.ReversePost()) {
                if (!marked[i]) {
                    Dfs(g, i);
                    count++;
                }
            }
        }

        private void Dfs(Digraph g, int v) {
            marked[v] = true;
            id[v] = count;
            foreach (int w in g.Adj(v)) {
                if (!marked[w]) {
                    Dfs(g, w);
                }
            }
        }

        public bool StrongConnected(int v, int w) {
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
