using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            var matrixA = MatrixCreate(1, 1);
            var matrixB = MatrixCreate(1, 1);

            MatrixFill(matrixA);
            MatrixFill(matrixB);

            Console.WriteLine(MatrixPrint(matrixA));
            Console.WriteLine(MatrixPrint(matrixB));

            Console.WriteLine(MatrixPrint(MatrixMultiply(matrixA, matrixB)));

            Console.ReadLine();
        }


        private static double[][] MatrixCreate(int rows, int cols)
        {
            // do error checking here
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }

        private static StringBuilder MatrixPrint(double[][] matrix)
        {
            var result = new StringBuilder();
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            for (int row = 0; row < rows; row++)
                result.AppendLine(String.Join(" | ", matrix[row]));
            result.AppendLine();
            return result;
        }

        private static void MatrixFill(double[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            Parallel.For(0, rows, row =>
            {
                for (int col = 0; col < cols; col++)
                    matrix[row][col] = rnd.NextDouble();

            });
        }

        private static double[][] MatrixMultiply(double[][] matrixA, double[][] matrixB)
        {
            // do error checking here
            var Arows = matrixA.Length;
            var Acols = matrixA[0].Length;

            var Brows = matrixB.Length;
            var Bcols = matrixB[0].Length;

            if (Acols != Brows) throw new Exception();

            double[][] result = MatrixCreate(Arows, Bcols);
            Parallel.For(0, Arows, row =>
            {
                for (int col = 0; col < Bcols; col++)
                for (int newCol = 0; newCol < Acols; newCol++)
                    result[row][col] += matrixA[row][newCol] * matrixB[newCol][col];
            });


            return result;
        }
    }
}
