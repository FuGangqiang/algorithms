using Xunit;
using Books.Algorithms.Chap5;

namespace Tests.Books.Algorithms.Chap5 {
    public class StringTest {
        [Fact]
        public void LsdSortTest() {
            var a = new string[] {
                "4PGC938",
                "2IYE230",
                "3CIO720",
                "1ICK750",
                "1OHV845",
                "4JZY524",
                "1ICK750",
                "3CIO720",
                "1OHV845",
                "1OHV845",
                "2RLA629",
                "2RLA629",
                "3ATW723",
            };

            var b = new string[] {
                "1ICK750",
                "1ICK750",
                "1OHV845",
                "1OHV845",
                "1OHV845",
                "2IYE230",
                "2RLA629",
                "2RLA629",
                "3ATW723",
                "3CIO720",
                "3CIO720",
                "4JZY524",
                "4PGC938",
            };

            Lsd.Sort(a, a[0].Length);
            for (int i = 0; i < a.Length; i++) {
                Assert.Equal(a[i], b[i]);
            }
        }

        [Fact]
        public void MsdSortTest() {
            var a = new string[] {
                "she",
                "sells",
                "seashells",
                "by",
                "the",
                "seashore",
                "the",
                "shells",
                "she",
                "sells",
                "are",
                "surely",
                "seashells",
            };

            var b = new string[] {
                "are",
                "by",
                "seashells",
                "seashells",
                "seashore",
                "sells",
                "sells",
                "she",
                "she",
                "shells",
                "surely",
                "the",
                "the",
            };
            Msd.Sort(a);
            for (int i = 0; i < a.Length; i++) {
                Assert.Equal(a[i], b[i]);
            }
        }

        [Fact]
        public void Quick3StringTest() {
            var a = new string[] {
                "she",
                "sells",
                "seashells",
                "by",
                "the",
                "seashore",
                "the",
                "shells",
                "she",
                "sells",
                "are",
                "surely",
                "seashells",
            };

            var b = new string[] {
                "are",
                "by",
                "seashells",
                "seashells",
                "seashore",
                "sells",
                "sells",
                "she",
                "she",
                "shells",
                "surely",
                "the",
                "the",
            };
            Quick3String.Sort(a);
            for (int i = 0; i < a.Length; i++) {
                Assert.Equal(a[i], b[i]);
            }
        }

        [Fact]
        public void TrieSymbolTable() {
            var st = new TrieSymbolTable<int>();
            st.Put("by", 4);
            st.Put("sea", 2);
            st.Put("sells", 1);
            st.Put("she", 6);
            st.Put("shells", 3);
            st.Put("the", 5);

            Assert.Equal(6, st.Size());

            var keys = st.KeysWithPrefix("sh");
            int i = 0;
            var res = new string[] { "she", "shells" };
            foreach (var key in keys) {
                Assert.Equal(key, res[i]);
                i++;
            }

            Assert.Equal("she", st.LongestPrefixOf("she"));
            Assert.Equal("she", st.LongestPrefixOf("shed"));

            st.TryGet("shells", out var val1);
            Assert.Equal(3, val1);
            st.TryGet("shed", out var val2);
            Assert.Equal(0, val2);

            st.Delete("shells");
            st.TryGet("shells", out var val3);
            Assert.Equal(0, val3);
        }

        [Fact]
        public void TernarySearchTrieSymbolTableTest() {
            var st = new TrieSymbolTable<int>();
            st.Put("by", 4);
            st.Put("sea", 2);
            st.Put("sells", 1);
            st.Put("she", 6);
            st.Put("shells", 3);
            st.Put("the", 5);

            st.TryGet("by", out var val1);
            Assert.Equal(4, val1);
            st.TryGet("bye", out var val2);
            Assert.Equal(0, val2);
        }

        [Fact]
        public void BruteForceSearchTest() {
            string txt = "ABACADABRAC";
            string pat = "ABRA";
            Assert.Equal(6, BruteForceSearch.Search(pat, txt));
        }

        [Fact]
        public void KMPSearchTest() {
            string txt = "ABACADABRAC";
            string pat = "ABRA";
            var kmp = new KmpSearch(pat);
            Assert.Equal(6, kmp.Search(txt));
        }
    }
}