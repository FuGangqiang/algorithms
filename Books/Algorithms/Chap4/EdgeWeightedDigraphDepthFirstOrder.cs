using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class EdgeWeightedDigraphDepthFirstOrder {
        private bool[] marked;
        private Queue<int> pre;
        private Queue<int> post;
        private Stack<int> reversePost;

        public EdgeWeightedDigraphDepthFirstOrder(EdgeWeightedDigraph g) {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[g.Vcount];
            for (int i = 0; i < g.Vcount; i++) {
                if (!marked[i]) {
                    Dfs(g, i);
                }
            }
        }

        private void Dfs(EdgeWeightedDigraph g, int v) {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (var e in g.Adj(v)) {
                if (!marked[e.To]) {
                    Dfs(g, e.To);
                }
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> Pre() {
            return pre;
        }

        public IEnumerable<int> Post() {
            return post;
        }

        public IEnumerable<int> ReversePost() {
            return reversePost;
        }
    }
}
