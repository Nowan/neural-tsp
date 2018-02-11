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

        public void PrintPopulation(Population population) {
            Console.WriteLine("POPULATION: \n" + population.ToString() + "\n");
        }

        public void DisplayExitMessage() {
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
