using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    private readonly int[,] values;

    public SaddlePoints(int[,] values)
    {
        this.values = values;
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        var saddlePoints = new List<Tuple<int, int>>();

        for (int i = 0; i < values.GetLength(0); i++)
        {
            for (int j = 0; j < values.GetLength(1); j++)
            {
                var currentPoint = values[i, j];
                var row = Enumerable.Range(0, values.GetLength(0)).Select(x => values[i, x]);
                var col = Enumerable.Range(0, values.GetLength(1)).Select(x => values[x, j]);
                var isMaxOfRow = currentPoint == row.Max();
                var isMinOfCol = currentPoint == col.Min();

                if (isMaxOfRow && isMinOfCol)
                    saddlePoints.Add(Tuple.Create(i, j));

            }
        }
        return saddlePoints;
    }
}