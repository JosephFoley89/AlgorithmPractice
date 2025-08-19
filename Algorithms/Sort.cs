using System.ComponentModel.DataAnnotations;

namespace Algorithms {
    internal class Sort {
        //Insertion sorting is an algorithm that is efficient
        //for a small number of items. Worst case scenario,
        //this is O(n^2). This algorithm gets worse the larger
        //the number of items there are.
        public int[] Insertion(int[] n) {
            for (int i = 1; i < n.Length; i++) {
                int key = n[i];
                int j = i - 1;

                while (j > -1 && n[j] > key) {
                    n[j + 1] = n[j];
                    j = j - 1;
                }

                n[j + 1] = key;
            }

            return n;
        }

        //Merge sort is much more efficient for larger data sets
        //than Insertion sorting is. The reason this is the case
        //is because it takes an a single array and continues to
        //split it in half until it can no longer do so (arrays
        //would need to be greater than 1 to be split). Then it
        //sorts and merges the arrays. This has a time complexity
        //of O(n log n) or very close to linear.
        public void Merge(int[] a, int l, int r) {
            if (l < r) {
                int m = l + (r - l) / 2;

                Merge(a, l, m);
                Merge(a, m + 1, r);

                MergeSort(a, l, m, r);
            }
        }

        private static void MergeSort(int[] a, int l, int m, int r) {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; i++) {
                L[i] = a[l + i];
            }

            for (j = 0; j < n2; j++) {
                R[j] = a[m + 1 + j];
            }

            i = 0;
            j = 0;

            int k = l;

            while (i < n1 && j < n2) {
                if (L[i] <= R[j]) {
                    a[k] = L[j];
                    i++;
                } else {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1) {
                a[k] = L[i];
                i++;
                k++;
            }

            while (j < n2) {
                a[k] = R[j];
                j++;
                k++;
            }
        }

        //Bubble sort is an example of another inefficient
        //sorting algorithm. It's worst case scenario is
        //also O(n^2).
        public int[] Bubble(int[] a) {
            for (int i = 1; i < a.Length - 1; i++) {
                for (int j = a.Length - 1; j > 0;  j--) {
                    if (a[j] < a[j-1]) {
                        int temp = a[j];
                        a[j] = a[j-1];
                        a[j-1] = temp;
                    }
                }
            }

            return a;
        }

        //Quicksort is another sorting algorithm that,
        //in the worst case is O(n^2) but it averages
        //a running time of O(n log n).
        public int[] Quick(int[] a) {
            if (a.Length < 2) {
                return a;
            }

            return QuickSort(a, 0, a.Length - 1);
        }

        private static int[] QuickSort(int[] a, int l, int r) {
            int pivot = a[l];
            int currentL = l;
            int currentR = r;

            while (currentL < currentR) {
                while (a[currentL] < pivot) {
                    currentL++;
                }

                while (a[currentR] > pivot) {
                    currentR--;
                }

                if (currentL <= currentR) {
                    (a[currentR], a[currentL]) = (a[currentL], a[currentR]);
                    currentL++;
                    currentR--;
                }
            }

            if (l < currentR) {
                QuickSort(a, l, currentR);
            }
            if (r< currentL) {
                QuickSort(a, currentL, r);
            }

            return a;
        }

        //Shell Sorting is a form/modification of insertion sorting.
        //This algorithm sorts elements at specific intervals first
        //while gradually reducing the interval until it's equal to one.
        //The worst case time complexity for this is O(n^2).
        //The average time complexity, however, is O(n log n).
        public int[] Shell(int[] a, int size) {
            for (int interval = size / 2; interval > 0; interval /= 2) {
                for (int i = interval; i < size; i++) {
                    int current = a[i];
                    int k = i;

                    while (k > interval && a[k - interval] > current) {
                        a[k] = a[k - interval];
                        k -= interval;
                    }

                    a[k] = current;
                }
            }

            return a;
        }


        //Selection sort is similar to bubble sort and 
        //has a time complexity of O(n^2).
        public int[] Selection(int[] a) {
            for (int i = 0; i < a.Length - 1; i++) {
                int min = i;

                for (int j = i + 1; j < a.Length - 1; j++) {
                    if (a[j] < a[min]) {
                        min = j;
                    }
                }

                int temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }

            return a;
        }

        //Heap sort is an optimization upon selection sort.
        //The algorithm finds the largest number and swaps
        //places with the last element in the array. The
        //process is repeated for the remaining elements.
        //The time complexity of this sorting algorithm is
        //O(n log n).
        public int[] Heap(int[] a) {
            for (int i = (a.Length / 2) - 1; i >= 0; i--) {
                Heapify(a, a.Length, i);
            }

            for (int i = a.Length - 1; i > 0; i--) {
                int temp = a[0];
                a[0] = a[i];
                a[i] = temp;

                Heapify(a, i, 0);
            }

            return a;
        }

        private static void Heapify(int[] a, int n, int i) {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && a[l] > a[largest]) {
                largest = l;
            }

            if (r < n && a[r] > a[largest]) {
                largest = r;
            }

            if (largest != i) {
                int temp = a[i];
                a[i] = a[largest];
                a[largest] = temp;

                Heapify(a, n, largest);
            }
        }

        //Tim Sort
        public int[] Tim(int[] a, int n) {
            const int RUN = 32;

            for (int i = 0; i < n; i += RUN) {
                TimInsertion(a, i, Math.Min((i + RUN - 1), (n - 1)));
            }

            for (int size = RUN; size < n; size = 2 * size) { 
                for (int left = 0; left < n; left += 2 * size) {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right) {
                        MergeSort(a, left, mid, right);
                    }
                }
            }

            return a;
        }

        private static void TimInsertion(int[] a, int left, int right) {
            for (int i = left + 1; i <= right; i++) {
                int temp = a[i];
                int j = i - 1;

                while (j >= left && a[j] > temp) {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = temp;
            }
        }

    }
}
