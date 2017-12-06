using System;

namespace Books.Algorithms.Chap4 {
    public class UF {
        private int[] parent;
        private byte[] rank;
        private int count;

        public UF(int N) {
            if (N < 0) throw new ArgumentException();
            count = N;
            parent = new int[N];
            rank = new byte[N];
            for (int i = 0; i < N; i++) {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int p) {
            validate(p);
            while (p != parent[p]) {
                parent[p] = parent[parent[p]];
                p = parent[p];
            }
            return p;
        }

        public int Count {
            get { return count; }
        }

        public bool Connected(int p, int q) {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q) {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;

            if (rank[rootP] < rank[rootQ]) parent[rootP] = rootQ;
            else if (rank[rootP] > rank[rootQ]) parent[rootQ] = rootP;
            else {
                parent[rootQ] = rootP;
                rank[rootP]++;
            }
            count--;
        }

        private void validate(int p) {
            int N = parent.Length;
            if (p < 0 || p >= N) {
                throw new IndexOutOfRangeException("index " + p + " is not between 0 and " + (N - 1));
            }
        }
    }
}
