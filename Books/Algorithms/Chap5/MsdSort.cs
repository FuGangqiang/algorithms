namespace Books.Algorithms.Chap5 {
    public class Msd {
        private static int R = 256;
        private static string[] aux;

        private static int CharAt(string s, int i) {
            if (i < s.Length) {
                return s[i];
            } else {
                return -1;
            }
        }

        public static void Sort(string[] a) {
            int N = a.Length;
            aux = new string[N];
            Sort(a, 0, N - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d) {
            if (lo >= hi) {
                // when hi < lo + M
                // use Insertion Sort
                return;
            }
            int[] count = new int[R + 2];
            for (int i = lo; i <= hi; i++) {
                count[CharAt(a[i], d) + 2]++;
            }
            for (int r = 0; r < R + 1; r++) {
                count[r + 1] += count[r];
            }
            for (int i = lo; i <= hi; i++) {
                aux[count[CharAt(a[i], d) + 1]++] = a[i];
            }
            for (int i = lo; i <= hi; i++) {
                a[i] = aux[i - lo];
            }
            for (int r = 0; r < R; r++) {
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
            }
        }
    }
}