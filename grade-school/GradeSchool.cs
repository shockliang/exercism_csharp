using System;
using System.Linq;
using System.Collections.Generic;

public class School
{
    private IList<Student> students = new List<Student>();

    public void Add(string student, int grade)
    {
        students.Add(new Student(student, grade));
    }

    public IEnumerable<string> Roster()
    {
        return students.OrderBy(x => x.Grade).ThenBy(x => x.Name).Select(x => x.Name);
    }

    public IEnumerable<string> Grade(int grade)
    {
        return students.OrderBy(x => x.Grade).ThenBy(x => x.Name).Where(x => x.Grade >= grade).Select(x => x.Name);
    }
}

internal class Student
{
    public string Name { get; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        this.Grade = grade;
        this.Name = name;
    }
}