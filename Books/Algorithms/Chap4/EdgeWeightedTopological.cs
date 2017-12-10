using System.Collections.Generic;

namespace Books.Algorithms.Chap4 {
    public class EdgeWeightedTopological {
        private IEnumerable<int> order;

        public EdgeWeightedTopological(EdgeWeightedDigraph g) {
            var cycleFinder = new EdgeWeightedDirectedCycle(g);
            if (!cycleFinder.HasCycle()) {
                var dfs = new EdgeWeightedDigraphDepthFirstOrder(g);
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