using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class LuckyNumberInMatrix
    {
        public static List<int> LuckyNumbers(int[][] matrix)
        {
            int rowMin = 0;
            int colMax = 0;

            List<List<int>> inputMatrix = new List<List<int>>();
            List<List<int>> reverseMatrix = new List<List<int>>();
            List<int> results = new List<int>();

            foreach (var row in matrix)
            {
                List<int> data = new List<int>();

                for (int i = 0; i < row.Length; i++)
                {
                    data.Add(row[i]);

                    if (reverseMatrix == null || reverseMatrix.Count < row.Length)
                    {
                        var data2 = new List<int>();
                        data2.Add(row[i]);
                        reverseMatrix?.Add(data2);
                    }
                    else
                    {
                        reverseMatrix[i].Add(row[i]);
                    }
                }

                inputMatrix.Add(data);
            }

            foreach (List<int> row in inputMatrix)
            {
                rowMin = row.Min(x => x);

                var maxColumn = reverseMatrix.Where(x => x.Contains(rowMin)).FirstOrDefault();

                colMax = maxColumn.Max(x => x);

                if (rowMin == colMax)
                {
                    Console.WriteLine("Result : " + rowMin);
                    results.Add(rowMin);
                }
            }

            return results;
        }

        public static List<int> LuckyNumbers()
        {
            int rowMin = 0;
            int colMax = 0;

            List<List<int>> inputMatrix = new List<List<int>>();
            List<List<int>> reverseMatrix = new List<List<int>>();
            List<int> results = new List<int>();

            var input = Console.ReadLine();

            var rows = input?.Split("],").ToList();

            if (rows != null && rows.Count > 0)
            {
                foreach (var row in rows)
                {
                    var currentRow = row?.Replace("[", string.Empty).Replace("]", string.Empty);

                    var columns = currentRow?.Split(",").ToList();

                    List<int> data = new List<int>();

                    if (columns != null && columns.Count > 0)
                    {
                        for (int i = 0; i < columns.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(columns[i]))
                            {
                                var number = Convert.ToInt32(columns[i]);
                                data.Add(number);

                                if (reverseMatrix == null || reverseMatrix.Count < columns.Count)
                                {
                                    var data2 = new List<int>();
                                    data2.Add(number);
                                    reverseMatrix?.Add(data2);
                                }
                                else
                                {
                                    reverseMatrix[i].Add(number);
                                }
                            }
                        }

                        inputMatrix.Add(data);
                    }
                }

                foreach (List<int> row in inputMatrix)
                {
                    rowMin = row.Min(x => x);

                    var maxColumn = reverseMatrix.Where(x => x.Contains(rowMin)).FirstOrDefault();

                    colMax = maxColumn.Max(x => x);

                    if (rowMin == colMax)
                    {
                        Console.WriteLine("Result : " + rowMin);
                        results.Add(rowMin);
                    }
                }
            }

            return results;
        }
    }
}
