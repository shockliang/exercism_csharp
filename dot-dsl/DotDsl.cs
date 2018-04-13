using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class Node : BaseCollection
{
    public string Name { get; }

    public Node(string name)
    {
        this.Name = name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (obj is Node)
            return Name.Equals((obj as Node).Name);
        else
            return false;
    }

    public override int GetHashCode() => Name.GetHashCode();
}

public class Edge : BaseCollection
{
    public string PointA { get; }
    public string PointB { get; }

    public Edge(string pointA, string pointB)
    {
        this.PointB = pointB;
        this.PointA = pointA;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (obj is Edge)
            return PointA.Equals((obj as Edge).PointA) && PointB.Equals((obj as Edge).PointB);
        else
            return false;
    }

    public override int GetHashCode()
        => PointA.GetHashCode() ^ PointB.GetHashCode();
}

public class Attr
{
    public string Key { get; }
    public string Value { get; }

    public Attr(string key, string value)
    {
        this.Value = value;
        this.Key = key;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        
        if(obj is Attr)
            return Key.Equals((obj as Attr).Key) && Value.Equals((obj as Attr).Value);
        else
            return false;
    }

    public override int GetHashCode()
        => Key.GetHashCode() ^ Value.GetHashCode();
}

public class Graph : BaseCollection
{
    private List<Node> nodes = new List<Node>();
    private List<Edge> edges = new List<Edge>();

    public IEnumerable<Node> Nodes => nodes;
    public IEnumerable<Edge> Edges => edges;
    public IEnumerable<Attr> Attrs => attrs;

    public Graph()
    {

    }

    public void Add(Node node) => nodes.Add(node);
    public void Add(Edge edge) => edges.Add(edge);
}

public class BaseCollection : IEnumerable<Attr>
{
    protected List<Attr> attrs = new List<Attr>();

    public void Add(string key, string value) => attrs.Add(new Attr(key, value));

    public IEnumerator<Attr> GetEnumerator() => attrs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}