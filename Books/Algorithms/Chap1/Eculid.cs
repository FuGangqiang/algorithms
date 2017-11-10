namespace Books.Algorithms.Chap1 {
    public class Eculid {
        public static int Gcd(int p, int q) {
            if (q == 0) {
                return p;
            }
            int r = p % q;
            return Gcd(q, r);
        }
    }
}
