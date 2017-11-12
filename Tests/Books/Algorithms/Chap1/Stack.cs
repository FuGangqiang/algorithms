using Xunit;
using Books.Algorithms.Chap1;

namespace Tests.Books.Algorithms.Chap1 {
    public class StackTest {
        [Fact]
        public void IsEmptyTest() {
            var stack = new Stack<int>();
            Assert.True(stack.IsEmpty());
        }

        [Fact]
        public void SizeTest() {
            var stack = new Stack<int>();
            Assert.Equal(0, stack.Size);
            for (var i = 1; i < 10; i++) {
                stack.Push(i);
                Assert.Equal(i, stack.Size);
            }
        }

        [Fact]
        public void PushPopTest() {
            var stack = new Stack<int>();
            int size = 10;
            for (var i = 0; i < size; i++) {
                stack.Push(i);
            }
            for (var j = size - 1; j >= 0; j--) {
                Assert.Equal(j, stack.Pop());
            }
        }

        [Fact]
        public void EvaluateTest() {
            var expr = "(1+((6/3)*(4*5)))";
            var ops = new Stack<char>();
            var vals = new Stack<int>();

            foreach (var c in expr) {
                switch (c) {
                    case '(':
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        ops.Push(c);
                        break;
                    case ')':
                        var op = ops.Pop();
                        var v = vals.Pop();
                        switch (op) {
                            case '+':
                                v = vals.Pop() + v;
                                break;
                            case '-':
                                v = vals.Pop() - v;
                                break;
                            case '*':
                                v = vals.Pop() * v;
                                break;
                            case '/':
                                v = vals.Pop() / v;
                                break;
                        }
                        vals.Push(v);
                        break;
                    default:
                        vals.Push((int)c - (int)'0');
                        break;
                }
            }
            Assert.Equal(41, vals.Pop());
        }
    }
}
