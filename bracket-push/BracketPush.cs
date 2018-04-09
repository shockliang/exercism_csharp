using System;
using System.Linq;
using System.Collections.Generic;

public static class BracketPush
{
    private const string open = "[{(";
    private const string close = "]})";

    public static bool IsPaired(string input)
    {
        var stack = new Stack<char>();

        return input
            .Where(c => "[]{}()".Contains(c))
            .All(stack.Match) && !stack.Any();
    }

    private static bool Match(this Stack<char> brackets, char c)
    {
        if (open.Contains(c))
        {
            brackets.Push(c);
            return true;
        }
        if (!brackets.Any()) return false;
        return open.IndexOf(brackets.Pop()) == close.IndexOf(c);
    }
}
