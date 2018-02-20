using System;
using System.Linq;
using System.Collections.Generic;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private List<string> students = new List<string>(new string[]
    {
        "Alice", "Bob", "Charlie", "David",
        "Eve", "Fred", "Ginny", "Harriet",
        "Ileana", "Joseph", "Kincaid", "Larry"
    }).OrderBy(x => x).ToList();

    private Garden[] gardens;

    public KindergartenGarden(string diagram)
    {
        var plantBucket = diagram.Split("\n");
        var holderCount = plantBucket.FirstOrDefault().Count() / 2;
        gardens = new Garden[students.Count];

        for (int i = 0; i < holderCount; i++)
        {
            var plants = plantBucket[0].Skip(i * 2).Take(2).ToArray().Concat(plantBucket[1].Skip(i * 2).Take(2)).ToArray();
            gardens[i] = new Garden(students[i], plants);
        }

    }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return gardens.Where(x => x.Holer.Equals(student)).FirstOrDefault().Plants;
    }
}

internal class Garden
{
    private static readonly IDictionary<char, Plant> mapping = new Dictionary<char, Plant>()
    {
        ['V'] = Plant.Violets,
        ['R'] = Plant.Radishes,
        ['C'] = Plant.Clover,
        ['G'] = Plant.Grass,
    };

    public string Holer { get; }

    public IEnumerable<Plant> Plants { get; }

    public Garden(string holer, IEnumerable<char> plants)
    {
        this.Holer = holer;
        this.Plants = PlantParser(plants);
    }

    private IEnumerable<Plant> PlantParser(IEnumerable<char> plants)
    {
        return plants.Select(x => mapping[x]);
    }
}