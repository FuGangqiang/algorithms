namespace Books.Algorithms.Chap1 {
    public class Counter {
        private readonly string _id;
        private int count;

        public Counter(string id) {
            _id = id;
        }

        public void Increment() {
            count++;
        }

        public int Tally {
            get => count;
        }

        public static Counter Max(Counter x, Counter y) {
            if (x.Tally > y.Tally) {
                return x;
            } else {
                return y;
            }
        }

        public override string ToString() {
            return $"Counter(id={_id}, tally={count})";
        }
    }
}
