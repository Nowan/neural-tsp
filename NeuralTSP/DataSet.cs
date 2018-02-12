using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralTSP {
    class DataSet {

        private const int MIN_DISTANCE = 20;
        private const int MAX_DISTANCE = 100;

        public int[,] Matrix { get; }
        public int Size { get; }

        public DataSet(int Size) {
            this.Size = Size;
            Matrix = new int[Size, Size];

            Random rand = new Random();
            for (int i = 0; i < Matrix.GetLength(0); i++) {
                for (int j = i + 1; j < Matrix.GetLength(1); j++) {
                    Matrix[i, j] = rand.Next(MIN_DISTANCE, MAX_DISTANCE);
                    Matrix[j, i] = (int)(Matrix[i, j] * (rand.Next(80, 120) * 0.01));
                }
            }
        }

        public DataSet(int [] routeMatrix) {
            Size = (int)(Math.Floor(Math.Sqrt(routeMatrix.Length)));
            Matrix = new int[Size, Size];
            for (int i = 0; i < Size; i++) {
                for (int j = i + 1; j < Size; j++) {
                    Matrix[i, j] = routeMatrix[i * Size + j];
                    Matrix[j, i] = routeMatrix[j * Size + i];
                }
            }
        }

        public int GetDistanceBetween(int routeIndexA, int routeIndexB) {
            return Matrix[routeIndexA, routeIndexB];
        }

        public override String ToString() {
            String output = "";
            for (int c = 0; c < Size; c++) {
                for (int r = 0; r < Size; r++) {
                    output += Matrix[c, r].ToString() + " ";
                }
                output += "\n";
            }
            return output;
        }
    }
}
