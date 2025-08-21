using Algorithms.Algorithms;
using Algorithms.Helper;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Algorithms.Tests {
    internal class SortingTest {
        private static Sort sort;
        private static Util util;
        private static Stopwatch stopwatch;
        private List<int[]> Data;
        private static int Sets;
        private static int Count;

        public SortingTest(int sets = 0, int count = 0) {
            sort = new Sort();
            util = new Util();
            stopwatch = new Stopwatch();
            Sets = sets;
            Count = count;
            Data = util.GenerateTestDataArray(sets, count);
        }

        public void Execute(bool debug = false) {
            Console.WriteLine($"Executing Sorting Tests [{Sets} arrays with {Count} items]");
            ExecuteBubbleTest(debug);
            ExecuteSelectionTest(debug);
            ExecuteInsertionSortTest(debug);
            ExecuteShellTest(debug);
            ExecuteMergeTest(debug);
            ExecuteQuickTest(debug);
            ExecuteHeapTest(debug);
            ExecuteTimTest(debug);
        }

        public void ExecuteInsertionSortTest(bool debug = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Insertion(clone);
                stopwatch.Start();
                sort.Insertion(d);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (debug) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Insertion", elapsed));
        }

        public void ExecuteMergeTest(bool debug = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();
                
                sort.Merge(clone, 0, clone.Length - 1);
                stopwatch.Start();
                sort.Merge(d, 0, d.Length - 1);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (debug) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Merge", elapsed));
        }

        public void ExecuteBubbleTest(bool debug = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Bubble(clone);
                stopwatch.Start();
                sort.Bubble(d);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (debug) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Bubble", elapsed));
        }

        public void ExecuteQuickTest(bool debug = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Quick(clone, 0, length);
                stopwatch.Start();
                sort.Quick(d, 0, length);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (debug) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    Debug.Assert(sort.Merge(unsorted, 0, length).SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Quick", elapsed));
        }

        public void ExecuteShellTest(bool display = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Shell(clone, length);
                stopwatch.Start();
                sort.Shell(d, length);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (display) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length - 1);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Shell", elapsed));
        }

        public void ExecuteSelectionTest(bool debug = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Selection(clone);
                stopwatch.Start();
                sort.Selection(d);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (debug) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length);
                    Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Selection", elapsed));
        }

        public void ExecuteHeapTest(bool display = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length - 1;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Heap(clone);
                stopwatch.Start();
                sort.Heap(d);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (display) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Heap", elapsed));
        }

        public void ExecuteTimTest(bool display = false) {
            List<int[]> data = util.CloneData(Data);
            List<double> elapsed = new List<double>();

            foreach (int[] d in data) {
                int length = d.Length;
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Tim(clone, length);
                stopwatch.Start();
                sort.Tim(d, length);
                stopwatch.Stop();
                elapsed.Add(stopwatch.Elapsed.TotalMilliseconds);
                stopwatch.Reset();

                if (display) {
                    Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                    sort.Quick(unsorted, 0, length - 1);
                    Debug.Assert(unsorted.SequenceEqual(clone), "The sorted arrays do not match.");
                }
            }

            Console.WriteLine(util.FormatTestStatistics("Tim", elapsed));
        }
    }
}
