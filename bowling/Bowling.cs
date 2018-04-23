using System;
using System.Linq;
using System.Collections.Generic;

public class BowlingGame
{
    private Frame[] frames = Enumerable.Range(0, 10).Select(i => new Frame(i)).ToArray();
    private int step = 0;
    private bool isGameEnd = false;

    public void Roll(int pins)
    {
        if(IsDissatisfy(pins)) throw new ArgumentException();
        
        var current = frames[step];
        current.AddScore(pins);

        AddPinsToPreviousFrames(pins);

        if (IsBonusGameEnd(current) || IsTenFrameEnd(current))
            isGameEnd = true;

        if (current.IsGoingNext)
            step++;
    }

    private bool IsDissatisfy(int pins)
        => IsOutOfPinsRange(pins) || isGameEnd || frames[step].IsOverFrameLimit(pins);

    private bool IsBonusGameEnd(Frame frame)
        => step == 9 && (frame.IsStrike || frame.IsSpare) && frame.ScoreCount == 3;

    private bool IsTenFrameEnd(Frame frame)
        => step == 9 && !frame.IsBonus && frame.ScoreCount >= 2;

    private void AddPinsToPreviousFrames(int pins)
    {
        var takePrevousCount = step == 1 ? 1 : 2;
        if (step >= takePrevousCount)
        {
            var previous = frames.Skip(step - takePrevousCount).Take(takePrevousCount);
            foreach (var frame in previous)
            {
                if (frame.IsSpare || frame.IsStrike)
                {
                    if (frame.Step < 9)
                        frame.AddScore(pins);
                }
            }
        }
    }

    private bool IsOutOfPinsRange(int pins)
        => pins < 0 || pins > 10;

    public int? Score()
        => step == 0 || step < 9 || !isGameEnd
            ? throw new ArgumentException()
            : frames.Take(step + 1).Sum(frame => frame.Score);
}

public class Frame
{
    private const int MAX_SCORE_COUNT = 3;
    private List<int> scores = new List<int>(MAX_SCORE_COUNT);

    public Frame(int step) => Step = step;

    public readonly int Step;
    public bool IsStrike => scores.FirstOrDefault().Equals(10);
    public bool IsSpare => scores.Count() == 2 && scores.Sum() == 10;
    public bool IsGoingNext => Step < 9 && (IsStrike || IsSpare || ScoreCount == 2);
    public bool IsBonus => Step == 9 && (IsStrike || IsSpare);
    public int Score => scores.Sum();
    public int ScoreCount => scores.Count;

    public void AddScore(int pins)
    {
        if (scores.Count == MAX_SCORE_COUNT) return;

        if (IsOverBonusLimit(pins))
            throw new ArgumentException();

        scores.Add(pins);
    }

    private bool IsOverBonusLimit(int pins)
        => IsBonus && IsStrike && !scores.All(x => x == 10) && Score + pins > 20;
}

public static class FrameExtensions
{
    public static bool IsOverFrameLimit(this Frame fram, int pins)
        => !fram.IsBonus && fram.Score + pins > 10;
}