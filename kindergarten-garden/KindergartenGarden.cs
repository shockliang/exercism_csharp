using System;
using System.Linq;
using System.Collections.Generic;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private static readonly List<string> DefaultStudents = new List<string>
    {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };

    private Dictionary<string, List<Plant>> garden;

    public KindergartenGarden(string diagram) : this(diagram, DefaultStudents)
    {
    }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
        garden = students.ToDictionary(s => s, s => new List<Plant>());

        int n = 0;
        foreach (char c in diagram)
        {
            if (char.IsLetter(c))
            {
                garden[students.ElementAt(n / 2)].Add((Plant)c);
                n++;
            }
            else
            {
                n = 0;
            }
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return garden[student];
    }
}