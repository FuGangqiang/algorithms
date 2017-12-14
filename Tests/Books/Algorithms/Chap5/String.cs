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
    }
}