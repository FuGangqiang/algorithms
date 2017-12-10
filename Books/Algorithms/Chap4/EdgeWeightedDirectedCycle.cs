using System;
using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class EdgeWeightedDirectedCycle {
        private bool[] marked;
        private DirectedEdge[] edgeTo;
        private Stack<int> cycle;
        private bool[] onStack;

        public EdgeWeightedDirectedCycle(EdgeWeightedDigraph g) {
            marked = new bool[g.Vcount];
            onStack = new bool[g.Vcount];
            edgeTo = new DirectedEdge[g.Vcount];
            for (int i = 0; i < g.Vcount; i++)
                if (!marked[i]) {
                    Dfs(g, i);
                }
        }

        private void Dfs(EdgeWeightedDigraph g, int v) {
            marked[v] = true;
            onStack[v] = true;
            foreach (var e in g.Adj(v)) {
                int w = e.To;
                if (HasCycle()) {
                    return;
                } else if (!marked[w]) {
                    edgeTo[w] = e;
                    Dfs(g, w);
                } else if (onStack[w]) {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x].To) {
                        cycle.Push(x);
                    }
                    cycle.Push(w);
                    cycle.Push(v);
                }
            }
            onStack[v] = false;
        }

        public bool HasCycle() {
            return cycle != null;
        }

        public IEnumerable<int> GetCycle() {
            return cycle;
        }
    }
}