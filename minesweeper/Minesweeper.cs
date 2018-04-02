using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public static class Minesweeper
{
    private static Func<int, int, int, int, char[][], bool> condition = IsInTheRangeAndMineCell;

    private static List<Func<int, int, char[][], bool>> adjacent = new Func<int, int, char[][], bool>[]
    {
        (x, y, map) => condition(x - 1, y - 1, map[y].Length, map.Length, map), // LT
        (x, y, map) => condition(x, y - 1, map[y].Length, map.Length, map),     // Top
        (x, y, map) => condition(x + 1, y - 1, map[y].Length, map.Length, map), // RT
        (x, y, map) => condition(x - 1, y, map[y].Length, map.Length, map),     // Left
        (x, y, map) => condition(x + 1, y, map[y].Length, map.Length, map),     // Right
        (x, y, map) => condition(x - 1, y + 1, map[y].Length, map.Length, map), // LB
        (x, y, map) => condition(x, y + 1, map[y].Length, map.Length, map),     // Bottom
        (x, y, map) => condition(x + 1, y + 1, map[y].Length, map.Length, map)  // RB
    }.ToList();

    public static string[] Annotate(string[] input)
    {
        var map = input.Select(str => str.ToArray()).ToArray();

        for (int y = 0; y < map.Length; y++)
        {
            for (int x = 0; x < map[y].Length; x++)
            {
                if (map[y][x].Equals('*')) continue;

                foreach (var checkFunc in adjacent)
                {
                    if (checkFunc.Invoke(x, y, map))
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

    private static bool IsInTheRangeAndMineCell(int x, int y, int boundX, int boundY, char[][] map)
        => x < boundX && x >= 0 && y >= 0 && y < boundY
            ? IsMineCell(x, y, map)
            : false;
            
    private static bool IsMineCell(int x, int y, char[][] map)
        => map[y][x].Equals('*');
}
