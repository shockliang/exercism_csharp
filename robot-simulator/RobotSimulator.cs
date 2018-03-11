using System;
using System.Linq;
using System.Collections.Generic;

public enum Direction
{
    North,
    East,
    South,
    West
}
public enum Turn
{
    Right,
    Left
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public class RobotSimulator
{
    private IDictionary<char, Action> instructionReact;

    public RobotSimulator(Direction direction, Coordinate coordinate)
    {
        this.Direction = direction;
        this.Coordinate = coordinate;
        instructionReact = new Dictionary<char, Action>()
        {
            ['L'] = TurnLeft,
            ['R'] = TurnRight,
            ['A'] = Advance
        };
    }

    public Direction Direction { get; private set; }

    public Coordinate Coordinate { get; private set; }

    public void TurnRight() => TurnsDirection(Turn.Right);

    public void TurnLeft() => TurnsDirection(Turn.Left);

    public void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                break;
            case Direction.East:
                Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                break;
            case Direction.South:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                break;
            case Direction.West:
                Coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                break;
        }
    }

    public void Simulate(string instructions)
    {
        instructions
            .ToUpper()
            .Where(c => instructionReact.ContainsKey(c))
            .Select(actionChar => instructionReact[actionChar])
            .ToList()
            .ForEach(action => action.Invoke());
    }

    private void TurnsDirection(Turn turn)
    {
        switch (Direction)
        {
            case Direction.North:
                Direction = turn == Turn.Right ? Direction.East : Direction.West;
                break;
            case Direction.East:
                Direction = turn == Turn.Right ? Direction.South : Direction.North;
                break;
            case Direction.South:
                Direction = turn == Turn.Right ? Direction.West : Direction.East;
                break;
            case Direction.West:
                Direction = turn == Turn.Right ? Direction.North : Direction.South;
                break;
        }
    }
}