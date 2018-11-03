using System;
using System.Collections.Generic;
using System.Text;

namespace MinCostPath
{
    class MinCostPathProcessor
    {
        int[,] matrix;

        public MinCostPathProcessor(int[,] matrix) {
            this.matrix = matrix;
        }

        public void GetMinCostPathInMatrix() {

            Console.WriteLine("---------------The input Matrix-------");
            PrintMatrix(matrix);

            int[,] costMatrix = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];

            costMatrix[0, 0] = matrix[0, 0];

            for (int i = 1; i < matrix.GetLength(0); i++) {
                costMatrix[i, 0] = matrix[i, 0] + costMatrix[i - 1, 0];
            }

            for (int j = 1; j < matrix.GetLength(1); j++) {
                costMatrix[0, j] = matrix[0, j] + costMatrix[0, j-1];
            }

            for (int i = 1; i < matrix.GetLength(0); i++) {
                for (int j = 1; j < matrix.GetLength(1); j++) {
                    costMatrix[i, j] = matrix[i, j] + 
                        Math.Min(costMatrix[i-1,j],
                        Math.Min(costMatrix[i, j-1], costMatrix[i-1, j-1])
                        );
                }
            }

            int rowsPenUltimateIndex = matrix.GetLength(0) - 1;
            int columnsPenUltimateIndex = matrix.GetLength(1) - 1;


            costMatrix[matrix.GetLength(0), matrix.GetLength(1)] = costMatrix[rowsPenUltimateIndex, columnsPenUltimateIndex];
            
            Console.WriteLine("The minimum cost is "
                + costMatrix[matrix.GetLength(0), matrix.GetLength(1)]);

            Console.WriteLine("-----------The Cost Matrix -------------");
            PrintMatrix(costMatrix);
        }


        private void PrintMatrix(int[,] inputMatrix) {

            int rows = inputMatrix.GetLength(0);
            int columns = inputMatrix.GetLength(1);

            Console.WriteLine("------------------------");
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    Console.Write(inputMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------");
        }
    }
}
