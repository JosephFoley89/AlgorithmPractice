namespace Algorithms.Helper {
    internal class Util {
        private const int MIN = 1;
        private const int MAX = 100;

        public List<int[]> GenerateTestDataArray(int sets, int length, int min = MIN, int max = MAX) {
            List<int[]> testData = new List<int[]>();
            Random random = new Random();

            sets = sets == 0 ? 20 : sets;
            length = length == 0 ? 20 : length;

            for (int i = 0; i < sets; i++) {
                int[] testDataArray = new int[length];

                for (int j = 0; j < length; j++) {
                    testDataArray[j] = random.Next(min, max);
                }

                testData.Add(testDataArray);
            }

            return testData;
        }


        public List<int[]> CloneData(List<int[]> data) {
            List<int[]> clone = new List<int[]>();

            foreach (int[] d in data) {
                int[] c = new int[d.Length];
                for (int i = 0; i < d.Length; i++) {
                    int n = d[i];
                    c[i] = n;
                }
                clone.Add(c);
            }

            return clone;
        }

        public string FormatTestStatistics(string algorithm, List<double> elapsed, double itemsFound = 0.0) {
            int count = elapsed.Count();
            double total = elapsed.Sum();
            double mean = elapsed.Average();
            double median = elapsed.ElementAt(count / 2);
            double mode = elapsed.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.Key)
                .Select(x => (double)x.Key)
                .FirstOrDefault();

            string successRate = itemsFound == 0.0 ? "" : 
                $"Found:\t\t{(itemsFound / count).ToString("P2")}";

            string row = $"Algorithm:\t{algorithm}\n"
                + $"Total:\t\t{total.ToString("0.0000")}ms\n"
                + $"Mean:\t\t{mean.ToString("0.0000")}ms\n"
                + $"Median:\t\t{median.ToString("0.0000")}ms\n"
                + $"Mode:\t\t{mode.ToString("0.0000")}ms\n"
                + $"{successRate}\n";

            return $"{row}";
        }

        public List<(int[], int[])> GenerateKnapsackData(int sets, int count, int minimum = 0, int maximum = 0) {
            List < (int[], int[])> VWs = new List < (int[], int[])>();
            Random random = new Random();
            int min = minimum == 0 ? MIN : minimum;
            int max = maximum == 0 ? MAX : maximum;

            for (int i = 0; i < sets; i++) {
                int[] value = new int[count];
                int[] weight = new int[count];

                for (int j = 0; j < count; j++) {
                    value[j] = random.Next(min, max);
                    weight[j] = random.Next(min, max);
                }

                VWs.Add((value, weight));
            }

            return VWs;
        }
    }
}
