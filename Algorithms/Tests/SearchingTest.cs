using Algorithms.Algorithms;
using System.Diagnostics;

namespace Algorithms.Tests {
    internal class SearchingTest {
        private static Sort sort;
        private static Search search;
        private static Util util;
        private static Stopwatch stopwatch;
        private static List<int[]> Data;
        private static int SearchValue;
        private static int Sets;
        private static int Count;

        public SearchingTest(int sets = 0, int count = 0, int searchValue = 0) {
            sort = new Sort();
            search = new Search();
            util = new Util();
            stopwatch = new Stopwatch();
            Data = util.GenerateTestDataArray(sets, count, 1, count);
            Random random = new Random();
            SearchValue = searchValue == 0 ? random.Next(1, count) : searchValue;
            Sets = sets;
            Count = count;
        }

        public void Execute() {
            Console.WriteLine($"Executing Searching Tests [{Sets} arrays with {Count} items]");
            TestRandomSearch();
            TestLinearSearch();
            TestBinarySearch();
        }

        public void TestLinearSearch() {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();
            double found = 0;

            foreach (int[] d in data) {
                stopwatch.Start();
                int index = search.LinearSearch(d, SearchValue);
                stopwatch.Stop();

                if (index > -1) {
                    found++;
                }

                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();
            }

            Console.WriteLine(util.FormatTestStatistics("Linear Search", elapsed, found));
        }

        public void TestBinarySearch() {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();
            double found = 0;

            foreach (int[] d in data) {
                sort.Quick(d, 0, d.Length - 1);
            }

            foreach (int [] d in data) {
                stopwatch.Start();
                int index = search.BinarySearch(d, SearchValue);
                stopwatch.Stop();


                if (index > -1) {
                    found++;
                }

                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();
            }

            Console.WriteLine(util.FormatTestStatistics("Binary Search", elapsed, found));
        }

        public void TestRandomSearch() {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();
            double found = 0;

            foreach (int[] d in data) {
                stopwatch.Start();
                int index = search.Random(d, SearchValue);
                stopwatch.Stop();

                if (index > -1) {
                    found++;
                }

                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine(util.FormatTestStatistics("Random Search", elapsed, found));
        }
    }
}
