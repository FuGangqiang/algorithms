using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class DirectedCycle {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;

        public DirectedCycle(Digraph g) {
            onStack = new bool[g.Vcount];
            edgeTo = new int[g.Vcount];
            marked = new bool[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                if (!marked[i]) {
                    Dfs(g, i);
                }
            }
        }

        private void Dfs(Digraph g, int v) {
            marked[v] = true;
            onStack[v] = true;
            foreach (int i in g.Adj(v)) {
                if (HasCycle()) {
                    return;
                } else if (!marked[i]) {
                    edgeTo[i] = v;
                    Dfs(g, i);
                } else if (onStack[i]) {    
                    cycle = new Stack<int>();
                    for (int j = v; j != i; j = edgeTo[j]) {
                        cycle.Push(j);
                    }
                    cycle.Push(i);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }

        public bool HasCycle() {
            return cycle != null;
        }

        public IEnumerable<int> Cycle() {
            return cycle;
        }
    }
}
