using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Controller {
        
        private View View { get; }
        private Model Model { get; }
        
        public Controller(View view, Model model) {
            View = view;
            Model = model;

            var testSet = model.AddTestSet(new int[] {
                0, 23, 14,
                23, 0, 9,
                14, 9, 0
            }, 46);

            Solve(testSet);
            
            PrepareToClose();
        }

        private void Solve(DataSet dataSet) {
            // TODO: implement generic algorithm
        }

        public void PrepareToClose() {
            View.DisplayExitMessage();
        }
    }
}
