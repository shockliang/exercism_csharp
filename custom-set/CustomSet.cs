using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CustomSet<T> : IEnumerable<T>, IEquatable<IEnumerable<T>>
{
    private IEnumerable<T> values;

    public CustomSet() => this.values = new T[] { };

    public CustomSet(T value)
        => this.values = value == null ? new T[] { } : new T[] { value };

    public CustomSet(IEnumerable<T> values)
        => this.values = values.OrderBy(x => x);

    public CustomSet<T> Insert(T value)
    {
        if (!Contains(value))
            values = values.Append(value).OrderBy(x => x);
        return this;
    }

    public bool IsEmpty() => !values.Any();

    public bool Contains(T value) => values.Contains(value);

    public bool IsSubsetOf(CustomSet<T> right) => values.All(item => right.Contains(item));

    public bool IsDisjointFrom(CustomSet<T> right) => !values.Any(item => right.Contains(item));

    public CustomSet<T> Intersection(CustomSet<T> right)
        => new CustomSet<T>(this.Intersect(right).OrderBy(x => x));

    public CustomSet<T> Difference(CustomSet<T> right)
        => new CustomSet<T>(this.Except(right).OrderBy(x => x));

    public CustomSet<T> Union(CustomSet<T> right)
        => new CustomSet<T>(values.Union(right).OrderByDescending(x => x));

    public IEnumerator<T> GetEnumerator() => values.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public override bool Equals(object obj)
    {
        if (obj.Equals(null))
            return false;

        if (obj is IEnumerable<T>)
            return Equals(obj as IEnumerable<T>);
        else
            return false;
    }

    public override int GetHashCode() => values.GetHashCode();

    public bool Equals(IEnumerable<T> other) => values.SequenceEqual(other);

    public int GetHashCode(IEnumerable<T> obj) => obj.GetHashCode();
}