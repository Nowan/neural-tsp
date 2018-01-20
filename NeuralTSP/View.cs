using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class View {

        public View() {

        }

        public void PrintMatrix(Array matrix) {
            for (int c = 0; c < matrix.GetLength(0); c++) {
                for (int r = 0; r < matrix.GetLength(1); r++) {
                    Console.Write(matrix.GetValue(c, r).ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintPopulation(Population population) {
            Console.WriteLine("POPULATION: \n" + population.ToString() + "\n");
        }

        public void DisplayExitMessage() {
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
