using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.String;

public static class Grep
{
    public static string Find(string pattern, string flags, string[] files)
    {
        Directory.SetCurrentDirectory(Path.GetTempPath());
        var readFiles = files.Select(file =>
        {
            return new ReadContext()
            {
                FileName = file,
                Context = File.ReadAllText($"{Path.GetTempPath()}/{file}")
                    .Split('\n')
                    .Where(str => !IsNullOrEmpty(str))
            };
        });

        var cmd = new Command(flags, files.Length > 1);
        var part = new Regex(cmd.IsCaseInsenstive ? $"(?i){pattern}" : pattern);
        var matches = new List<MatchResult>();

        foreach (var file in readFiles)
        {
            var context = file.Context
                .Select((section, index) =>
                {
                    var match = new MatchResult();
                    if (cmd.IsMatchEntireLines)
                    {
                        if (cmd.IsCaseInsenstive && section.ToLower().Equals(pattern.ToLower()))
                        {
                            match = SetupMatchResult(index, section, file.FileName, cmd);
                        }
                        else if (section.Equals(pattern))
                        {
                            match = SetupMatchResult(index, section, file.FileName, cmd);
                        }
                        else if (cmd.IsInverMatches)
                        {
                            match = SetupMatchResult(index, section, file.FileName, cmd);
                        }

                        return match;
                    }
                    else if (part.IsMatch(section))
                    {
                        if (cmd.IsInverMatches)
                            return match;
                        else
                            return SetupMatchResult(index, section, file.FileName, cmd);
                    }
                    else if (cmd.IsInverMatches)
                    {
                        return match = SetupMatchResult(index, section, file.FileName, cmd);
                    }
                    else
                    {
                        return match;
                    }
                })
                .Where(matchReuslt => !string.IsNullOrEmpty(matchReuslt.Context));

            matches.AddRange(context);
        }

        return cmd.IsPrintFileName
            ? Concat(matches.GroupBy(item => item.FileName).Select(match => match.Key + '\n'))
            : Concat(matches.CombinMatches());
    }

    private static MatchResult SetupMatchResult(int index, string section, string fileName, Command cmd)
    {
        var match = new MatchResult();
        match.Line = index + 1;
        match.Context = Concat(section.Append('\n'));
        match.FileName = fileName;

        if (cmd.IsPrintLineNumber)
            match.SetLineNumber();

        if (cmd.IsMultiFiles)
            match.SetFileName();

        return match;
    }

    private static IEnumerable<string> CombinMatches(this IEnumerable<MatchResult> source)
    {
        foreach (var item in source)
        {
            yield return item.Context;
        }
    }

    private class ReadContext
    {
        public string FileName { get; set; }
        public IEnumerable<string> Context { get; set; }
    }

    private class MatchResult
    {
        public int Line { get; set; }
        public string Context { get; set; }
        public string FileName { get; set; }

        public void SetLineNumber()
        {
            Context = $"{Line}:{Context}";
        }

        public void SetFileName()
        {
            Context = $"{FileName}:{Context}";
        }
    }

    public class Command
    {
        public bool IsCaseInsenstive { get; set; } = false;
        public bool IsPrintLineNumber { get; set; } = false;
        public bool IsPrintFileName { get; set; } = false;
        public bool IsInverMatches { get; set; } = false;
        public bool IsMatchEntireLines { get; set; } = false;
        public bool IsMultiFiles { get; set; } = false;

        public Command(string flags, bool isMultiFiles)
        {
            var commands = flags
                .Split('-')
                .Select(cmd => cmd.Trim(' '))
                .Where(cmd => !IsNullOrEmpty(cmd));

            if (commands.Contains("n")) { IsPrintLineNumber = true; }
            if (commands.Contains("l")) { IsPrintFileName = true; }
            if (commands.Contains("i")) { IsCaseInsenstive = true; }
            if (commands.Contains("v")) { IsInverMatches = true; }
            if (commands.Contains("x")) { IsMatchEntireLines = true; }
            IsMultiFiles = isMultiFiles;
        }
    }
}