using Algorithms.Algorithms;
using Algorithms.Helper;
using System.Net.WebSockets;

namespace Algorithms.Tests {
    internal class GreedyTests {
        private static Greedy greedy;
        private static Util util;
        private static List<int[]> Data;

        public GreedyTests() {
            greedy = new Greedy();
            util = new Util();
            Data = util.GenerateTestDataArray(1, 25, 1, 99);
        }

        public void ExecuteTests() {
            TestCoinProblem();
            TestKnapsackProblem();
        }

        public static void TestCoinProblem() {
            foreach (int[] d in Data) {
                foreach (int n in d) {
                    Console.WriteLine(
                        $"The minimum number of coins required to reach {n.ToString("00")} is\t{greedy.CoinProblem(n)}"
                    );
                }
            }
        }

        public static void TestKnapsackProblem() {
            List<(int[], int[])> vwList = util.GenerateKnapsackData(10, 10);
            int capacity = 100;

            foreach ((int[], int[]) vw in vwList) {
                string format = string.Empty;

                for (int i = 0; i < vw.Item1.Length; i++) {
                    string ratio = ((double)vw.Item1[i] / (double)vw.Item2[i]).ToString("0.00");
                    format += $"Value: {vw.Item1[i].ToString("00")}\tWeight: {vw.Item2[i].ToString("00")} " +
                    $"Ratio:\t{ratio}\n";
                } 

                Console.WriteLine(
                    $"The most value you can expect with capacity of {capacity} is:" +
                    $"{greedy.FractionalKnapsack(vw.Item1, vw.Item2, capacity).ToString("0.00")} " + 
                    $"given\n{format}"
                );
            }

        }
    }
}
