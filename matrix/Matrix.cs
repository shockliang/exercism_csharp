using System;
using System.Linq;
using System.Collections.Generic;

public class Matrix
{
    private List<IEnumerable<int>> matrix;
    public Matrix(string input)
    {
        matrix = input.Split('\n').Aggregate(new List<IEnumerable<int>>(), (list, row) =>
        {
            var rowElements = row.Split(' ').Select(x => Convert.ToInt32(x));
            list.Add(rowElements);
            return list;
        });
    }

    public int Rows { get => matrix.Count; }

    public int Cols { get => matrix.Max(x => x.Count()); }

    public int[] Row(int row) => matrix[row].ToArray();

    public int[] Col(int col) => matrix.Select(x => x.ElementAtOrDefault(col)).ToArray();
}