using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

public class Queen
{
    private static readonly int ChessboardSize = 8;
    public Queen(int row, int column)
    {
        Row = row >= 0 && row < ChessboardSize ? row : throw new ArgumentOutOfRangeException();
        Column = column >= 0 && column < ChessboardSize ? column : throw new ArgumentOutOfRangeException();
        Vector = new Vector2(row, column);
    }

    public int Row { get; }
    public int Column { get; }
    public Vector2 Vector { get; }
}

public static class QueenAttack
{
    private static readonly IEnumerable<double> diagonals = new double[] { 45.0d, -45.0d, 135.0d, -135.0d };
    public static bool CanAttack(Queen white, Queen black)
    {
        var angle = Math.Atan2(black.Vector.Y - white.Vector.Y, black.Vector.X - white.Vector.X);
        var radians = angle * (180.0 / Math.PI);

        return white.Row == black.Row ||
                white.Column == black.Column ||
                diagonals.Any(x => x == radians);
    }

    public static Queen Create(int row, int column)
    {
        return new Queen(row, column);
    }
}