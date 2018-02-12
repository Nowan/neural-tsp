using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Controller {

        private const int NUMBER_OF_INTERATIONS = 10000;
        private const int NUMBER_OF_PARTITION_POINTS_IN_CROSS_ENTROPY = 2;
        private const int NUMBER_OF_CITIES = 20;

        private View View { get; }
        private Model Model { get; }
        
        public Controller(View view, Model model) {
            View = view;
            Model = model;

            var testSet = new DataSet(NUMBER_OF_CITIES);

            // Remove comment braces to override randomly generated values
            /*
            testSet = model.AddTestSet(new int[] {
                0, 1, 4, 2, 6, 6, 8, 6, 8, 5,
                2, 0, 9, 4, 4, 4, 2, 6, 5, 7,
                2, 5, 0, 9, 4, 4, 7, 9, 7, 6,
                9, 6, 9, 0, 2, 5, 2, 9, 9, 8,
                7, 6, 4, 4, 0, 3, 8, 9, 3, 7,
                8, 6, 6, 5, 8, 0, 2, 8, 2, 4,
                2, 3, 8, 9, 5, 6, 0, 6, 4, 2,
                7, 5, 4, 2, 8, 1, 8, 0, 4, 5,
                2, 9, 7, 8, 5, 7, 9, 4, 0, 5,
                1, 5, 3, 9, 4, 3, 3, 3, 8, 0
            });
            */

            View.PrintDataSet(testSet);

            Solve(testSet);
            
            PrepareToClose();
        }

        private void Solve(DataSet dataSet) {
            Population originalPopulation = Population.Create(dataSet.Size);
            for (int i = 0; i < NUMBER_OF_INTERATIONS; i++) {
                Population randomPopulation = Population.Create(dataSet.Size);
                Population crossPopulation = Population.Cross(originalPopulation, randomPopulation, 2);

                int originalDistance = CalculateDistance(dataSet, originalPopulation);
                int newDistance = CalculateDistance(dataSet, crossPopulation);

                if (newDistance < originalDistance) {
                    View.PrintIterationStep(i, newDistance, GetRoute(crossPopulation), originalPopulation, randomPopulation, crossPopulation);
                    originalPopulation = crossPopulation;
                }
            }
        }

        private int CalculateDistance(DataSet dataSet, Population population) {
            int distance = 0;
            int[] route = GetRoute(population);
            for (int i = 0; i < route.Length - 1; i++) {
                distance += dataSet.GetDistanceBetween(route[i], route[i + 1]);
            }

            return distance;
        }

        private int [] GetRoute(Population population) {
            int[] route = new int[population.Size];
            for (int i = 0; i < route.Length; i++) {
                route[i] = i;
            }
            Array.Sort(population.ToArray<int>(), route);
            return route;
        }

        public void PrepareToClose() {
            View.DisplayExitMessage();
        }
    }
}
