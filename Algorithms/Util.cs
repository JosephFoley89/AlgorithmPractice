using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

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

        public string FormatStatistics(string algorithm, int sets, int count, double totalTime) {
            return $"\tCompleted {algorithm} Sort of {sets} array of {count} items in {totalTime}ms."
                + $"\n\tMean:\t{(totalTime / count)}ms\n";
        }
    }
}
