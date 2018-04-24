using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static System.String;

public class WordSearch
{
    private List<string> leftToRight;
    private List<string> rightToLeft;
    private List<string> topToBottom;
    private List<string> bottomToTop;
    private List<string> diagonals;

    private List<string> topLeftToBottomRight;
    public WordSearch(string puzzle)
    {
        leftToRight = puzzle.Split('\n').ToList();
        rightToLeft = leftToRight.Select(x => Concat(x.Reverse())).ToList();
        topToBottom = Enumerable
            .Range(0, leftToRight.Count)
            .Select(i => Concat(leftToRight.Select(line => line.ElementAt(i))))
            .ToList();
        bottomToTop = topToBottom.Select(x => Concat(x.Reverse())).ToList();
        diagonals = new List<string>();
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

        

        return Tuple.Create(Tuple.Create(0, 0), Tuple.Create(0, 0));
    }
}
