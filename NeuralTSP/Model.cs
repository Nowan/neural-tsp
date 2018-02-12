using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Model {

        public List<DataSet> TestSets { get; }
        
        public Model() {
            TestSets = new List<DataSet>();
        }

        public DataSet AddTestSet(int[] setData) {
            DataSet dataSet = new DataSet(setData);
            TestSets.Add(dataSet);
            return dataSet;
        }


    }
}
