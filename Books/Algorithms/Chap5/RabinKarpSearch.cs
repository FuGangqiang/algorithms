using System;

namespace Books.Algorithms.Chap5 {
    public class RabinKarpSearch {
        private string pat;
        private long patHash;
        private int M;
        private long Q;   // a large prime
        private int R = 256;
        private long RM;  // R^(M-1) % Q

        public RabinKarpSearch(string pat) {
            this.pat = pat;
            M = pat.Length;
            Q = longRandomPrime();
            RM = 1;
            for (int i = 1; i <= M - 1; i++) {
                RM = (R * RM) % Q;
            }
            patHash = Hash(pat, M);
        }

        private static long longRandomPrime() {
            long[] largePrimes = { 5915587277, 1500450271, 3267000013, 5754853343, 4093082899, 9576890767, 3628273133, 2860486313, 5463458053, 3367900313 };
            Random rnd = new Random();
            return largePrimes[rnd.Next() % largePrimes.Length];
        }

        private bool Check(string txt, int offset) {
            for (int i = 0; i < M; i++) {
                if (pat[i] != txt[offset + i]) {
                    return false;
                }
            }
            return true;
        }

        private long Hash(string key, int M) {
            long h = 0;
            for (int i = 0; i < M; i++) {
                h = (R * h + key[i]) % Q;
            }
            return h;
        }

        public int Search(string txt) {
            int N = txt.Length;
            if (N < M) {
                return -1;
            }
            long txtHash = Hash(txt, M);
            if (patHash == txtHash && Check(txt, 0)) {
                return 0;
            }
            for (int i = M; i < N; i++) {
                // Remove leading digit, add trailing digit, check for match
                txtHash = (txtHash + Q - RM * txt[i - M] % Q) % Q;
                txtHash = (txtHash * R + txt[i]) % Q;

                int offset = i - M + 1;
                if (patHash == txtHash && Check(txt, offset)) {
                    if (Check(txt, offset)) {
                        return offset;
                    }
                }
            }
            return -1;
        }
    }
}