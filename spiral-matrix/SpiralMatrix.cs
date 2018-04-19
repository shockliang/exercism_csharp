using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        if (size < 1)
            return new int[,] { };

        var map = new int[size, size];
        var row = 0;
        var col = 0;
        var dir = ConsoleKey.RightArrow;
        var moves = 0;
        var total = size * size;
        map[row, col] = ++moves;
        while (moves < total)
        {
            switch (dir)
            {
                case ConsoleKey.RightArrow:
                    if (col + 1 < size && map[row, col + 1] == 0)
                        map[row, ++col] = ++moves;
                    else
                        dir = ConsoleKey.DownArrow;
                    break;
                case ConsoleKey.DownArrow:
                    if (row + 1 < size && map[row + 1, col] == 0)
                        map[++row, col] = ++moves;
                    else
                        dir = ConsoleKey.LeftArrow;
                    break;
                case ConsoleKey.LeftArrow:
                    if (col - 1 >= 0 && map[row, col - 1] == 0)
                        map[row, --col] = ++moves;
                    else
                        dir = ConsoleKey.UpArrow;
                    break;
                case ConsoleKey.UpArrow:
                    if (row - 1 >= 0 && map[row - 1, col] == 0)
                        map[--row, col] = ++moves;
                    else
                        dir = ConsoleKey.RightArrow;
                    break;
            }
        }
        return map;
    }
}