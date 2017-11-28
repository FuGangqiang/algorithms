using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class Topological {
        private IEnumerable<int> order;

        public Topological(Digraph g) {
            var cycleFinder = new DirectedCycle(g);
            if (!cycleFinder.HasCycle()) {
                var dfs = new DepthFirstOrder(g);
                order = dfs.ReversePost();
            }
        }

        public IEnumerable<int> Order() {
            return order;
        }

        public bool IsDAG() {
            return order != null;
        }
    }
}
