using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using static System.String;

public class WordSearch
{
    private List<string> leftToRight;
    private List<string> rightToLeft;
    private List<string> topToBottom;
    private List<string> bottomToTop;
    private List<PuzzleString> topLeftToBottomRight;
    public WordSearch(string puzzle)
    {
        leftToRight = puzzle.Split('\n').ToList();
        rightToLeft = leftToRight.Select(x => Concat(x.Reverse())).ToList();
        topToBottom = Enumerable
            .Range(0, leftToRight.Count)
            .Select(i => Concat(leftToRight.Select(line => line.ElementAt(i))))
            .ToList();
        bottomToTop = topToBottom.Select(x => Concat(x.Reverse())).ToList();

        topLeftToBottomRight = GetDiagonals(leftToRight);
    }

    private List<PuzzleString> GetDiagonals(List<string> puzzleLines)
    {
        var diagonals = new List<PuzzleString>();
        int row = 0, col = 0;
        int step = 1;
        for (int i = 0; i < puzzleLines.Count; i++)
        {
            var str = new List<char>();
            row = 0;
            col = puzzleLines.Count - i - 1;
            var puzzleWord = new PuzzleString();
            for (int j = 0; j < step; j++)
            {
                puzzleWord.Add(puzzleLines[row][col], col, row);
                str.Add(puzzleLines[row][col]);
                row += row < puzzleLines.Count ? 1 : 0;
                col += col < puzzleLines[i].Length ? 1 : 0;
            }
            // diagonals.Add(Concat(str));
            diagonals.Add(puzzleWord);
            step++;
        }

        step = puzzleLines.FirstOrDefault().Length - 1;
        for (int i = 1; i < puzzleLines.Count; i++)
        {
            var str = new List<char>();
            row = i;
            col = 0;
            var puzzleWord = new PuzzleString();
            for (int j = 0; j < step; j++)
            {
                puzzleWord.Add(puzzleLines[row][col++], col, row);
                // str.Add(puzzleLines[row][col++]);
                row += row < puzzleLines.Count ? 1 : 0;
            }
            // diagonals.Add(Concat(str));
            diagonals.Add(puzzleWord);
            step--;
        }

        return diagonals;
    }

    public Tuple<Tuple<int, int>, Tuple<int, int>> Find(string word)
    {
        var regex = new Regex(word);
        var reverseWord = Concat(word.Reverse());

        for (int i = 0; i < leftToRight.Count; i++)
        {
            if (regex.IsMatch(leftToRight[i]))
            {
                var result = regex.Match(leftToRight[i]);
                var start = result.Index;
                var end = start + word.Length;
                return Tuple.Create(Tuple.Create(start + 1, i + 1), Tuple.Create(end, i + 1));
            }
        }

        for (int i = 0; i < rightToLeft.Count; i++)
        {
            if (regex.IsMatch(rightToLeft[i]))
            {
                var result = regex.Match(rightToLeft[i]);
                var start = rightToLeft[i].Length - result.Index;
                var end = start - word.Length + 1;
                return Tuple.Create(Tuple.Create(start, i + 1), Tuple.Create(end, i + 1));
            }
        }

        for (int i = 0; i < topToBottom.Count; i++)
        {
            if (regex.IsMatch(topToBottom[i]))
            {
                var result = regex.Match(topToBottom[i]);
                var start = result.Index + 1;
                var end = start + word.Length - 1;
                return Tuple.Create(Tuple.Create(i + 1, start), Tuple.Create(i + 1, end));
            }
        }

        for (int i = 0; i < bottomToTop.Count; i++)
        {
            if (regex.IsMatch(bottomToTop[i]))
            {
                var result = regex.Match(bottomToTop[i]);
                var start = bottomToTop[i].Length - result.Index;
                var end = bottomToTop[i].Length - (result.Index + word.Length) + 1;
                return Tuple.Create(Tuple.Create(i + 1, start), Tuple.Create(i + 1, end));
            }
        }

        for (int i = 0; i < topLeftToBottomRight.Count; i++)
        {
            if (regex.IsMatch(topLeftToBottomRight[i].ToString()))
            {
                var (start, end) = topLeftToBottomRight[i].GetCoordinate(word);
                return Tuple.Create(Tuple.Create(start.X + 1, start.Y + 1), Tuple.Create(end.X + 1, end.Y + 1));
            }
        }

        return Tuple.Create(Tuple.Create(0, 0), Tuple.Create(0, 0));
    }
}

public class PuzzleString
{
    public List<Point> coordinates { get; private set; } = new List<Point>();
    public List<char> characters { get; private set; } = new List<char>();

    public void Add(char c, int x, int y)
    {
        coordinates.Add(new Point(x, y));
        characters.Add(c);
    }

    public (Point start, Point end) GetCoordinate(string word)
    {
        var str = this.ToString();
        if (str.Contains(word))
        {
            int idx = str.IndexOf(word);
            return (start: coordinates[idx], end: coordinates[idx + word.Length - 1]);
        }

        return (start: Point.Empty, end: Point.Empty);
    }

    public override string ToString() => Concat(characters);
}
