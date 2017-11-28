using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class DepthFirstOrder {
        private bool[] marked;
        private Queue<int> pre;
        private Queue<int> post;
        private Stack<int> reversePost;

        public DepthFirstOrder(Digraph g) {
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

        private void Dfs(Digraph g, int v) {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (int i in g.Adj(v)) {
                if (!marked[i]) {
                    Dfs(g, i);
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
