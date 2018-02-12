using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class View {

        public View() {

        }

        public void PrintDataSet(DataSet dataSet) {
            for (int c = 0; c < dataSet.Size; c++) {
                for (int r = 0; r < dataSet.Size; r++) {
                    Console.Write(dataSet.Matrix.GetValue(c, r).ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintIterationStep(int iteration, int distance, int[] route, Population original, Population random, Population final) {
            PrintSeparator();
            Console.WriteLine("ROUTE CHANGE ON " + iteration + " ITERATION\n");

            Console.WriteLine("CROSS ENTROPY:");
            Console.WriteLine(original.ToString() + "   [original population]");
            Console.WriteLine(random.ToString() + "   [random population]");
            Console.WriteLine(final.ToString() + "   [final population]\n");

            PrintDistance(distance);
            PrintRoute(route);
            Console.WriteLine();
        }

        public void PrintSeparator() {
            Console.WriteLine("-------------------------------------------------------------");
        }

        public void PrintPopulation(Population population) {
            Console.WriteLine(population.ToString());
        }

        public void PrintRoute(int[] route) {
            String output = "ROUTE: ";
            for (int i = 0; i < route.Length - 1; i++) output += route[i] + " -> ";
            Console.WriteLine(output + route[route.Length - 1]);
        }

        public void PrintDistance(int distance) {
            Console.WriteLine("DISTANCE: " + distance);
        }

        public void DisplayExitMessage() {
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
