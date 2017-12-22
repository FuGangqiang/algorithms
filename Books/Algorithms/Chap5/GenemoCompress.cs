using System.IO;
using System.Text;

namespace Books.Algorithms.Chap5 {
    public class Genome {
        private BinaryInput input;
        private BinaryOutput output;

        public Genome(string inputFileName, string outputFileName) {
            input = new BinaryInput(inputFileName);
            output = new BinaryOutput(outputFileName);
        }

        public void Compress() {
            string s = input.ReadString();
            int N = s.Length;
            output.Write(N);

            // Write two-bit code for char.
            for (int i = 0; i < N; i++) {
                int d = Alphabet.Dna.ToIndex(s[i]);
                output.Write(d, 2);
            }
            output.Close();
            input.Close();
        }

        public void Expand() {
            int N = input.ReadInt();
            // Read two bits; write char.
            for (int i = 0; i < N; i++) {
                char c = input.ReadChar(2);
                output.Write(Alphabet.Dna.ToChar(c), 8);
            }
            output.Close();
            input.Close();
        }
    }
}
