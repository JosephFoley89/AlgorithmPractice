using System.Diagnostics;
using System.Timers;

namespace Algorithms.Tests {
    internal class SortingTest {
        private static Sort sort;
        private static Util util;
        private static Stopwatch stopwatch;
        private static List<int[]> Data;
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

        public void Execute(bool display = false) {
            Console.WriteLine("Executing Sorting Tests");
            if (Count < 1001) {
                ExecuteInsertionSortTest(display);
                ExecuteBubbleTest(display);
                ExecuteSelectionTest(display);
            }

            ExecuteMergeTest(display);
            ExecuteQuickTest(display);
            ExecuteShellTest(display);
            ExecuteHeapTest(display);
            ExecuteTimTest(display);
        }

        public void ExecuteInsertionSortTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = (int[])d.Clone();
                int[] sortedClone = sort.Insertion((int[])clone.Clone());

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", clone)}\nSorted Array:\t{string.Join(",", sort.Insertion(d))}");
                Debug.Assert(sort.Insertion(clone).SequenceEqual(sortedClone), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Insertion", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteMergeTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();
                
                sort.Merge(clone, 0, clone.Length - 1);
                sort.Merge(d, 0, d.Length - 1);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Merge", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteBubbleTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = (int[])d.Clone();
                int[] unsorted = (int[])clone.Clone();

                sort.Bubble(clone);
                sort.Bubble(d);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Bubble", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteQuickTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = sort.Quick((int[])d.Clone());
                int[] unsorted = (int[])clone.Clone();

                sort.Quick(d);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Quick", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteShellTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int length = d.Length - 1;
                int[] clone = sort.Shell((int[])d.Clone(), length);
                int[] unsorted = (int[])clone.Clone();

                sort.Shell(d, length);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Shell", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteSelectionTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = sort.Selection((int[])d.Clone());
                int[] unsorted = (int[])clone.Clone();

                sort.Selection(d);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Selection", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteHeapTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int[] clone = sort.Heap((int[])d.Clone());
                int[] unsorted = (int[])clone.Clone();

                sort.Heap(d);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Heap", Sets, Count, elapsed));
            stopwatch.Reset();
        }

        public void ExecuteTimTest(bool display = false) {
            stopwatch.Start();

            foreach (int[] d in Data) {
                int length = d.Length - 1;
                int[] clone = sort.Tim((int[])d.Clone(), length);
                int[] unsorted = (int[])clone.Clone();

                sort.Tim(d, length);

                if (display) Console.WriteLine($"\nUnsorted Array:\t{string.Join(",", unsorted)}\nSorted Array:\t{string.Join(",", d)}\n");
                Debug.Assert(clone.SequenceEqual(d), "The sorted arrays do not match.");
            }

            stopwatch.Stop();
            double elapsed = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(util.FormatStatistics("Tim", Sets, Count, elapsed));
            stopwatch.Reset();
        }

    }
}
