namespace Algorithms.Algorithms {
    internal class Search {
        private static Sort sort;

        public Search() {
            sort = new Sort();
        }

        //Linear search is best used in unsorted arrays
        public int LinearSearch(int[] a, int n) {
            int index = -1;

            for (int i = 0; i < a.Length; i++) {
                if (a[i] == n) {
                    index = i;
                    break;
                }
            }

            return index;
        }

        //Binary search is best used in sorted arrays.
        //The array is split into halves and if the
        //value does not equal the searched for value
        //the algorithm checks to see if the midpoint is
        //higher or lower than the searched for value
        //and searches the appropriate slice of the array
        //for the value.
        public int BinarySearch(int[] a, int n) {
            int mid = 0, low = 0, high = a.Length - 1;

            while (low <= high) {
                mid = low + (high - low) / 2;

                if (a[mid] == n) {
                    return mid;
                }

                if (a[mid] < n) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }

            return -1;
        }


        //Random search is a gamble
        public int Random(int[] a, int n) {
            int index = -1, counter = 0;
            Random random = new Random();
            Dictionary<int, int> searched = new Dictionary<int, int>();

            while (searched.Count() < a.Length - 1) {
                int key = random.Next(0, a.Length - 1);
                if (!searched.ContainsKey(key)) {
                    if (a[key] == n) {
                        index = key;
                        break;
                    } else {
                        searched.Add(key, counter);
                    }
                }
                counter++;
            }

            return index;
        }
    }
}
