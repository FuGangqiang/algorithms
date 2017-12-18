namespace Books.Algorithms.Chap5 {
    public class BoyerMooreSearch {
        private readonly int R = 256;
        private int[] badChar;
        private string pat;

        public BoyerMooreSearch(string pat) {
            this.pat = pat;
            badChar = new int[R];
            InitBadChar();
        }

        private void InitBadChar() {
            int M = pat.Length;
            for (int i = 0; i < R; i++) {
                badChar[i] = -1;
            }
            for (int i = 0; i < M; i++) {
                badChar[pat[i]] = i;
            }
        }

        public int Search(string txt) {
            int N = txt.Length;
            int M = pat.Length;
            int skip;
            for (int i = 0; i <= N - M; i += skip) {
                skip = 0;
                for (int j = M - 1; j >= 0; j--) {
                    if (pat[j] != txt[i + j]) {
                        skip = j - badChar[txt[i + j]];
                        if (skip < 1) {
                            skip = 1;
                        }
                        break;
                    }
                }
                if (skip == 0) {
                    return i;
                }
            }
            return -1;
        }
    }
}