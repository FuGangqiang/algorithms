using System;
using System.IO;
using System.Text;

namespace Books.Algorithms.Chap5 {
    public sealed class BinaryInput : IDisposable {
        private BinaryReader input;
        private const int EOF = -1;
        private int buffer;           // one byte buffer
        private int n;                // number of bits left in buffer
        private bool disposed = false;

        public BinaryInput(string inputFileName = "") {
            if (inputFileName.Equals("")) {
                input = new BinaryReader(Console.OpenStandardInput());
            } else {
                try {
                    input = new BinaryReader(File.OpenRead(inputFileName));
                } catch (Exception e) {
                    throw new IOException(string.Format("BinaryInput error {0}", e.Message));
                }
            }
            FillBuffer();
        }

        private void FillBuffer() {
            try {
                buffer = input.ReadByte();
                n = (buffer == EOF) ? -1 : 8;
            } catch (IOException) {
                buffer = EOF;
                n = -1;
            }
        }

        public void Close() {
            try {
                input.Close();
            } catch (IOException e) {
                throw new IOException(string.Format("BinaryInput error {0}", e.Message));
            }
        }

        public bool IsEmpty {
            get { return buffer == EOF; }
        }

        public bool ReadBoolean() {
            if (IsEmpty) {
                throw new IOException("Reading from empty input stream");
            }
            n--;
            bool bit = ((buffer >> n) & 1) == 1;
            if (n == 0) {
                FillBuffer();
            }
            return bit;
        }

        public char ReadChar() {
            if (IsEmpty) {
                throw new IOException("Reading from empty input stream");
            }

            // special case when aligned byte
            int x = default(int);
            if (n == 8) {
                x = buffer;
                FillBuffer();
                return (char)(x & 0xff);
            }

            // combine last n bits of current buffer with first 8-n bits of new buffer
            x = buffer;
            x <<= (8 - n);
            int oldN = n;
            FillBuffer();
            if (IsEmpty) {
                throw new IOException("Reading from empty input stream");
            }
            n = oldN;
            x |= (buffer >> n);
            return (char)(x & 0xff);
            // the above code doesn't quite work for the last character if n = 8
            // because buffer will be -1, so there is a special case for aligned byte
        }

        public char ReadChar(int r) {
            if (r < 1 || r > 16) {
                throw new ArgumentException("Illegal value of r = " + r);
            }

            if (r == 8) {
                return ReadChar();
            }

            int x = 0;
            for (int i = 0; i < r; i++) {
                x <<= 1;
                bool bit = ReadBoolean();
                if (bit) x |= 1;
            }
            return (char)(x & 0xffff);
        }

        public string ReadString() {
            // Debug 16-bit char behavior in .NET
            if (IsEmpty) {
                throw new IOException("Reading from empty input stream");
            }

            var sb = new StringBuilder();
            while (!IsEmpty) {
                char c = ReadChar();
                sb.Append(c);
            }
            return sb.ToString();
        }

        public short ReadShort() {
            int x = 0;
            for (int i = 0; i < 2; i++) {
                int c = ReadChar();
                x <<= 8;
                x |= c;
            }
            return (short)x;
        }

        public int ReadInt() {
            int x = 0;
            for (int i = 0; i < 4; i++) {
                char c = ReadChar();
                x <<= 8;
                x |= c;
            }
            return x;
        }

        public int ReadInt(int r) {
            if (r < 1 || r > 32) {
                throw new ArgumentException("Illegal value of r = " + r);
            }

            if (r == 32) {
                return ReadInt();
            }

            int x = 0;
            for (int i = 0; i < r; i++) {
                x <<= 1;
                bool bit = ReadBoolean();
                if (bit) {
                    x |= 1;
                }
            }
            return x;
        }

        public long ReadLong() {
            long x = 0;
            for (int i = 0; i < 8; i++) {
                char c = ReadChar();
                x <<= 8;
                x |= c;
            }
            return x;
        }

        public double ReadDouble() {
            long bit64 = ReadLong();
            return BitConverter.Int64BitsToDouble(bit64);
        }

        public static float ReadFloat() {
            throw new NotImplementedException("ReadFloat to be implemented");
        }

        public byte ReadByte() {
            char c = ReadChar();
            byte x = (byte)(c & 0xff);
            return x;
        }

        public void Dispose() {
            DisposeIt(true);
            GC.SuppressFinalize(this);
        }

        void DisposeIt(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    input.Dispose();
                }
                disposed = true;
            }
        }

        ~BinaryInput() {
            DisposeIt(false);
        }
    }
}