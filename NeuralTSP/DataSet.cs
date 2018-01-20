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

        public void Print() {
            for (int c = 0; c < Size; c++) {
                for (int r = 0; r < Size; r++) {
                    Console.Write(Matrix[c, r].ToString() + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
