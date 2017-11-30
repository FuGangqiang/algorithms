namespace Books.Algorithms.Chap4 {
    public class TransitiveClosure {
        private DirectedDfs[] all;

        public TransitiveClosure(Digraph g) {
            all = new DirectedDfs[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                all[i] = new DirectedDfs(g, i);
            }
        }

        public bool Reachable(int v, int w) {
            return all[v].Marked(w);
        }
    }
}
