namespace Books.Algorithms.Chap5 {
    public class BruteForceSearch {
        public static int Search(string pat, string txt) {
            int M = pat.Length;
            int N = txt.Length;
            for (int i = 0; i < N - M; i++) {
                int j;
                for (j = 0; j < M; j++) {
                    if (txt[i + j] != pat[j]) {
                        break;
                    }
                }
                if (j == M) {
                    return i;
                }
            }
            return N;
        }
    }
}