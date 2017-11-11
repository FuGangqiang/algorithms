namespace Books.Algorithms.Chap1 {
    public class Accumulator {
        private double total;
        private int n;

        public void AddDataValue(double val) {
            n++;
            total += val;
        }

        public double Mean {
            get => total / n;
        }

        public override string ToString() {
            return $"Accumulator(Mean={Mean})";
        }
    }
}
