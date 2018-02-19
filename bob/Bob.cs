using System;
using System.Text.RegularExpressions;

public static class Bob
{
    private static Regex lettersRegex = new Regex(@"[a-zA-Z]");
    private static Regex numberRegex = new Regex(@"[0-9]");

    public static string Response(string statement)
    {
        statement = statement.TrimEnd();

        if (IsQuestion(statement))
            if (IsYell(statement) && IsLetters(statement))
                return "Calm down, I know what I'm doing!";
            else
                return "Sure.";
        else if (IsYell(statement))
            return "Whoa, chill out!";
        else if (IsSilence(statement))
            return "Fine. Be that way!";
        else
            return "Whatever.";
    }

    private static bool IsQuestion(string statement)
    {
        return statement.EndsWith("?");
    }

    private static bool IsYell(string statement)
    {
        return statement == statement.ToUpper() && !IsSilence(statement) && !IsOnlyNumber(statement);
    }

    private static bool IsSilence(string statement)
    {
        return string.IsNullOrEmpty(statement) || string.IsNullOrWhiteSpace(statement);
    }

    private static bool IsLetters(string statement)
    {
        return lettersRegex.IsMatch(statement);
    }

    private static bool IsOnlyNumber(string statement)
    {
        return numberRegex.IsMatch(statement) && !lettersRegex.IsMatch(statement);
    }
}