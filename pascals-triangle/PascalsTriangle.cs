﻿using System;
using System.Collections.Generic;

public class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    => rows < 0
        ? throw new ArgumentOutOfRangeException()
        : GetRows(rows);


    public static IEnumerable<IEnumerable<int>> GetRows(int rows)
    {
        for (var i = 1; i <= rows; i++)
        {
            yield return Row(i);
        }
    }

    private static IEnumerable<int> Row(int row)
    {
        yield return 1;
        var column = 1;

        for (var j = 1; j < row; j++)
        {
            column = column * (row - j) / j;
            yield return column;
        }
    }
}