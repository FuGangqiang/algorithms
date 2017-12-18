namespace Books.Algorithms.Chap5 {
    public class KmpDfaSearch {
        private readonly int R = 256;
        private string pat;
        private int[,] dfa;

        public KmpDfaSearch(string pat) {
            this.pat = pat;
            int M = pat.Length;
            dfa = new int[R, M];
            dfa[pat[0], 0] = 1;
            for (int x = 0, j = 1; j < M; j++) {
                for (int c = 0; c < R; c++) {
                    dfa[c, j] = dfa[c, x];
                }
                dfa[pat[j], j] = j + 1;
                x = dfa[pat[j], x];
            }
        }

        public int Search(string txt) {
            int N = txt.Length;
            int M = pat.Length;
            int i;
            int j;
            for (i = 0, j = 0; i < N && j < M; i++) {
                j = dfa[txt[i], j];
            }
            if (j == M) {
                return i - M;
            } else {
                return N;
            }
        }
    }
}