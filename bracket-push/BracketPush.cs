using System;
using System.Linq;
using System.Collections.Generic;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        var filtered = input
            .Where(c => c.Equals('(') || c.Equals(')') ||
                        c.Equals('[') || c.Equals(']') ||
                        c.Equals('{') || c.Equals('}'))
            .ToArray();

        var brackets = string.Concat(filtered);

        while (brackets.Length > 0)
        {
            brackets = brackets.Replace("()", "").Replace("[]", "").Replace("{}", "");
            
            if (brackets.Length == filtered.Length || brackets.Length % 2 != 0)
            {
                return false;
            }
        }
        
        return true;
    }
}
