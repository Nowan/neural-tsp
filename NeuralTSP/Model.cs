using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class Model {

        public List<DataSet> TestSets { get; }
        public Dictionary<DataSet, int> ExpectedResults { get; }
        
        public Model() {
            TestSets = new List<DataSet>();
            ExpectedResults = new Dictionary<DataSet, int>();
        }

        public DataSet AddTestSet(int[] setData, int expectedResult) {
            DataSet dataSet = new DataSet(setData);
            TestSets.Add(dataSet);
            ExpectedResults.Add(dataSet, expectedResult);
            return dataSet;
        }


    }
}
