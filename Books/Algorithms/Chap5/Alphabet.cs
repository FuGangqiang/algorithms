using System;
using System.Text;

namespace Books.Algorithms.Chap5 {
    public class Alphabet {
        public static readonly Alphabet Binary = new Alphabet("01");
        public static readonly Alphabet Octal = new Alphabet("01234567");
        public static readonly Alphabet Decimal = new Alphabet("0123456789");
        public static readonly Alphabet Hexadecimal = new Alphabet("0123456789ABCDEF");
        public static readonly Alphabet Dna = new Alphabet("ACTG");
        public static readonly Alphabet LowerCase = new Alphabet("abcdefghijklmnopqrstuvwxyz");
        public static readonly Alphabet UpperCase = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        public static readonly Alphabet Protein = new Alphabet("ACDEFGHIKLMNPQRSTVWY");
        public static readonly Alphabet Base64 = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/");
        public static readonly Alphabet Ascii = new Alphabet(128);
        public static readonly Alphabet ExtendedAscii = new Alphabet(256);
        public static readonly Alphabet Unicode16 = new Alphabet(65536);

        private char[] alphabet;
        private int[] inverse;
        private int radix;

        public Alphabet(string alpha) {
            bool[] unicode = new bool[char.MaxValue];
            for (int i = 0; i < alpha.Length; i++) {
                char c = alpha[i];
                if (unicode[c]) {
                    throw new ArgumentException("Illegal alphabet: repeated character = '" + c + "'");
                }
                unicode[c] = true;
            }

            alphabet = alpha.ToCharArray();
            radix = alpha.Length;
            inverse = new int[char.MaxValue];
            for (int i = 0; i < inverse.Length; i++) {
                inverse[i] = -1;
            }
            for (int i = 0; i < radix; i++) {
                inverse[alphabet[i]] = i;
            }
        }

        private Alphabet(int R) {
            alphabet = new char[R];
            inverse = new int[R];
            radix = R;

            for (int i = 0; i < R; i++) {
                alphabet[i] = (char)i;
            }
            for (int i = 0; i < R; i++) {
                inverse[i] = i;
            }
        }

        public Alphabet() : this(256) {
        }

        public bool Contains(char c) {
            return inverse[c] != -1;
        }

        public int Radix {
            get { return radix; }
        }

        public int LgR {
            get {
                int lgR = 0;
                for (int t = radix - 1; t >= 1; t /= 2) {
                    lgR++;
                }
                return lgR;
            }
        }

        public int ToIndex(char c) {
            if (c >= inverse.Length || inverse[c] == -1) {
                throw new ArgumentException("Character " + c + " not in alphabet");
            }
            return inverse[c];
        }

        public int[] ToIndices(string s) {
            char[] source = s.ToCharArray();
            int[] target = new int[s.Length];
            for (int i = 0; i < source.Length; i++) {
                target[i] = ToIndex(source[i]);
            }
            return target;
        }

        public char ToChar(int index) {
            if (index < 0 || index >= radix) {
                throw new IndexOutOfRangeException("Alphabet index out of bounds");
            }
            return alphabet[index];
        }

        public string ToChars(int[] indices) {
            var s = new StringBuilder(indices.Length);
            for (int i = 0; i < indices.Length; i++) {
                s.Append(ToChar(indices[i]));
            }
            return s.ToString();
        }
    }
}
