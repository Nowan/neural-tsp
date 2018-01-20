using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Population : List<int>, IDisposable {

        public int Size { get { return Capacity; } }

        private static Random rng = new Random();

        public Population(int size) : base(size) {
            FillWithRandomValues();
        }

        public Population(IEnumerable<int> entities) : base(entities) {}

        public override string ToString() {
            return String.Join(" ", this);
        }

        private void FillWithRandomValues() {
            for (int i = 0; i < Capacity; i++) {
                Add(rng.Next(0, 256));
            }
        }

        public static Population Cross(Population populationA, Population populationB) {
            return Cross(populationA, populationB, 1);
        }

        public static Population Cross(Population populationA, Population populationB, int partitionsNumber) {
            var smallerPopulation = populationA.Size > populationB.Size ? populationB : populationA;
            var biggerPopulation = populationA.Size > populationB.Size ? populationA : populationB;
            var crossEntities = new int [biggerPopulation.Size];

            int[] pivots = GeneratePartitionPivots(smallerPopulation.Size, partitionsNumber);
            for (int p = 0; p < pivots.Length - 1; p++) {
                int partitionStartIndex = pivots[p];
                int partitionEndIndex = pivots[p + 1];
                int partitionLength = partitionEndIndex - partitionStartIndex;

                using (var sourcePopulation = p % 2 == 0 ? smallerPopulation : biggerPopulation) {
                    var sourcePopulationEntities = sourcePopulation.ToArray<int>();
                    Array.Copy(sourcePopulationEntities, partitionStartIndex, crossEntities, partitionStartIndex, partitionLength);
                }
            }

            return new Population(crossEntities);
        }

        private static int[] GeneratePartitionPivots(int populationSize, int partitionsNumber) {
            int[] pivots = new int[partitionsNumber + 2];
            pivots[0] = 0;
            pivots[pivots.Length - 1] = populationSize;
            
            for (var i = 0; i < partitionsNumber; i++) {
                pivots[i + 1] = rng.Next(1, partitionsNumber);
            }

            Array.Sort(pivots);
            return pivots;
        }

        public void Dispose() {

        }
    }
}
