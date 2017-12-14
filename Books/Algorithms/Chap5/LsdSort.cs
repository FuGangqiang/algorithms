namespace Books.Algorithms.Chap5 {
    public class Lsd {
        public static void Sort(string[] a, int width) {
            int N = a.Length;
            int R = 256;
            var aux = new string[N];

            for (int d = width - 1; d >= 0; d--) {
                var count = new int[R + 1];
                for (int i = 0; i < N; i++) {
                    count[a[i][d] + 1]++;
                }
                for (int r = 0; r < R; r++) {
                    count[r + 1] += count[r];
                }
                for (int i = 0; i < N; i++) {
                    aux[count[a[i][d]]++] = a[i];
                }
                for (int i = 0; i < N; i++) {
                    a[i] = aux[i];
                }
            }
        }
    }
}