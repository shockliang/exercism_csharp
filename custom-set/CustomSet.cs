using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CustomSet<T> : IEnumerable<T>, IEquatable<IEnumerable<T>>
{
    private IEnumerable<T> values;

    public CustomSet()
    {
        this.values = new T[] { };
    }

    public CustomSet(T value)
    {
        this.values = value == null ? new T[] { } : new T[] { value };
    }

    public CustomSet(IEnumerable<T> values)
    {
        this.values = values.OrderBy(x => x);
    }

    public CustomSet<T> Insert(T value)
    {
        if (!Contains(value))
            values = values.Append(value).OrderBy(x => x);
        return this;
    }

    public bool IsEmpty()
    {
        return values.Equals(null) || values.Count().Equals(0);
    }

    public bool Contains(T value)
    {
        return values.Contains(value);
    }

    public bool IsSubsetOf(CustomSet<T> right)
    {
        if (this.IsEmpty() && right.IsEmpty())
            return true;

        if (this.IsEmpty() && !right.IsEmpty())
            return true;

        if (this.Equals(right))
            return true;

        if (right.Count() > this.Count())
            return values.SequenceEqual(right.Intersect(values));

        return false;
    }

    public bool IsDisjointFrom(CustomSet<T> right)
    {
        if (this.IsEmpty() && right.IsEmpty())
            return true;

        if (this.IsEmpty() && !right.IsEmpty())
            return true;

        if (!this.IsEmpty() && right.IsEmpty())
            return true;

        return Equals(this.Except(right));
    }

    public CustomSet<T> Intersection(CustomSet<T> right)
    {
        return new CustomSet<T>(this.Intersect(right).OrderBy(x => x));
    }

    public CustomSet<T> Difference(CustomSet<T> right)
    {
        var reuslt = this.Except(right);
        return new CustomSet<T>(this.Except(right).OrderBy(x => x));
    }

    public CustomSet<T> Union(CustomSet<T> right)
    {
        var result = values.Union(right).OrderByDescending(x => x);
        return new CustomSet<T>(result);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in values)
            yield return item;
    }

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

    public override int GetHashCode()
    {
        return values.GetHashCode();
    }

    public bool Equals(IEnumerable<T> other)
    {
        return values.SequenceEqual(other);
    }

    public int GetHashCode(IEnumerable<T> obj)
    {
        return obj.GetHashCode();
    }
}