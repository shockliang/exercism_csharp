using System;
using System.Linq;
using System.Collections.Generic;

public class School
{
    private IList<Student> students = new List<Student>();

    public void Add(string student, int grade)
    {
        if (students.FirstOrDefault(x=>x.Name.Equals(student)) == null)
            students.Add(new Student(student, grade));
    }

    public IEnumerable<string> Roster()
    {
        return from student in students
               orderby student.Grade, student.Name
               select student.Name;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return from student in students
               where student.Grade >= grade
               orderby student.Grade, student.Name
               select student.Name;
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