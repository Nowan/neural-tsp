using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Controller {

        private const int PARTITIONS_NUMBER = 1;

        private View View { get; }
        private Model Model { get; }
        
        public Controller(View view, Model model) {
            View = view;
            Model = model;

            var populationA = new Population(Model.Path.Size);
            var populationB = new Population(Model.Path.Size);
            var populationC = Population.Cross(populationA, populationB);

            View.PrintMatrix(Model.Path.Matrix);

            View.PrintPopulation(populationA);
            View.PrintPopulation(populationB);
            View.PrintPopulation(populationC);

            PrepareToClose();
        }

        public void PrepareToClose() {
            View.DisplayExitMessage();
        }
    }
}
