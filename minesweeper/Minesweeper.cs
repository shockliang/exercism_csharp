using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public static class Minesweeper
{
    private static Func<int, int, (int x, int y)>[] adjacent = new Func<int, int, (int x, int y)>[]
    {
        (x, y) => (x - 1, y - 1), // LT
        (x, y) => (x, y - 1),     // Top
        (x, y) => (x + 1, y - 1), // RT
        (x, y) => (x - 1, y),     // Left
        (x, y) => (x + 1, y),     // Right
        (x, y) => (x - 1, y + 1), // LB
        (x, y) => (x, y + 1),     // Bottom
        (x, y) => (x + 1, y + 1)  // RB
    };

    public static string[] Annotate(string[] input)
    {
        var map = input.Select(str => str.ToArray()).ToArray();

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x].Equals('*')) continue;

                foreach (var adjFunc in adjacent)
                {
                    var result = adjFunc.Invoke(x, y);
                    if (IsInTheRange(result.x, result.y, map[y].Length, map.Length) &&
                        map[result.y][result.x].Equals('*'))
                    {
                        map[y][x] = map[y][x] != ' '
                            ? (char)(map[y][x] + 1)
                            : '1';
                    }
                }
            }
        }

        return map.Select(ary => string.Concat(ary)).ToArray();
    }

    private static bool IsInTheRange(int x, int y, int boundX, int boundY)
    {
        return x < boundX && x >= 0 && y >= 0 && y < boundY;
    }
}
