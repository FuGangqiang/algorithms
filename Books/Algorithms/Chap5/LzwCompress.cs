namespace Books.Algorithms.Chap5 {
    public class LZW {
        private const int R = 256;        // number of input chars
        private const int L = 4096;       // number of codewords = 2^W
        private const int W = 12;         // codeword width

        private BinaryInput input;
        private BinaryOutput output;

        public LZW(string inputFileName, string outputFileName) {
            input = new BinaryInput(inputFileName);
            output = new BinaryOutput(outputFileName);
        }

        public void Compress() {
            string inputChars = input.ReadString();
            var st = new TrieSymbolTable<int>();

            // initialize symbol table
            for (int i = 0; i < R; i++) {
                st.Put("" + (char)i, i);
            }
            int code = R + 1;  // R is codeword for EOF

            while (inputChars.Length > 0) {
                string s = st.LongestPrefixOf(inputChars);
                output.Write(st[s], W);
                int t = s.Length;
                if (t < inputChars.Length && code < L) {
                    // Add s to symbol table
                    st.Put(inputChars.Substring(0, t + 1), code++);
                }
                // Scan past s in input
                inputChars = inputChars.Substring(t);
            }
            output.Write(R, W);
            output.Close();
        }

        public void Expand() {
            string[] st = new string[L];
            int i;  // next available codeword value

            // initialize symbol table
            for (i = 0; i < R; i++) {
                st[i] = "" + (char)i;
            }
            st[i++] = "";    // (unused) lookahead for EOF

            int codeword = input.ReadInt(W);
            string val = st[codeword];

            while (true) {
                output.Write(val);
                codeword = input.ReadInt(W);
                if (codeword == R) {
                    // EOF
                    break;
                }
                string s = st[codeword];
                if (i == codeword) {
                    // If lookahead is invalid, make codeword from last one
                    s = val + val[0];
                }
                if (i < L) {
                    // Add new entry to code table
                    st[i++] = val + s[0];
                }
                val = s;
            }
            output.Close();
        }
    }
}
