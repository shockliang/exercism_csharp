using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        int colDiff = white.Column - black.Column, rowDiff = white.Row - black.Row;
        return colDiff == 0 || rowDiff == 0 || Math.Abs(colDiff) == Math.Abs(rowDiff);
    }

    public static Queen Create(int row, int column)
    {
        if (Math.Min(row, column) < 0 || Math.Max(row, column) > 7) throw new ArgumentOutOfRangeException();

        return new Queen(row, column);
    }
}