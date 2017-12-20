using System;
using System.Collections.Generic;
using Books.Algorithms.Chap4;

namespace Books.Algorithms.Chap5 {
    public class NFA {
        private char[] re;
        private int M;
        private Digraph g;

        public NFA(string regexp) {
            var ops = new Stack<int>();
            re = regexp.ToCharArray();
            M = re.Length;
            g = new Digraph(M + 1);

            for (int i = 0; i < M; i++) {
                int lp = i;
                if (re[i] == '(' || re[i] == '|') {
                    ops.Push(i);
                } else if (re[i] == ')') {
                    int or = ops.Pop();
                    if (re[or] == '|') {
                        lp = ops.Pop();
                        g.AddEdge(lp, or + 1);
                        g.AddEdge(or, i);
                    } else {
                        lp = or;
                    }
                }
                if (i < M - 1 && re[i + 1] == '*') {
                    g.AddEdge(lp, i + 1);
                    g.AddEdge(i + 1, lp);
                }
                if (re[i] == '(' || re[i] == '*' || re[i] == ')') {
                    g.AddEdge(i, i + 1);
                }
            }
        }

        public bool Recognizes(string txt) {
            var pc = new List<int>();
            var dfs = new DirectedDfs(g, 0);
            for (int v = 0; v < g.Vcount; v++) {
                if (dfs.Marked(v)) {
                    // here should filter metachar out
                    pc.Add(v);
                }
            }
            for (int i = 0; i < txt.Length; i++) {
                var match = new List<int>();
                foreach (int v in pc) {
                    if (v < M) {
                        if (re[v] == txt[i] || re[v] == '.') {
                            match.Add(v + 1);
                        }
                    }
                }
                pc = new List<int>();
                dfs = new DirectedDfs(g, match);
                for (int v = 0; v < g.Vcount; v++) {
                    if (dfs.Marked(v)) {
                        // here should filter metachar out
                        pc.Add(v);
                    }
                }
            }
            foreach (int v in pc) {
                if (v == M) {
                    return true;
                }
            }
            return false;
        }
    }
}