using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class BreadthFirstPaths {
        private bool[] marked;
        private int[] edgeTo;
        private readonly int s;

        public BreadthFirstPaths(Graph g, int s) {
            this.marked = new bool[g.Vcount];
            this.edgeTo = new int[g.Vcount];
            this.s = s;
            Bfs(g, s);
        }

        private void Bfs(Graph g, int s) {
            Queue<int> queue = new Queue<int>();
            marked[s] = true;
            queue.Enqueue(s);
            while (queue.Count != 0) {
                int v = queue.Dequeue();
                foreach (int w in g.Adj(v)) {
                    if (!marked[w]) {
                        edgeTo[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
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
