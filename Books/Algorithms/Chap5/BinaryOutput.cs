using System;
using System.IO;
using System.Diagnostics;

namespace Books.Algorithms.Chap5 {
    public sealed class BinaryOutput {
        private BinaryWriter output;
        private static int buffer;     // 8-bit buffer of bits to write out
        private static int n;          // number of bits remaining in buffer

        public BinaryOutput(string outputFileName) {
            try {
                output = new BinaryWriter(File.Create(outputFileName));
            } catch (Exception e) {
                throw new IOException(string.Format("BinaryOutput error {0}", e.Message));
            }
        }

        private void WriteBit(bool bit) {
            buffer <<= 1;
            if (bit) {
                buffer |= 1;
            }
            n++;
            if (n == 8) {
                ClearBuffer();
            }
        }

        private void WriteByte(int x) {
            Debug.Assert(x >= 0 && x < 256);

            if (n == 0) {
                try {
                    output.Write((byte)x);
                } catch (IOException e) {
                    throw new IOException(string.Format("BinaryOutput error {0}", e.Message));
                }
                return;
            }
            for (int i = 0; i < 8; i++) {
                bool bit = ((x >> (8 - i - 1)) & 1) == 1;
                WriteBit(bit);
            }
        }

        private void ClearBuffer() {
            if (n == 0) {
                return;
            }
            if (n > 0) {
                buffer <<= (8 - n);
            }
            try {
                output.Write((byte)buffer);
            } catch (IOException e) {
                throw new IOException(string.Format("BinaryOutput error {0}", e.Message));
            }
            n = 0;
            buffer = 0;
        }

        public void Flush() {
            ClearBuffer();
            try {
                output.Flush();
            } catch (IOException e) {
                throw new IOException(string.Format("BinaryOutput error {0}", e.Message));
            }
        }

        public void Close() {
            Flush();
            try {
                output.Close();
            } catch (IOException e) {
                throw new IOException(string.Format("BinaryOutput error {0}", e.Message));
            }
        }

        public void Write(bool x) {
            WriteBit(x);
        }

        public void Write(byte x) {
            WriteByte(x & 0xff);
        }

        public void Write(int x) {
            WriteByte((x >> 24) & 0xff);
            WriteByte((x >> 16) & 0xff);
            WriteByte((x >> 8) & 0xff);
            WriteByte((x >> 0) & 0xff);
        }

        public void Write(int x, int r) {
            if (r == 32) {
                Write(x);
                return;
            }
            if (r < 1 || r > 32) {
                throw new ArgumentException("Illegal value for r = " + r);
            }
            if (x < 0 || x >= (1 << r)) {
                throw new ArgumentException("Illegal " + r + "-bit char = " + x);
            }
            for (int i = 0; i < r; i++) {
                bool bit = ((x >> (r - i - 1)) & 1) == 1;
                WriteBit(bit);
            }
        }

        public void Write(double x) {
            Write(BitConverter.DoubleToInt64Bits(x));
        }

        public void Write(long x) {
            WriteByte((int)((x >> 56) & 0xff));
            WriteByte((int)((x >> 48) & 0xff));
            WriteByte((int)((x >> 40) & 0xff));
            WriteByte((int)((x >> 32) & 0xff));
            WriteByte((int)((x >> 24) & 0xff));
            WriteByte((int)((x >> 16) & 0xff));
            WriteByte((int)((x >> 8) & 0xff));
            WriteByte((int)((x >> 0) & 0xff));
        }

        public void Write(float x) {
            throw new NotImplementedException("Write float not yet implemented");
        }

        public void Write(short x) {
            WriteByte((x >> 8) & 0xff);
            WriteByte((x >> 0) & 0xff);
        }

        public void Write(char x) {
            if (x < 0 || x >= 256) {
                throw new ArgumentException("Illegal 8-bit char = " + x);
            }
            WriteByte(x);
        }

        public void Write(char x, int r) {
            if (r == 8) {
                Write(x);
                return;
            }
            if (r < 1 || r > 16) {
                throw new ArgumentException("Illegal value for r = " + r);
            }
            if (x >= (1 << r)) {
                throw new ArgumentException("Illegal " + r + "-bit char = " + x);
            }
            for (int i = 0; i < r; i++) {
                bool bit = ((x >> (r - i - 1)) & 1) == 1;
                WriteBit(bit);
            }
        }

        public void Write(string s) {
            for (int i = 0; i < s.Length; i++) {
                Write(s[i]);
            }
        }

        public void Write(string s, int r) {
            for (int i = 0; i < s.Length; i++) {
                Write(s[i], r);
            }
        }
    }
}