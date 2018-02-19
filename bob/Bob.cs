using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement)
    {
        string response = "Whatever.";

        statement = statement.Trim();

        bool saidNothing = statement.Length == 0;
        bool isYelling = !saidNothing && statement.Any(char.IsUpper) && statement.Where(char.IsLetter).All(char.IsUpper);
        bool isQuestioning = !saidNothing && statement.EndsWith("?");

        if (isYelling && isQuestioning)
            response = "Calm down, I know what I'm doing!";
        else if (isYelling)
            response = "Whoa, chill out!";
        else if (isQuestioning)
            response = "Sure.";
        else if (saidNothing)
            response = "Fine. Be that way!";

        return response;
    }
}