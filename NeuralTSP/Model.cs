using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Model {

        public DataSet Path { get; set; }

        public Model() {
            Path = new DataSet(6);
        }
    }
}
