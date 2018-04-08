using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value)
    {
        this.Value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        this.Value = values.FirstOrDefault();

        foreach (var item in values.Skip(1))
        {
            Add(item);
        }
    }

    public int Value { get; }

    public BinarySearchTree Left { get; private set; }

    public BinarySearchTree Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
        var node = new BinarySearchTree(value);

        if (value <= Value)
        {
            if (Left == null)
                Left = node;
            else
                Left.Add(value);
        }
        else
        {
            if (Right == null)
                Right = node;
            else
                Right.Add(value);
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (var left in Left?.AsEnumerable() ?? Enumerable.Empty<int>())
        {
            yield return left;
        }

        yield return Value;

        foreach (var right in Right?.AsEnumerable() ?? Enumerable.Empty<int>())
        {
            yield return right;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}