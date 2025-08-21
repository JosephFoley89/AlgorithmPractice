using Algorithms.Helper;

namespace Algorithms.Algorithms {
    internal class Greedy {
        public (int, string) CoinProblem(int target) {
            int[] coins = [ 1, 5, 10, 25, 50 ];
            int minimum = 0, n = coins.Length;
            List<int> returnCoins = new List<int>();

            for (int i = n - 1; i >= 0; i--) {
                if (target >= coins[i]) {
                    int count = (target / coins[i]);
                    minimum += count;

                    for (int j = 0; j < count; j++) {
                        returnCoins.Add(coins[i]);
                    }

                    target -= (count * coins[i]);
                }

                if (target == 0) {
                    break;
                }
            }

            return (minimum, string.Join(",", returnCoins));
        }

        public double FractionalKnapsack(int[] value, int[] weight, int capacity = 100) {
            int n = value.Length, current = capacity;
            int[][] items = new int[n][];
            double max = 0.0;

            for (int i = 0; i < n; i++) {
                items[i] = new int[n];
                items[i][0] = value[i];
                items[i][1] = weight[i];
            }

            Array.Sort(items, new ItemComparer());

            for(int i = 0; i < n; i++) {
                if (items[i][1] <= current) {
                    Console.WriteLine($"{items[i][0]} - {items[i][1]}");
                    max += items[i][0];
                    current -= items[i][1];
                } else {
                    max += (1.0 * items[i][0] / items[i][1]) * current;
                    break;
                }
            }

            return max;
        }
    }
}
