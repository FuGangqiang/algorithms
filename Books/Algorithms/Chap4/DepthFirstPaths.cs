using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class DepthFirstPaths {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;

        public DepthFirstPaths(Graph g, int s) {
            this.marked = new bool[g.Vcount];
            this.edgeTo = new int[g.Vcount];
            this.s = s;
            Dfs(g, s);
        }

        private void Dfs(Graph g, int v) {
            marked[v] = true;
            foreach (int i in g.Adj(v)) {
                if (!marked[i]) {
                    edgeTo[i] = v;
                    Dfs(g, i);
                }
            }
        }

        public bool HasPathTo(int v) {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v) {
            if (!HasPathTo(v)) {
                return null;
            }
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x]) {
                path.Push(x);
            }
            return path;
        }
    }
}
