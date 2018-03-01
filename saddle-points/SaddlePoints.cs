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
        int l = values.GetLength(0);

        var rows = Enumerable.Range(0, l).Select(i => Enumerable.Range(0, l).Select(j => values[i, j]).ToArray()).ToArray();
        var columns = Enumerable.Range(0, l).Select(i => Enumerable.Range(0, l).Select(j => values[j, i]).ToArray()).ToArray();

        var maxInRows = Enumerable.Range(0, l).Select(i => rows[i].Max()).ToArray();
        var minInColumns = Enumerable.Range(0, l).Select(i => columns[i].Min()).ToArray();

        bool isSaddelPoint(int i, int j) => values[i, j] == maxInRows[i] && values[i, j] == minInColumns[j];

        return Enumerable.Range(0, l).SelectMany(i => Enumerable.Range(0, l).Where(j => isSaddelPoint(i, j)).Select(j => Tuple.Create(i, j)));
    }
}