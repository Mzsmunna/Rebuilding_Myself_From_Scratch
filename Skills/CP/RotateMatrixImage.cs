using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class RotateMatrixImage
    {
        public static void Rotate(int[][] matrix)
        {
            //int[] matrix1 = new int[] { 1, 2, 3 };
            //int[] matrix2 = new int[] { 4, 5, 6 };
            //int[] matrix3 = new int[] { 7, 8, 9 };
            ////int[] matrix4 = new int[] { 10, 11, 12 };

            //int[][] matrix = new int[][] { matrix1, matrix2, matrix3 }; //, matrix4

            var row = matrix.Length;
            var col = matrix[0].Length;

            int[,] results = new int[col, row];

            for (int c = 0; c < col; c++)
            {
                int i = 0;

                for (int r = row - 1; r >= 0; r--)
                {
                    var number = matrix[r][c];
                    results[c, i] = number;
                    i++;
                }
            }

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    matrix[r][c] = results[r, c];
                }
            }

            Console.WriteLine(results);
        }
    }
}
