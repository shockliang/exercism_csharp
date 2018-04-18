using System;
using System.Linq;
using System.Collections.Generic;

public class SpiralMatrix
{
    [Flags]
    public enum Direction : int
    {
        Right = 0b1000,
        Bottom = 0b0100,
        Left = 0b0010,
        Top = 0b0001,
        All = Right | Bottom | Left | Top,
    }

    public static int[,] GetMatrix(int size)
    {
        var cells = new Cell<int>[size, size];
        var matrix = new int[size, size];

        for (int c = 0; c < size; c++)
        {
            for (int r = 0; r < size; r++)
            {
                var cell = new Cell<int>(0, r, c);
                cells[r, c] = cell;
                cell.CheckBound(size);
            }
        }

        var directions = new Direction[] {
                Direction.Right, Direction.Bottom, Direction.Left,Direction.Top}.ToList();

        for (int c = 0; c < size; c++)
        {
            for (int r = 0; r < size; r++)
            {
                var cell = cells[r, c];
                directions.ForEach(dir =>
                {
                    if ((cell.Spaces & dir) == dir)
                    {
                        switch (dir)
                        {
                            case Direction.Right:
                                cell.SetNeighbor(Direction.Right, cells[r, c + 1]);
                                break;
                            case Direction.Bottom:
                                cell.SetNeighbor(Direction.Bottom, cells[r + 1, c]);
                                break;
                            case Direction.Left:
                                cell.SetNeighbor(Direction.Left, cells[r, c - 1]);
                                break;
                            case Direction.Top:
                                cell.SetNeighbor(Direction.Top, cells[r - 1, c]);
                                break;
                        }
                    }
                });

            }
        }

        int step = 1, row = 0, col = 0;
        var nextDirection = Direction.Right;
        while (step <= (size * size))
        {
            var cell = cells[row, col];
            cell.Value = step;
            cell.UpdateSpaces();
            nextDirection = cell.NextDirection;

            switch (nextDirection)
            {
                case Direction.Right:
                    col++;
                    break;
                case Direction.Bottom:
                    row++;
                    break;
                case Direction.Left:
                    col--;
                    break;
                case Direction.Top:
                    row--;
                    break;
            }

            step++;
        }
        var values = OutputValues(cells);
        return OutputValues(cells);
    }

    private static T[,] OutputValues<T>(Cell<T>[,] cells)
    {
        var values = new T[cells.GetLength(0), cells.GetLength(1)];
        var size = cells.GetLength(0);

        for (int c = 0; c < size; c++)
        {
            for (int r = 0; r < size; r++)
            {
                values[r, c] = cells[r, c].Value;
            }
        }
        return values;
    }

    public class Cell<T>
    {
        public T Value { get; set; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool HasSpaceOnTheLeft { get; set; } = true;
        public bool HasSpaceOnTheBottom { get; set; } = true;
        public bool HasSpaceOnTheRight { get; set; } = true;
        public bool HasSpaceOnTheTop { get; set; } = true;
        public Direction Spaces { get; set; } = Direction.All;
        public Direction NextDirection { get; private set; } = Direction.Left;
        private IDictionary<Direction, Cell<T>> neighbors = new Dictionary<Direction, Cell<T>>(4);

        public Cell(T value, int row, int col)
        {
            Value = value;
            Row = row;
            Col = col;
        }

        // neighbor
        public void CheckBound(int bound)
        {
            if (Col == 0)
            {
                HasSpaceOnTheLeft = false;
                Spaces ^= Direction.Left;
            }
            if (Row == 0)
            {
                HasSpaceOnTheTop = false;
                Spaces ^= Direction.Top;
            }
            if (Col + 1 == bound)
            {
                HasSpaceOnTheRight = false;
                Spaces ^= Direction.Right;
            }
            if (Row + 1 == bound)
            {
                HasSpaceOnTheBottom = false;
                Spaces ^= Direction.Bottom;
            }

            NextDirection = GetNextDirection();
        }

        public void UpdateSpaces()
        {
            foreach (var neighbor in neighbors)
            {
                if (!neighbor.Value.Value.Equals(default(T)))
                {
                    Spaces ^= neighbor.Key;
                }
            }

            var directions = new Direction[] {
                Direction.Right, Direction.Bottom, Direction.Left,Direction.Top};

            var currentSpaces = directions.Where(dir => (Spaces & dir) == dir);

            if (currentSpaces.Contains(Direction.Top) &&
                currentSpaces.Contains(Direction.Right))
            {
                NextDirection = GetNextDirection(new Direction[] { Direction.Top, Direction.Right });
            }
            else
            {
                NextDirection = GetNextDirection();
            }
        }

        public Direction GetNextDirection(IEnumerable<Direction> directionPriority = null)
        {
            directionPriority = directionPriority ?? new Direction[] {
                Direction.Right, Direction.Bottom, Direction.Left,Direction.Top};

            return directionPriority.FirstOrDefault(dir => (dir & Spaces) != 0);
        }

        public void SetNeighbor(Direction direction, Cell<T> neighbor)
        {
            if (neighbors.ContainsKey(direction))
                neighbors[direction] = neighbor;
            else
                neighbors.Add(direction, neighbor);
        }
    }
}
