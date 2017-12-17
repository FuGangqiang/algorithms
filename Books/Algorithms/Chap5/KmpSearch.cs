namespace Books.Algorithms.Chap5 {
    public class KmpSearch {
        private string pat;
        private int[] next;

        public KmpSearch(string pat) {
            this.pat = pat;
            this.next = new int[pat.Length];
            InitNext();
        }

        private void InitNext() {
            int i = 0;
            int j = -1;
            next[0] = -1;

            while (i < pat.Length - 1) {
                if (j == -1 || pat[i] == pat[j]) {
                    i++;
                    j++;
                    next[i] = j;
                } else {
                    j = next[j];
                }
            }
        }

        public int Search(string txt) {
            int i = 0;
            int j = 0;

            while (i < txt.Length && j < pat.Length) {
                if (j == -1 || txt[i] == pat[j]) {
                    i++;
                    j++;
                } else {
                    j = next[j];
                }
            }

            if (j == pat.Length) {
                return i - j;
            } else {
                return -1;
            }
        }
    }
}