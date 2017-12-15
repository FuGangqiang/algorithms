namespace Books.Algorithms.Chap5 {
    public class Quick3String {
        private static int CharAt(string s, int i) {
            if (i < s.Length) {
                return s[i];
            } else {
                return -1;
            }
        }

        public static void Sort(string[] a) {
            Sort(a, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d) {
            if (lo >= hi) {
                // when hi < lo + M
                // use Insertion Sort
                return;
            }
            int lt = lo;
            int gt = hi;
            int v = CharAt(a[lo], d);
            int i = lo + 1;
            while (i <= gt) {
                int t = CharAt(a[i], d);
                if (t < v) {
                    Exchange(a, lt++, i++);
                } else if (t > v) {
                    Exchange(a, i, gt--);
                } else {
                    i++;
                }
            }
            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]
            Sort(a, lo, lt - 1, d);
            if (v >= 0) {
                Sort(a, lt, gt, d + 1);
            }
            Sort(a, gt + 1, hi, d);
        }

        public static void Exchange(string[] xs, int i, int j) {
            string temp = xs[i];
            xs[i] = xs[j];
            xs[j] = temp;
        }
    }
}
