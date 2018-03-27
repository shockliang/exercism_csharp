using System;
using System.Linq;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows < 0) throw new ArgumentOutOfRangeException();

        var result = new List<List<int>>();
        int c = 1;
        for (int i = 0; i < rows; i++)
        {
            var row = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                c = j == 0 || i == 0 ? 1 : c * (i - j + 1) / j;

                row.Add(c);
            }
            result.Add(row);
        }

        return result;
    }

}