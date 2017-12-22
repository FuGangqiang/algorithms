using System;
using Books.Algorithms.Chap2;

namespace Books.Algorithms.Chap5 {
    public class HuffmanCommpress {
        private const char ONE = '\u0001';
        private const char ZERO = '\u0000';
        private const int R = 256;

        private BinaryInput input;
        private BinaryOutput output;

        public HuffmanCommpress(string inputFileName, string outputFileName) {
            input = new BinaryInput(inputFileName);
            output = new BinaryOutput(outputFileName);
        }

        private class Node : IComparable<Node> {
            public char ch;
            public int freq;
            public readonly Node left;
            public readonly Node right;

            public Node(char ch, int freq, Node left, Node right) {
                this.ch = ch;
                this.freq = freq;
                this.left = left;
                this.right = right;
            }

            public bool IsLeaf {
                get => left == null && right == null;
            }

            public int CompareTo(Node other) {
                if (other == null) {
                    return 1;
                }
                return this.freq.CompareTo(other.freq);
            }
        }

        public void Compress() {
            var s = input.ReadString();
            var inputChars = s.ToCharArray();

            int[] freq = new int[R];
            for (int i = 0; i < inputChars.Length; i++) {
                freq[inputChars[i]]++;
            }

            var root = BuildTrie(freq);
            var st = new string[R];
            BuildCode(st, root, "");
            WriteTrie(root);
            output.Write(inputChars.Length);

            for (int i = 0; i < inputChars.Length; i++) {
                var code = st[inputChars[i]];
                for (int j = 0; j < code.Length; j++) {
                    if (code[j] == '0') {
                        output.Write(false);
                    } else if (code[j] == '1') {
                        output.Write(true);
                    } else {
                        throw new InvalidOperationException("Illegal state");
                    }
                }
            }
            output.Close();
        }

        public void Expand() {
            var root = ReadTrie();
            int length = input.ReadInt();
            for (int i = 0; i < length; i++) {
                var x = root;
                while (!x.IsLeaf) {
                    bool bit = input.ReadBoolean();
                    if (bit) {
                        x = x.right;
                    } else {
                        x = x.left;
                    }
                }
                output.Write(x.ch, 8);
            }
            output.Close();
        }

        private static Node BuildTrie(int[] freq) {
            var pq = new MinPriorityQueue<Node>(freq.Length);
            for (int i = 0; i < R; i++) {
                if (freq[i] > 0) {
                    pq.Insert(new Node((char)i, freq[i], null, null));
                }
            }

            // special case in case there is only one character with a nonzero frequency
            if (pq.Size == 1) {
                if (freq[ZERO] == 0) {
                    pq.Insert(new Node(ZERO, 0, null, null));
                } else {
                    pq.Insert(new Node(ONE, 0, null, null));
                }
            }

            while (pq.Size > 1) {
                var left = pq.DelMin();
                var right = pq.DelMin();
                var parent = new Node(ZERO, left.freq + right.freq, left, right);
                pq.Insert(parent);
            }
            return pq.DelMin();
        }

        private static void BuildCode(string[] st, Node x, string s) {
            if (!x.IsLeaf) {
                BuildCode(st, x.left, s + '0');
                BuildCode(st, x.right, s + '1');
            } else {
                st[x.ch] = s;
            }
        }

        private void WriteTrie(Node x) {
            if (x.IsLeaf) {
                output.Write(true);
                output.Write(x.ch, 8);
            } else {
                output.Write(false);
                WriteTrie(x.left);
                WriteTrie(x.right);
            }
        }

        private Node ReadTrie() {
            bool isLeaf = input.ReadBoolean();
            if (isLeaf) {
                return new Node(input.ReadChar(), -1, null, null);
            } else {
                return new Node(ZERO, -1, ReadTrie(), ReadTrie());
            }
        }
    }
}
