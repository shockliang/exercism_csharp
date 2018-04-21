using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var input = new StreamReader(inStream).ReadToEnd();

        if(input.Equals(""))
        {
            FlushOutput(outStream, new Dictionary<string, Team>());
            return;
        }

        var results = input.Split(Environment.NewLine);
        var tally = results.Aggregate(new Dictionary<string, Team>(), (teams, result) =>
        {
            var match = result.Split(";").ToArray();
            var gameResult = match.Last();
            match = match.Take(2).ToArray();

            foreach (var name in match)
            {
                if (!teams.ContainsKey(name))
                {
                    var team = new Team(name);
                    team.SetGameResult(gameResult);
                    teams.Add(name, team);
                }
                else
                {
                    teams[name].SetGameResult(gameResult);
                }

                if (gameResult.Equals("win"))
                {
                    gameResult = "loss";
                    continue;
                }
                if (gameResult.Equals("loss"))
                {
                    gameResult = "win";
                    continue;
                }
            }

            return teams;
        });

        FlushOutput(outStream, tally);
    }

    private static void FlushOutput(Stream outStream, Dictionary<string, Team> tally)
    {
        using (var outStreamWriter = new StreamWriter(outStream))
        {
            var list = new List<string>();
            list.Add("Team                           | MP |  W |  D |  L |  P");
            list.AddRange(tally
                 .OrderByDescending(x => x.Value.Point)
                 .ThenBy(x => x.Value.Name)
                 .Select(team => team.Value.ToString()));
            outStreamWriter.Write(string.Join(Environment.NewLine, list));
            outStreamWriter.Flush();
        }
    }

    private class Team
    {
        public string Name { get; private set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int Point { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public void SetGameResult(string result)
        {
            Played++;
            switch (result)
            {
                case "win":
                    Won++;
                    Point += 3;
                    break;
                case "draw":
                    Drawn++;
                    Point += 1;
                    break;
                case "loss":
                    Lost++;
                    break;
            }
        }

        public override string ToString()
        {
            var final = new StringBuilder();
            final.Append($"{Name.PadRight(30)} | ");
            final.Append($"{Played.ToString().PadLeft(2)} | ");
            final.Append($"{Won.ToString().PadLeft(2)} | ");
            final.Append($"{Drawn.ToString().PadLeft(2)} | ");
            final.Append($"{Lost.ToString().PadLeft(2)} | ");
            final.Append($"{Point.ToString().PadLeft(2)}");

            return final.ToString();
        }
    }
}
