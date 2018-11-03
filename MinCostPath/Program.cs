using System;

namespace MinCostPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Min Cost Path!");
            Console.WriteLine("--------------");

            int[,] inputMatrix = GetInput();
            if (inputMatrix != null)
            {
                MinCostPathProcessor minCostPathProcessor = new MinCostPathProcessor(inputMatrix);
                minCostPathProcessor.GetMinCostPathInMatrix();
            }
            else {
                Console.WriteLine("Please try again with valid inputs!");
            }

            Console.ReadLine();
        }

        private static int[,] GetInput() {
            int[,] matrix = null;

            Console.WriteLine("Enter the number of rows in the matrix");
            try
            {
                int noOfRows = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of columsn in the matrix");
                int noOfColumns = int.Parse(Console.ReadLine());
                matrix = new int[noOfRows, noOfColumns];

                for (int i = 0; i < noOfRows; i++) {
                    Console.WriteLine("Enter the elements in row "+i +"separated by space");
                    String rowelems = Console.ReadLine();
                    String[] elements = rowelems.Split(' ');
                    for (int j = 0; j < elements.Length; j++) {
                        matrix[i, j] = int.Parse(elements[j]);
                    }
                }
                
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is"+exception.Message);
            }
            return matrix;
        }
    }
}
