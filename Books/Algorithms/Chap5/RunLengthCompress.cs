using System.Text;

namespace Books.Algorithms.Chap5 {
    public sealed class RunLength {
        private const int R = 256;
        private const int LG_R = 8;
        private BinaryInput input;
        private BinaryOutput output;

        public RunLength(string inputFileName, string outputFileName) {
            input = new BinaryInput(inputFileName);
            output = new BinaryOutput(outputFileName);
        }

        public void Compress() {
            int run = 0;
            bool old = false;
            while (!input.IsEmpty) {
                bool b = input.ReadBoolean();
                if (b != old) {
                    output.Write(run, LG_R);
                    run = 1;
                    old = !old;
                } else {
                    if (run == R - 1) {
                        output.Write(run, LG_R);
                        run = 0;
                        output.Write(run, LG_R);
                    }
                    run++;
                }
            }
            output.Write(run, LG_R);
            output.Close();
        }

        public void Expand() {
            bool b = false;
            while (!input.IsEmpty) {
                int run = input.ReadInt(LG_R);
                for (int i = 0; i < run; i++)
                    output.Write(b);
                b = !b;
            }
            output.Close();
        }
    }
}