namespace Algorithms {
    internal class Util {
        private const int MIN = 1;
        private const int MAX = 100;

        public List<int[]> GenerateTestDataArray(int sets, int length, int min = MIN, int max = MAX) {
            List<int[]> testData = new List<int[]>();
            Random random = new Random();

            sets = sets == 0 ? 20 : sets;
            length = length == 0 ? 20 : length;

            for (int i = 0; i < sets; i++) {
                int[] testDataArray = new int[(int)length];

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
                $"\n\tFound:\t{(itemsFound / count).ToString("P2")}";

            return $"\tCompleted {algorithm}"
                + $"\n\tTotal\t{total.ToString("0.00")}ms"
                + $"\n\tMean:\t{mean.ToString("0.00")}ms"
                + $"\n\tMedian:\t{median.ToString("0.00")}ms"
                + $"\n\tMode:\t{mode.ToString("0.00")}ms"
                + $"{successRate}\n";
        }
    }
}
